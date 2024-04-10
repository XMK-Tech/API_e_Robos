using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Commom;

public class CourierServices : ICourierServices
{
    private readonly IPDFGenerator _pdfGenerator;
    
    private readonly PostOfficeConsumer.AtendeClienteClient Consumer;
    private readonly PostOfficeConsumer.AtendeClienteClient AddressFinder;

    private readonly IEntitiesServices _entitiesServices;

    private static readonly string SIGEPWEB_HOMO_URL = "https://apphom.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";
    private static readonly string SIGEPWEB_PROD_URL = "https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";

    public CourierServices(IEntitiesServices entitiesServices, IPDFGenerator pdfGenerator, IConfiguration configuration)
    {
        _entitiesServices = entitiesServices;
        _pdfGenerator = pdfGenerator;
            
        var system_url = configuration.GetSection("Integrations")["SIGEPWEB_URL"];
        Consumer = new();
        Consumer.Endpoint.Address = new System.ServiceModel.EndpointAddress(system_url);

        AddressFinder = new();
        AddressFinder.Endpoint.Address = new System.ServiceModel.EndpointAddress(SIGEPWEB_PROD_URL);
    }

    private void ValidateHomoCredentials(SIGEPWEBCredentialsViewModel credentials)
    {
        if (credentials == null)
            return;

        if (credentials.Document == "34028316000103" && credentials.User == "sigep" && credentials.Contract == "9992157880" && credentials.Card == "0067599079")
            Consumer.Endpoint.Address = new System.ServiceModel.EndpointAddress(SIGEPWEB_HOMO_URL);
    }

    public async Task<byte[]> TryPost(CourierDataViewModel data)
    {
        var entity = GetEntity();
        
        var credentials = Credentials(entity);

        data.Contract = credentials?.Contract;
        data.SenderName = entity?.Name;

        if (entity.DemoMode.HasValue && entity.DemoMode.Value)
            return await GetDemonstrationFile(data);

        ValidateHomoCredentials(credentials);
        await ValidateCredentials(credentials);

        await AddressValidation(data);

        var serviceIdentifier = await Service(credentials);
        //await ValidateServiceAvailability(credentials, serviceIdentifier, data.Devolution.ZipCode, data.Recipient.ZipCode);

        var edicatte = await GetEdicatte(credentials, serviceIdentifier);
        var edicatteWithChecker = await SetCheck(credentials, edicatte);

        var xml = await BuildPlpXml(credentials, edicatteWithChecker, serviceIdentifier, data, entity);

        var plpResponse = await Consumer.fechaPlpAsync(xml, 0, credentials.Card, edicatte + "," + edicatte, credentials.User, credentials.Password);

        data.EdicatteWithChecker = edicatteWithChecker;

        return await _pdfGenerator.Generate(data, "AR");
    }
    
    public async Task<PostOfficeConsumer.enderecoERP> GetAddress(string zipCode)
    {
        if (string.IsNullOrEmpty(zipCode))
            return null;

        PostOfficeConsumer.consultaCEPResponse response;
        zipCode = zipCode.Replace("-", "");

        try
        {            
            response = await AddressFinder.consultaCEPAsync(zipCode);
        }
        catch
        {
            throw new BadRequestException($"CEP {zipCode} inválido.");
        }

        return response.@return;
    }

    private async Task ValidateCredentials(SIGEPWEBCredentialsViewModel credentials)
    {
        if (credentials == null || credentials.User == null && credentials.Password == null)
            throw new BadRequestException("As credenciais de acesso ao sistema dos correios dessa subsidiária não foram encontradas.");

        bool hasError = false;
        PostOfficeConsumer.getStatusCartaoPostagemResponse response = null;
        try
        {
            response = await Consumer.getStatusCartaoPostagemAsync(credentials?.Card, credentials?.User, credentials?.Password);
        }
        catch (Exception)
        {
            hasError = true;
        }
        
        if (hasError || response?.@return != PostOfficeConsumer.statusCartao.Normal)
            throw new ForbiddenException($"Houve um problema de autenticação na plataforma dos correios(Estado das credenciais: {response?.@return})");
    }

    private static SIGEPWEBCredentialsViewModel Credentials(EntitiesViewModel entity)
    {
        return entity?.ITR?.Credentials;
    }

    private EntitiesViewModel GetEntity()
    {
        return _entitiesServices.View();
    }

    private async Task<byte[]> GetDemonstrationFile(CourierDataViewModel data)
    {
        data.EdicatteWithChecker = "JL030488202BR";

        data.ZipcodeRecipientResponse = DemoModeAddress(data.Recipient);
        data.ZipcodeDevolutionResponse = DemoModeAddress(data.Devolution);

        return await _pdfGenerator.Generate(data, "AR");
    }

    private static PostOfficeConsumer.enderecoERP DemoModeAddress(CourierAddressViewModel address)
    {
        return new()
        {
            end = address.Street,
            bairro = address.District,
            cep = address.ZipCode,
            cidade = address.CityName,
            uf = address.StateName,
        };
    }

    private async Task<string> GetEdicatte(SIGEPWEBCredentialsViewModel credentials, PostOfficeConsumer.servicoERP service)
    {
        var response = await Consumer.solicitaEtiquetasAsync("C", credentials.Document, service.id, 1, credentials.User, credentials.Password);
        var interval = response.@return.Split(',');
        return interval.First();
    }
    
    private async Task<string> SetCheck(SIGEPWEBCredentialsViewModel credentials, string edicatte)
    {
        var lst = new List<string>() { edicatte }.ToArray();
        var response = await Consumer.geraDigitoVerificadorEtiquetasAsync(lst, credentials.User, credentials.Password);

        var checker = response.@return.FirstOrDefault();
        return edicatte.Replace(" ", checker.ToString());
    }

    private async Task<PostOfficeConsumer.servicoERP> Service(SIGEPWEBCredentialsViewModel credentials)
    {
        var response = await Consumer.buscaClienteAsync(credentials.Contract, credentials.Card, credentials.User, credentials.Password);
        var availableServices = response.@return?.contratos?.First()?.cartoesPostagem?.First()?.servicos;

        if (availableServices == null && !availableServices.Any())
            throw new BadRequestException("Não há nenhum serviço disponível para este cartão de postagem.");

        return availableServices.First();
    }

    private async Task ValidateServiceAvailability(SIGEPWEBCredentialsViewModel credentials, PostOfficeConsumer.servicoERP service, string origin, string destiny)
    {
        origin = origin.Replace("-", "");
        destiny = destiny.Replace("-", "");

        var adminCode = int.Parse(credentials.AdministrativeCode);
        
        PostOfficeConsumer.verificaDisponibilidadeServicoResponse response = null;

        try
        {
            var serviceCode = service.codigo.Replace(" ", "");
            response = await Consumer.verificaDisponibilidadeServicoAsync(adminCode, serviceCode, origin, destiny, credentials.User, credentials.Password);

        }
        catch (Exception ex)
        {
            throw new NotFoundException("Houve uma falha na comunicação com o sistema dos correios. Não foi possível validar a disponibilidade do serviço desejado.");
        }

        if (response.@return != "0#")
            throw new ForbiddenException(response.@return);
    }
    
    private async Task<string> GetBoardCode(SIGEPWEBCredentialsViewModel credentials)
    {
        var response = await Consumer.buscaClienteAsync(credentials.Contract, credentials.Card, credentials.User, credentials.Password);
        return response.@return?.contratos?.First()?.codigoDiretoria; ;
    }

    private async Task AddressValidation(CourierDataViewModel data)
    {
        var messages = new List<string>();
        try
        {
            data.ZipcodeRecipientResponse = await SingleAddressValidation(data.Recipient, "do destinatário");
            data.ZipcodeDevolutionResponse = await SingleAddressValidation(data.Devolution, "de devolução");
        }
        catch(DomainException ex)
        {
            messages.AddRange(ex.ValidationMessages);
        }
               
        if(messages.Any())
            throw new BadRequestException(messages);
    }
    
    private async Task<PostOfficeConsumer.enderecoERP> SingleAddressValidation(CourierAddressViewModel address, string type)
	{
		var cepAddress = await GetAddress(address.ZipCode);

        if (cepAddress == null)
            throw new BadRequestException($"As informações de endereço {type} não foram encontradas. Confirme o CEP.");

		if (string.IsNullOrEmpty(cepAddress.end))
			cepAddress.end = address.Street;

		if (string.IsNullOrEmpty(cepAddress.bairro))
			cepAddress.bairro = address.District;

		if (string.IsNullOrEmpty(cepAddress.complemento2))
			cepAddress.complemento2 = address.Complement;

		CheckNumberFormat(address, cepAddress);

		var messages = new List<string>();

		if (!Compare(cepAddress.cidade, address.CityName))
			messages.Add(AddressValidateFormat(type, "cidade", address.ZipCode));

		if (string.IsNullOrEmpty(address.Number))
			messages.Add($"O número {type} é um campo obrigatório. E não foi encontrato nos serviços dos correios.");

		if (messages.Any())
			throw new BadRequestException(messages);

		return cepAddress;
	}

	private static void CheckNumberFormat(CourierAddressViewModel address, PostOfficeConsumer.enderecoERP cepAddress)
	{
        if (!string.IsNullOrEmpty(address.Number))
            return;

		cepAddress.end = FindNumberForCharacter(",", address, cepAddress.end);

		if (!string.IsNullOrEmpty(address.Number))
			return;

		cepAddress.end = FindNumberForCharacter(" ", address, cepAddress.end);

		if (!string.IsNullOrEmpty(address.Number))
			return;

		FindNumberForCharacter(",", address, address.Street);

		if (!string.IsNullOrEmpty(address.Number))
			return;

		FindNumberForCharacter(" ", address, address.Street);
	}

	private static string FindNumberForCharacter(string splitBy, CourierAddressViewModel address, string source)
	{
		if (!source.Contains(splitBy))
			return source;

		var fields = source.Split(splitBy);
        if (fields.Length == 1)
			return source;

		var targetIndex = fields.Length - 1;

		var isNumber = int.TryParse(fields[targetIndex], out _);
		if (!isNumber)
			return source;

		address.Number = fields[targetIndex];
		return string.Join(splitBy, fields, 0, targetIndex);
	}

	private static bool Compare(string str1, string str2)
    {
        return str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase);
    }

    private static string AddressValidateFormat(string type, string field, string zipcode)
    {
        return $"O campo '{field}' {type} não confere com os dados do CEP {zipcode}.";
    }

    private async Task<string> BuildPlpXml(SIGEPWEBCredentialsViewModel credentials, string edicatteWithChecker, PostOfficeConsumer.servicoERP service, CourierDataViewModel data, EntitiesViewModel entity)
    {
        var boardCode = await GetBoardCode(credentials);

        var person = data.RecipientInfo;
        var recipient = data.Recipient ;
        var devolution = data.Devolution;

        return "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" + $@"
                    <correioslog>
                        <tipo_arquivo> Postagem </tipo_arquivo>
                        <versao_arquivo> 2.3 </versao_arquivo>
                        <plp>
                            <id_plp/>
                            <valor_global/>
                            <mcu_unidade_postagem/>
                            <nome_unidade_postagem/>
                            <cartao_postagem> {credentials.Card} </cartao_postagem>
                        </plp>
                        <remetente>
                            <numero_contrato> {credentials.Contract} </numero_contrato>
                            <numero_diretoria> {boardCode} </numero_diretoria>
                            <codigo_administrativo> {credentials.AdministrativeCode} </codigo_administrativo>

                            <nome_remetente><![CDATA[{entity.Name}]]></nome_remetente>
                            <logradouro_remetente><![CDATA[{devolution.Street}]]></logradouro_remetente>
                            <numero_remetente> {devolution.Number} </numero_remetente>
                            <complemento_remetente>{devolution.Complement}</complemento_remetente>
                            <bairro_remetente><![CDATA[{devolution.District}]]></bairro_remetente>
                            <cep_remetente> {devolution.ZipCode.Replace("-","")} </cep_remetente>
                            <cidade_remetente> <![CDATA[{devolution.CityName}]]> </cidade_remetente>
                            <uf_remetente> {devolution.StateName} </uf_remetente>
                            <telefone_remetente></telefone_remetente>
                            <fax_remetente></fax_remetente> 
                            <email_remetente></email_remetente>
                            <celular_remetente/>
                            <cpf_cnpj_remetente> {person.Document} </cpf_cnpj_remetente>
                            <ciencia_conteudo_proibido> N </ciencia_conteudo_proibido>
                        </remetente>
                        <forma_pagamento/>
                        <objeto_postal>
                            <numero_etiqueta> {edicatteWithChecker} </numero_etiqueta >>
                            <sscc>  </sscc>
                            <codigo_objeto_cliente/>
                            <codigo_servico_postagem> {service.codigo} </codigo_servico_postagem>
                            <cubagem> 0,00 </cubagem>
                            <peso> 15 </peso>
                            <rt1/>
                            <rt2/>
                            <restricao_anac/>
                            <destinatario>
                                <nome_destinatario>
                                    <![CDATA[{person.Name}]]>
                                </nome_destinatario>
                                <telefone_destinatario />
                                <celular_destinatario />
                                <email_destinatario />
                                <logradouro_destinatario>
                                    <![CDATA[{recipient.Street}]]>
                                </logradouro_destinatario>
                                <complemento_destinatario>
                                    <![CDATA[{recipient.Complement}]]>
                                </complemento_destinatario>
                                <numero_end_destinatario> {recipient.Number} </numero_end_destinatario>
                                <cpf_cnpj_destinatario>
                                </cpf_cnpj_destinatario>
                            </destinatario>
                            <nacional>
                                <bairro_destinatario>
                                    <![CDATA[{recipient.District}]]>
                                </bairro_destinatario>
                                <cidade_destinatario>
                                    <![CDATA[{recipient.CityName}]]>
                                </cidade_destinatario>
                                <uf_destinatario> {recipient.StateName} </uf_destinatario>
                                <cep_destinatario>
                                    <![CDATA[{recipient.ZipCode}]]>
                                </cep_destinatario>
                                <codigo_usuario_postal/>
                                <centro_custo_cliente/>
                                <numero_nota_fiscal/>
                                <serie_nota_fiscal/>
                                <valor_nota_fiscal/>
                                <natureza_nota_fiscal/>
                                <descricao_objeto>
                                    <![CDATA[{recipient.Description}]]>
                                </descricao_objeto>
                                <valor_a_cobrar> 0,0
                                </valor_a_cobrar>
                            </nacional>
                            <servico_adicional>
                                <codigo_servico_adicional> 025 </codigo_servico_adicional>
                                <codigo_servico_adicional> 001 </codigo_servico_adicional>
                                <valor_declarado> 15,00 </valor_declarado>
                            </servico_adicional>
                            <dimensao_objeto>
                                <tipo_objeto> 001 </tipo_objeto>
                                <dimensao_altura> 0 </dimensao_altura>
                                <dimensao_largura> 0 </dimensao_largura>
                                <dimensao_comprimento> 0 </dimensao_comprimento>
                                <dimensao_diametro> 0 </dimensao_diametro>
                            </dimensao_objeto>
                            <data_postagem_sara/>
                            <status_processamento> 0 </status_processamento>
                            <numero_comprovante_postagem/>
                            <valor_cobrado/>
                        </objeto_postal>   
                    </correioslog> ";
    }

}
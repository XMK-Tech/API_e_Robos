using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var templates = new List<NoticeTemplate>()
            {
                new NoticeTemplate()
                {
                    Id = Guid.Parse("9896b39f-571a-489e-a496-ee819c5e3138"),
                    Template = "<!DOCTYPE html><html lang=\"pt-br\"><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\" /><meta charset=\"utf-8\" /><title>Notificação de constatação</title></head><body><table><tr style=\"vertical-align: middle; width: 100%;\"><td colspan=\"1\"><div style=\"vertical-align: middle;\"><img src=\"@logoMunicipio\" alt=\"logo\" style=\"width:90px;height:90px;\"></div></td><td colspan=\"4\"><div colspan style=\"vertical-align: middle;\"><h2>Prefeitura Municipal de @nomeMunicipio - @siglaEstado</h2><h3>Notificação de constatação</h3></div></td></tr></table><div style=\"width: 100%\">Documento Nº: @numeroNotificacao <br>Sujeito Passivo: @nomeDoIntimado <br>CPF/CNPJ: @documentoDoIntimado <br></div><br><div><h1 style=\"text-align: center;\">Notificação de constatação</h1><p style=\"text-align: justify;\">Formalizada a constatação da inconsistência na declaração dos dados perante a receita do município de@municipio, faz-se necesário a implantação de tal medida para sanar as pendências perante a sociedade.</p></div><br><br><br><br><br><div><p style=\"text-align: right;\">@municipio, @siglaEstado, @dataAtual</p></div><br><footer style=\"bottom: 0; width: 100%;\"><div style=\"text-align: right;\"><hr size=\"3\" width=\"20%\" align=\"right\" style=\"background-color: black;\">@nomeAuditor<br>Auditora(or) Fiscal<br>--- <br></div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><div><div style=\"text-align: left; float:left\">Folha @paginaAtual</div><div style=\"text-align: right; float:right\">@dataAtual &nbsp</div></div></footer></body></html>",
                    Name = "Modelo de constatação",
                    Type = NoticeType.Realization,
                    DaysToExpire = 10,
                    Module = Module.DTE,
                },
                new NoticeTemplate()
                {
                    Id = Guid.Parse("15cceb60-24ea-48b7-8ec9-f7764d9fec8e"),
                    Template = "<!DOCTYPE html><html lang=\"pt-br\"><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\" /><meta charset=\"utf-8\" /><title>Notificação de lançamento</title></head><body><table><tr style=\"vertical-align: middle; width: 100%;\"><td colspan=\"1\"><div style=\"vertical-align: middle;\"><img src=\"@logoMunicipio\" alt=\"logo\"style=\"width:90px;height:90px;\"></div></td><td colspan=\"4\"><div colspan style=\"vertical-align: middle;\"><h2>Prefeitura Municipal de @nomeMunicipio - @siglaEstado</h2><h3>Notificação de lançamento</h3></div></td></tr></table><div style=\"width: 100%\">Documento Nº: @numeroNotificacao <br>Sujeito Passivo: @nomeDoIntimado <br>CPF/CNPJ: @documentoDoIntimado <br></div><br><div><h1 style=\"text-align: center;\">Notificação de lançamento</h1><p style=\"text-align: justify;\">Tendo em vista a constatação préviamente relatada da irregularidade fiscal do indivíduo @nomeDoIntimado, inscrito no documento @documentoDoIntimado, informa-se que o processo foi devidamente anexado aos sistemas da receita federal. Em breve será emitida o Auto de notificação informando as condições para regularização de sua situação fiscal perante a união.</p></div><br><br><br><br><br><div><p style=\"text-align: right;\">@municipio, @siglaEstado, @dataAtual</p></div><br><footer style=\"bottom: 0; width: 100%;\"><div style=\"text-align: right;\"><hr size=\"3\" width=\"20%\" align=\"right\" style=\"background-color: black;\">@nomeAuditor <br>Auditora(or) Fiscal <br>--- <br></div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><div><div style=\"text-align: left; float:left\">Folha @paginaAtual</div><div style=\"text-align: right; float:right\">@dataAtual &nbsp</div></div></footer>  </body></html>",
                    Name = "Modelo de lançamento",
                    Type = NoticeType.Launch,
                    DaysToExpire = 10,
                    Module = Module.DTE,
                },
                new NoticeTemplate()
                {
                    Id = Guid.Parse("a61bf356-99db-43b2-8683-549b789b3738"),
                    Template = "<!DOCTYPE html><html lang=\"pt-br\"><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\" /><meta charset=\"utf-8\" /><title>Notificação de intimação</title></head><body><table><tr style=\"vertical-align: middle; width: 100%;\"><td colspan=\"1\"><div style=\"vertical-align: middle;\"><img src=\"@logoMunicipio\" alt=\"logo\"style=\"width:90px;height:90px;\"></div></td><td colspan=\"4\"><div colspan style=\"vertical-align: middle;\"><h2>Prefeitura Municipal de @nomeMunicipio - @siglaEstado</h2><h3>Notificação de intimação</h3></div></td></tr></table><div style=\"width: 100%\">Documento Nº: @numeroNotificacao <br>Sujeito Passivo: @nomeDoIntimado <br>CPF/CNPJ: @documentoDoIntimado <br></div><br><div><h1 style=\"text-align: center;\">Notificação de intimação</h1><p style=\"text-align: justify;\">Partindo das intimações de constatação e lançamento enviadas anteriormente para o indivíduo @nomeDoIntimado, inscrito no documento @documentoDoIntimado, informa-se que é necessário seguir os seguintes procedimentos para quitar suas pendências perante a receita federal.<br><ul><li>Dar abertura no processo no site da receita federal;</li><li>Garantir a consistência de suas declarações que foram anexadas ao processo;</li><li>Realizar o pagamento das pendências, e taxas decorrentes dos atrasos, no sistema da receita federal;</li><li>Finalizar o processo até @expiracao;</li></ul><br>O não cumprimento dos itens supracitados dentro do prazo resultará em um processo judicial visando a quitação das pendências com a união.</p></div><br><br><br><br><br><div><p style=\"text-align: right;\">@municipio, @siglaEstado, @dataAtual</p></div><br><footer style=\"bottom: 0; width: 100%;\"><div style=\"text-align: right;\"><hr size=\"3\" width=\"20%\" align=\"right\" style=\"background-color: black;\">@nomeAuditor <br>Auditora(or) Fiscal <br>--- <br></div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><div><div style=\"text-align: left; float:left\">Folha @paginaAtual</div><div style=\"text-align: right; float:right\">@dataAtual &nbsp</div></div></footer>  </body></html>",
                    Name = "Modelo de intimação",
                    Type = NoticeType.Subpoena,
                    DaysToExpire = 10,
                    Module = Module.DTE,
                },

                new NoticeTemplate()
                {
                    Id = Guid.Parse("F9E27BFD-4FA2-47D5-B226-17066E7CB6B2"),
                    Template = "<p><img src=\"https://locomotiva.digital/imagens/horizontal_preto.svg\"></p><p class=\"ql-align-right\"><strong>Secretaria Municipal da Fazenda</strong></p><p class=\"ql-align-right\">Auditoria Fiscal Municipal</p><p class=\"ql-align-right\">Av. Antônio Carlos, 6055 • DCC • Sala 2050 • Pampulha</p><p class=\"ql-align-right\">88304-053 • Belo Horizonte • MG</p><p class=\"ql-align-right\">fone: 4002-8922</p><h1 class=\"ql-align-center\">Aviso prévio </h1><h3 class=\"ql-align-center\"><em>Número de Controle: @numeroNotificacao</em></h3><p><strong>Contribuinte intimado</strong></p><p><strong> Nome: @nomeContribuinte </strong></p><p><strong>Endereço</strong>: @rua, @numeroEndereco @bairro/@estado - CEP: @cep</p><p><strong>Inscrição Municipal</strong>: @inscricaoMunicipal</p><p><strong>CPF/CNPJ</strong>: @cnpj</p><p>Detectou-se a não apresentação da Declaração Mensal de Serviços - Instituições Financeiras (DMS-IF) prevista no Decreto Municipal nº 10.398/2014,</p><p> art. 2°, § 3º (até dez/2018) e Decreto Municipal 11512/2018 (após jan/2019).</p><p><br></p><p> Em caso de autorregularização, providenciar, no prazo de 15 (dez) dias, a apresentação das declarações nos termos desta notificação e, quando o caso, </p><p> também o pagamento ou parcelamento dos valores advindos das declarações.</p><p><strong> Competências a regularizar: Outubro/2017 a Março/2019 </strong></p><p><strong> Instruções: </strong></p><ol><li><strong> A regularização deverá ser realizada com entrega (no Portal http://locomotiva.gov.br) das declarações faltantes; </strong></li><li>Para a regularização, <strong> será necessário a quitação das divergências com o devido juros. </strong></li><li><strong>Após regularização, enviar cópias dos recibos ao e-mail loco.motiva@digital.com;</strong></li><li>A não regularização no prazo estipulado sujeitará o contribuinte à instauração de Ação Fiscal e ao lançamento, de ofício do tributo, bem como à aplicação das penalidades aplicáveis;</li><li><br></li><li>Caso o empreendimento não estivesse em funcionamento na época notificada, apresentar documentação comprobatória (ex. CNPJ) e, quando cabível, justificativas.</li><li>Caso haja discrepâncias com relação a não entrega de declarações, apresentar os protocolos/comprovantes de entrega.</li></ol><p><strong> Prazo máximo para Regularização ou impugnação: </strong></p><p>@expiracao</p><p class=\"ql-align-right\"><strong>Documento lavrado em: </strong> @dataAtual</p>",
                    Name = "Auto de infração para contribuintes",
                    Type = NoticeType.Notice,
                    DaysToExpire = 14,
                    Module = Module.ISS,
                },
                new NoticeTemplate()
                {
                    Id = Guid.Parse("486A4703-84E2-4657-BB04-AB3FF8DDA23F"),
                    Template = "<div style=\"margin-bottom: 50px;\"><div style=\"display: flex; justify-content: space-around; align-items: center;\"><div><img src=\"https://media-exp1.licdn.com/dms/image/C4E1BAQE4F3AtAtYckg/company-background_10000/0/1592668162937?e=2147483647&v=beta&t=r869XX2I-M0WT2A4gdnVUrye-d_MyTCz-NVIABvgkXU\" style=\"width: 300px;\"></div><div style=\"color: rgb(102, 102, 102)\"><p style=\"text-align: right;\"><strong>Secretaria Municipal da Fazenda</strong></p><p style=\"text-align: right;\">Auditoria Fiscal Municipal<br />Av. Carlos Luz, 302 • ORL • Sala 103 • Copacabana<br />30488-000 •Rio de Janeiro •MG<br />fone: 8922-4002</p></div></div><divstyle=\"border: 1px solid black; display: flex;justify-content: center;flex-direction: column; margin: 0px 0px 0px 0px;\"><h1 style=\"text-align: center; font-size:23px;\">Notificação de divergência fiscal <br /></h1><h3 style=\"text-align: center; margin-top: 0px;\"><i>Número de Controle: @numeroNotificacao</i></h3></div><div style=\"display: flex; margin: 0px 0px 0px 0px; flex-direction: column;\"><p><strong>Contribuinte intimado</strong></p><div style=\"border: 1px solid black; display: flex; flex-direction: column;\"><div style=\"border-bottom: 1px solid black;\"><p style=\"margin-left: 15px;\"><strong>Nome: @nomeContribuinte</strong></p></div><div style=\"border-bottom: 1px solid black;\"><p style=\"margin-left: 15px;\"><strong>Endereço</strong>: @rua, @numeroEndereco @bairro/@estado - CEP: @cep</p></div><div style=\"display: flex; \"><div style=\"width: 50%;\"><p style=\"text-align: left; padding-left: 15px; width: 50%;\"><strong>Inscrição Municipal</strong>: @inscricaoMunicipal</p></div><div style=\"border-left: 1px solid black; width: 50%;\"><p style=\"text-align: left; padding-left: 15px;\"><strong>CPF/CNPJ</strong>: @cnpj</p></div></div></div></div><div style=\"margin: 0px 0px 0px 0px;\"><p>Com base no código de normas que regem a população carioca, mais conhecidas como leis, foram identificadas uma(s) divergência(s) em sua declarações. <br>Portando, faz-se necessário que esse problema seja solucionado dentro do prazo estimado, ou as consequências legais serão aplicadas a pessoa jurídica.</p></div><div style=\"margin: 0px 0px 0px 0px;\"><p><strong>Competências a regularizar: Fevereiro/2017 a Março/2018</strong></p></div><div style=\"margin: 0px 0px 0px 0px;\"><p><strong>Instruções:</strong></p></div><div style=\"margin: 0px 20px 30px 20px; border: 1px solid black;\"><ol><li><strong>A regularização deverá ser realizada com entrega (no Portal http://yellows.gov.br) dasdeclarações faltantes;</strong></li><li>Para a regularização,<strong>   será necessário a quitação das divergências com o devido juros.</strong></li><li><strong>Após regularização, enviar cópias dos recibos ao e-mail yellows.motiva@digital.com para as devidas validações;</strong></li></ol></div><div style=\"margin: 0px 20px 0px 20px; border: 1px solid black;\"><div style=\"border-bottom: 1px solid black;\"><p style=\"text-align: left; padding-left: 15px;\"><strong>Prazo máximo para Regularização ou impugnação:</strong></p></div><div><p style=\"text-align: left; padding-left: 15px;\">@expiracao</p></div></div><div style=\"margin: 0px 225px 0px 225px;\"><p style=\"text-align: right;\"><strong>Documento lavrado em: </strong>@dataAtual</p></div></div>",
                    Name = "Notificação para operadores de cartões",
                    Type = NoticeType.Warning,
                    DaysToExpire = 7,
                    Module = Module.ISS,
                },
                new NoticeTemplate()
                {
                    Id = Guid.Parse("FE502F45-43FC-4125-8C0A-49ECE897EB10"),
                    Template = "<div style=\"margin-bottom: 50px;\"><div style=\"display: flex; justify-content: space-around; align-items: center;\"><div><img src=\"https://media-exp1.licdn.com/dms/image/C4E1BAQE4F3AtAtYckg/company-background_10000/0/1592668162937?e=2147483647&v=beta&t=r869XX2I-M0WT2A4gdnVUrye-d_MyTCz-NVIABvgkXU\" style=\"width: 300px;\"></div><div style=\"color: rgb(102, 102, 102)\"><p style=\"text-align: right;\"><strong>Secretaria Municipal da Fazenda</strong></p><p style=\"text-align: right;\">Auditoria Fiscal Municipal<br />Av. Carlos Luz, 302 • ORL • Sala 103 • Copacabana<br />30488-000 •Rio de Janeiro •MG<br />fone: 8922-4002</p></div></div><divstyle=\"border: 1px solid black; display: flex;justify-content: center;flex-direction: column; margin: 0px 0px 0px 0px;\"><h1 style=\"text-align: center; font-size:23px;\">Aviso de divergência fiscal <br /></h1><h3 style=\"text-align: center; margin-top: 0px;\"><i>Número de Controle: @numeroNotificacao</i></h3></div><div style=\"display: flex; margin: 0px 0px 0px 0px; flex-direction: column;\"><p><strong>Contribuinte intimado</strong></p><div style=\"border: 1px solid black; display: flex; flex-direction: column;\"><div style=\"border-bottom: 1px solid black;\"><p style=\"margin-left: 15px;\"><strong>Nome: @nomeContribuinte</strong></p></div><div style=\"border-bottom: 1px solid black;\"><p style=\"margin-left: 15px;\"><strong>Endereço</strong>: @rua, @numeroEndereco @bairro/@estado - CEP: @cep</p></div><div style=\"display: flex; \"><div style=\"width: 50%;\"><p style=\"text-align: left; padding-left: 15px; width: 50%;\"><strong>Inscrição Municipal</strong>: @inscricaoMunicipal</p></div><div style=\"border-left: 1px solid black; width: 50%;\"><p style=\"text-align: left; padding-left: 15px;\"><strong>CPF/CNPJ</strong>: @cnpj</p></div></div></div></div><div style=\"margin: 0px 0px 0px 0px;\"><p>Com base no código de normas que regem a população carioca, mais conhecidas como leis, foram identificadas uma(s) divergência(s) em sua declarações. <br>Portando, faz-se necessário que esse problema seja solucionado dentro do prazo estimado, ou as consequências legais serão aplicadas a pessoa jurídica.</p></div><div style=\"margin: 0px 0px 0px 0px;\"><p><strong>Competências a regularizar: Fevereiro/2017 a Março/2018</strong></p></div><div style=\"margin: 0px 0px 0px 0px;\"><p><strong>Instruções:</strong></p></div><div style=\"margin: 0px 20px 30px 20px; border: 1px solid black;\"><ol><li><strong>A regularização deverá ser realizada com entrega (no Portal http://yellows.gov.br) dasdeclarações faltantes;</strong></li><li>Para a regularização,<strong>   será necessário a quitação das divergências com o devido juros.</strong></li><li><strong>Após regularização, enviar cópias dos recibos ao e-mail yellows.motiva@digital.com para as devidas validações;</strong></li></ol></div><div style=\"margin: 0px 20px 0px 20px; border: 1px solid black;\"><div style=\"border-bottom: 1px solid black;\"><p style=\"text-align: left; padding-left: 15px;\"><strong>Prazo máximo para Regularização ou impugnação:</strong></p></div><div><p style=\"text-align: left; padding-left: 15px;\">@expiracao</p></div></div><div style=\"margin: 0px 225px 0px 225px;\"><p style=\"text-align: right;\"><strong>Documento lavrado em: </strong>@dataAtual</p></div></div>",
                    Name = "Auto de infração para operadores de cartões",
                    Type = NoticeType.Notice,
                    DaysToExpire = 9,
                    Module = Module.ISS,
                },
                new NoticeTemplate()
                {
                    Id = Guid.Parse("935B8D9C-0E15-4DEC-8709-3BF3A6607648"),
                    Template = "<p><img src=\"https://locomotiva.digital/imagens/horizontal_preto.svg\"></p><p class=\"ql-align-right\"><strong>Secretaria Municipal da Fazenda</strong></p><p class=\"ql-align-right\">Auditoria Fiscal Municipal</p><p class=\"ql-align-right\">Av. Antônio Carlos, 6055 • DCC • Sala 2050 • Pampulha</p><p class=\"ql-align-right\">88304-053 • Belo Horizonte • MG</p><p class=\"ql-align-right\">fone: 4002-8922</p><h1 class=\"ql-align-center\">Notificação de Inadimplência Fiscal </h1><h3 class=\"ql-align-center\"><em>Número de Controle: @numeroNotificacao</em></h3><p><strong>Contribuinte intimado</strong></p><p><strong> Nome: @nomeContribuinte </strong></p><p><strong>Endereço</strong>: @rua, @numeroEndereco @bairro/@estado - CEP: @cep</p><p><strong>Inscrição Municipal</strong>: @inscricaoMunicipal</p><p><strong>CPF/CNPJ</strong>: @cnpj</p><p>Com base na legislação federal e municipal, foram identificadas divergências no que refere-se ao pagamento dos tributos devidos ao Estado.</p><p> Nesse cenário, é necessário que a entidade jurídica busque resolver tao impecilho junto aos setores responsáveis.</p><p><strong> Competências a regularizar: Outubro/2017 a Março/2019 </strong></p><p><strong> Instruções: </strong></p><ol><li><strong> A regularização deverá ser realizada com entrega (no Portal http://locomotiva.gov.br) das declarações faltantes; </strong></li><li>Para a regularização, <strong> será necessário a quitação das divergências com o devido juros. </strong></li><li><strong>Após regularização, enviar cópias dos recibos ao e-mail loco.motiva@digital.com;</strong></li><li>A não regularização no prazo estipulado sujeitará o contribuinte à instauração de Ação Fiscal e ao lançamento, de ofício do tributo, bem como à aplicação das penalidades aplicáveis;</li><li><br></li><li>Caso o empreendimento não estivesse em funcionamento na época notificada, apresentar documentação comprobatória (ex. CNPJ) e, quando cabível, justificativas.</li><li>Caso haja discrepâncias com relação a não entrega de declarações, apresentar os protocolos/comprovantes de entrega.</li></ol><p><strong> Prazo máximo para Regularização ou impugnação: </strong></p><p>@expiracao</p><p class=\"ql-align-right\"><strong>Documento lavrado em: </strong> @dataAtual</p>",
                    Name = "Notificação para contribuintes",
                    Type = NoticeType.Warning,
                    DaysToExpire = 10,
                    Module = Module.ISS,
                }
            };


            templates.ForEach(item =>
            {
                migrationBuilder.Sql(@$"IF NOT EXISTS (SELECT * FROM NoticeTemplates 
                                                       WHERE [Name] = '{item.Name}')
                                       BEGIN
                                           INSERT INTO [dbo].[NoticeTemplates]
                                               ([Id]
                                               ,[CreatedAt]
                                               ,[LastUpdateAt]
                                               ,[Template]
                                               ,[Name]
                                               ,[Type]
                                               ,[DaysToExpire]
                                               ,[Module])
                                         VALUES
                                               ('{item.Id}'
                                               ,GETDATE()
                                               ,GETDATE()
                                               ,'{item.Template}'
                                               ,'{item.Name}'
                                               ,{(int)item.Type}
                                               ,{item.DaysToExpire}
                                               ,{(int)item.Module})
                                       END");
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

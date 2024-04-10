using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Json;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.Services.Specialize.PDF.Implementations;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using Moq;
using Xunit;

namespace Test
{
    public class NoticeServicesTest
    {
        private readonly NoticeServices _services;
        private Mock<INoticeRepository> _repository;
        private Mock<IDivergencyEntryServices> _divergencyEntryServices;
        private Mock<INoticeTemplateServices> _templateServices;
        private readonly Mock<IAttachmentServices> _attachmentsServices;
        private readonly Mock<IPDFGenerator> _pdfGeneratorServices;
        private Mock<IJuridicalPersonServices> _juridicalPersonService;
        private Mock<IAddressService> _addressServices;
        private Mock<INoticeDivergencyEntryRepository> _noticeDivergencyEntryRepository;
        private Mock<IJuridicalPersonNoticesRepository> _juridicalPersonNoticesRepository;
        private Mock<TaxpayerServices> _taxpayerServices;
        private Mock<IJuridicalPersonRepository> _juridicalPersonRepository;
        private Mock<ICardDivergencyEntryRepository> _cardDivergencyEntryRepository;
        private Mock<ITaxActionRepository> _taxActionRepository;
        private Mock<IReturnProtocolReporitory> _returnProtocolRepository;

        private Mock<EntitiesServices> _entitiesServices;
        private Mock<IEntitiesRepository> _entitiesRepository;
        private Mock<ITenantServices> _tenantServices;
        private Mock<IImageLoaderServices> _imageLoaderServices;
        private Mock<IPersonServices> _personServices;
        private Mock<MiddlewareClient> _middlewareClient;

        private Entities entity;

        private Guid _templateId;
        public NoticeServicesTest()
        {
            _repository = new Mock<INoticeRepository>();
            _divergencyEntryServices = new Mock<IDivergencyEntryServices>();
            _templateServices = new Mock<INoticeTemplateServices>();
            _noticeDivergencyEntryRepository = new Mock<INoticeDivergencyEntryRepository>();
            _juridicalPersonNoticesRepository = new Mock<IJuridicalPersonNoticesRepository>();
            _pdfGeneratorServices = new Mock<IPDFGenerator>();
            _attachmentsServices = new Mock<IAttachmentServices>();
            _juridicalPersonService = new Mock<IJuridicalPersonServices>();
            _addressServices = new Mock<IAddressService>();
            _juridicalPersonRepository = new Mock<IJuridicalPersonRepository>();
            _cardDivergencyEntryRepository = new Mock<ICardDivergencyEntryRepository>();
            _taxActionRepository = new Mock<ITaxActionRepository>();
            _returnProtocolRepository = new Mock<IReturnProtocolReporitory>();

            _entitiesRepository = new Mock<IEntitiesRepository>();
            _tenantServices = new Mock<ITenantServices>();
            _imageLoaderServices = new Mock<IImageLoaderServices>();
            _entitiesServices = new Mock<EntitiesServices>(_entitiesRepository.Object, _tenantServices.Object, _imageLoaderServices.Object);
            _personServices = new Mock<IPersonServices>();
            _middlewareClient = new Mock<MiddlewareClient>("", "");

            _services = new NoticeServices(null, 
                _repository.Object, 
                _divergencyEntryServices.Object, 
               _templateServices.Object,
                _noticeDivergencyEntryRepository.Object,
                _attachmentsServices.Object,
                _pdfGeneratorServices.Object,
                _juridicalPersonService.Object,
                _addressServices.Object,
                _juridicalPersonNoticesRepository.Object,
                null,
                _juridicalPersonRepository.Object,
                _entitiesServices.Object,
                _cardDivergencyEntryRepository.Object,
                _taxActionRepository.Object,
                _returnProtocolRepository.Object,
                _personServices.Object,
                _middlewareClient.Object);

            SetupNoticeTemplate();
            SetupDivergencyEntry();
            SetupAttachment();
            SetupJurificalPerson();
            SetupAddress();
            SetupEntity();
        }

        [Fact]
        public void Insert_Should_Call_Insert_On_Repository()
        {
            var model = new NoticeInsertUpdateViewModel()
            {
                TemplateId = _templateId,
                Aliquot = 10.0M,
                Observation = "Observção",
                DivergencyIds = new List<Guid>() { Guid.NewGuid() }
            };
            _services.Insert(model);
            _repository.Verify(r => r.Insert(It.IsAny<Notice>()), Times.Once);
        }

        [Fact]
        public void Insert_Should_Parse_Content_Name()
        {
            var model = new NoticeInsertUpdateViewModel()
            {
                TemplateId = _templateId,
                Aliquot = 10.0M,
                Observation = "Observação",
                DivergencyIds = new List<Guid>() { Guid.NewGuid() },
                DaysToExpire = 10,

            };
            _services.Insert(model);
            _repository.Verify(r => r.Insert(It.Is<Notice>(n => n.Content == $"Padaria, Observação, 10,0%, Jacaranda, {GetCurrentDateAsString()}, 123456789, {entity.Name}, {entity.Content.ISS.ResponsibleName}, {entity.Content.ISS.LegalBasisWarning}, {entity.Content.ISS.LegalBasisNotice}")), Times.Once);
        }

        [Fact]
        public void GetContent_Should_Parse_Right_Values()
        {
            var model = new NoticeInsertUpdateViewModel()
            {
                TemplateId = _templateId,
                Aliquot = 10.0M,
                Observation = "Observação",
                DivergencyIds = new List<Guid>() { Guid.NewGuid() }

            };
            var content = _services.GetContent(model);
            Assert.Equal($"Padaria, Observação, 10,0%, Jacaranda, {GetCurrentDateAsString()}, 123456789, {entity.Name}, {entity.Content.ISS.ResponsibleName}, {entity.Content.ISS.LegalBasisWarning}, {entity.Content.ISS.LegalBasisNotice}", content);
        }

        [Fact]
        public void GetPreview_Should_Return_Content()
        {
            var template = "Olá, @nomeContribuinte. Você tem uma divergência de @aliquota%. Observações: @observacao";

            string content = _services.GetPreviewContent(template);
            Assert.Equal("Olá, Padaria. Você tem uma divergência de 10%. Observações: Observação", content);

        }

        private static string GetCurrentDateAsString()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void SetupDivergencyEntry()
        {
            _divergencyEntryServices.Setup(d => d.GetByIds(It.IsAny<IEnumerable<Guid>>())).Returns(new List<DivergencyEntry>() { new DivergencyEntry(
                0,
                "123",
                "Padaria",
                new DateTime(2022, 3, 16, 12, 0, 0),
                0,
                0,
                Guid.Empty
            ) });
        }

        private void SetupJurificalPerson()
        {
            JuridicalPersonBase company = new()
            {
                MunicipalRegistration = "123456789",
                Person = new()
                {
                    Document = "123",
                    Name = "Padaria",
                    DisplayName = "Padaria",
                    Date = new DateTime(2022, 3, 16, 12, 0, 0),
                    ProfilePicUrl = "cnpj",
                    Addresses = new List<AddressPerson>()
                    {
                        new()
                        {
                            Address = new()
                            {
                                Street = "Jacaranda",
                                Number = "240",
                            }
                        }
                    }
                }
            };
            _juridicalPersonService.Setup(e => e.GetByDocument(It.IsAny<string>())).Returns(company);
        }

        private void SetupAddress()
        {
            Guid guid = Guid.NewGuid();
            AddressViewModel address = new AddressViewModel(guid, "Jacaranda", "240", "cas", "326515", AgilleApi.Domain.Enums.AddressType.Commercial, guid, guid, guid, "Padaria", null, null, null, null, null);
            _addressServices.Setup(e => e.GetAddressByOwner(It.IsAny<Guid>())).Returns(new List<AddressViewModel>() { address });
        }

        private void SetupNoticeTemplate()
        {
            Guid templateId = Guid.NewGuid();
            _templateServices.Setup(t => t.GetById(templateId)).Returns(new NoticeTemplate("@nomeContribuinte, @observacao, @aliquota%, @rua, @dataAtual, @inscricaoMunicipal, @nomeMunicipio, @responsavelMunicipio, @baseLegalAviso, @baseLegalNotificacao", "Template 1", 5) { Module = AgilleApi.Domain.Enums.Module.ISS});
            _templateId = templateId;
            return;
        }

        private void SetupAttachment()
        {
            _attachmentsServices.Setup(a => a.Insert(It.IsAny<AttachmentInsertUpdateViewModel>())).Returns(new AttachmentViewModel()
            {
                Id = Guid.NewGuid()
            });
        }

        private void SetupEntity()
        {
            entity = new Entities()
            {
                Name = "Agille - Belo Horizonte",
                Content = new()
                {
                    ISS = new ISSContent()
                    {
                        ResponsibleName = "Alfredo",
                        LegalBasisWarning = "Art. 234 -> Aviso: tamo de olho.",
                        LegalBasisNotice = "Art. 243 -> Notificação: pague R$100 e volte duas casas no tabuleiro."
                    },
                    ITR = new()
                    {
                        
                    },
                }
            };

            var entityIContentJson = new Entities()
            {
                Name = entity.Name,
                FixedContentString = entity.Content.ConvertToJson(),
                ContentString = entity.Content.ConvertToJson(),
            };

            _tenantServices.Setup(e => e.GetId()).Returns(Guid.Empty);
            _entitiesRepository.Setup(e => e.Get(It.IsAny<Guid>())).Returns(entityIContentJson);
        }
    }
}
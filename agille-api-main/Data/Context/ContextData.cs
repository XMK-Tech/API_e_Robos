using AgilleApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static AgilleApi.Domain.Entities.Verification;

namespace AgilleApi.Data.ContextDb
{
  public partial class Context
  {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfiguration(new PersonBaseMap());
      modelBuilder.ApplyConfiguration(new OperatorMap());
      modelBuilder.ApplyConfiguration(new ServerMap());
      modelBuilder.ApplyConfiguration(new PhysicalPersonBaseMap());
      modelBuilder.ApplyConfiguration(new JuridicalPersonBaseMap());
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new UserPermissionMap());
      modelBuilder.ApplyConfiguration(new AddressMap());
      modelBuilder.ApplyConfiguration(new CityMap());
      modelBuilder.ApplyConfiguration(new StateMap());
      modelBuilder.ApplyConfiguration(new CountryMap());
      modelBuilder.ApplyConfiguration(new EmailMap());
      modelBuilder.ApplyConfiguration(new PermissionMap());
      modelBuilder.ApplyConfiguration(new PermissionGroupMap());
      modelBuilder.ApplyConfiguration(new PersonAddressMap());
      modelBuilder.ApplyConfiguration(new SocialMediaMap());
      modelBuilder.ApplyConfiguration(new PhoneMap());
      modelBuilder.ApplyConfiguration(new ProfileMap());
      modelBuilder.ApplyConfiguration(new TemplateProfilePermissionsMap());
      modelBuilder.ApplyConfiguration(new DynamicFieldOptionsMap());
      modelBuilder.ApplyConfiguration(new AttachmentMap());
      modelBuilder.ApplyConfiguration(new ParamMap());
      modelBuilder.ApplyConfiguration(new EmailPersonMap());
      modelBuilder.ApplyConfiguration(new MessageMap());
      modelBuilder.ApplyConfiguration(new MessageTemplateMap());
      modelBuilder.ApplyConfiguration(new StatusMap());
      modelBuilder.ApplyConfiguration(new StatusCategoryMap());
      //Agille
      modelBuilder.ApplyConfiguration(new ImportFileMap());
      modelBuilder.ApplyConfiguration(new InvoiceEntryMap());
      modelBuilder.ApplyConfiguration(new TransactionEntryMap());
      modelBuilder.ApplyConfiguration(new DivergencyEntryMap());
      modelBuilder.ApplyConfiguration(new DataCrossingMap());
      modelBuilder.ApplyConfiguration(new NoticeTemplateMap());
      modelBuilder.ApplyConfiguration(new NoticeMap());
      modelBuilder.ApplyConfiguration(new TaxpayerMap());
      modelBuilder.ApplyConfiguration(new CompanyCardRateMap());
      modelBuilder.ApplyConfiguration(new CardDivergencyEntryMap());
      modelBuilder.ApplyConfiguration(new CardCrossingReportMap());
      modelBuilder.ApplyConfiguration(new ServiceTypeMap());
      modelBuilder.ApplyConfiguration(new ServiceTypeDescriptionMap());
      modelBuilder.ApplyConfiguration(new JuridicalPersonServiceTypeDescriptionMap());
      modelBuilder.ApplyConfiguration(new TaxActionMap());
      modelBuilder.ApplyConfiguration(new ReturnProtocolMap());
      modelBuilder.ApplyConfiguration(new NotificationMap());

      // Itr includes
      modelBuilder.ApplyConfiguration(new ProprietyMap());
      modelBuilder.ApplyConfiguration(new ProprietyAddressMap());
      modelBuilder.ApplyConfiguration(new ProprietyCharacteristicsMap());
      modelBuilder.ApplyConfiguration(new ProprietyContactMap());
      modelBuilder.ApplyConfiguration(new ProprietyOwnersMap());
      modelBuilder.ApplyConfiguration(new ProprietyAttachmentMap());
      modelBuilder.ApplyConfiguration(new TaxProcedureMap()); 
      modelBuilder.ApplyConfiguration(new TaxStageMap()); 
      modelBuilder.ApplyConfiguration(new TaxStageAttachmentMap()); 
      modelBuilder.ApplyConfiguration(new TaxParamMap()); 
      modelBuilder.ApplyConfiguration(new CoordenateMap());
      modelBuilder.ApplyConfiguration(new ProprietyCattleMap());
      modelBuilder.ApplyConfiguration(new ChecklistMap());
      modelBuilder.ApplyConfiguration(new ChecklistAttachmentMap());
      modelBuilder.ApplyConfiguration(new UnionTransfersMap());
      modelBuilder.ApplyConfiguration(new AuditMap());
      modelBuilder.ApplyConfiguration(new BareLandValueMap());
      modelBuilder.ApplyConfiguration(new TaxPayerDeclarationMap());
      modelBuilder.ApplyConfiguration(new CultureTypeMap());
      modelBuilder.ApplyConfiguration(new CultureDeclarationMap());

      // Agiprev includes
      modelBuilder.ApplyConfiguration(new RevenueMap());
      modelBuilder.ApplyConfiguration(new CollectionMap());
      modelBuilder.ApplyConfiguration(new CollectionAttachmentMap());
      modelBuilder.ApplyConfiguration(new IndexMap());
      modelBuilder.ApplyConfiguration(new RubricMap());      
      modelBuilder.ApplyConfiguration(new RubricAccountMap());
      modelBuilder.ApplyConfiguration(new ExpenseMap());
      modelBuilder.ApplyConfiguration(new ExpenseAttachmentMap());
      modelBuilder.ApplyConfiguration(new FPMLaunchMap());
      modelBuilder.ApplyConfiguration(new RelatedEntityMap());
      modelBuilder.ApplyConfiguration(new CrawlerFileMap());

      var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
      var configuration = builder.Build();
      var db = configuration["DataBase"];

      modelBuilder.Entity<DynamicFieldOptions>().HasData(
      #region User
            new DynamicFieldOptions("[[user-token]]", //Nome do dynamic field
                                        "User", //display table
                                        "Token", //display column
                                        db, //schema
                                        "User", //table
                                        "SetPasswordToken", //column
                                        "Id"), //column key
      new DynamicFieldOptions("[[confirmation-token]]",
                                        "User",
                                        "ConfirmationToken",
                                        db, //schema
                                        "User", //table
                                        "ConfirmationToken", //column
                                        "Id"), //column key
      #endregion
      #region Person
                new DynamicFieldOptions("[[person-name]]",
                                        "Pessoa",
                                        "Nome",
                                        db,
                                        "Person",
                                        "Name",
                                        "Id"),
                new DynamicFieldOptions("[[person-document]]",
                                        "Person",
                                        "Document",
                                        db,
                                        "Person",
                                        "Document",
                                        "Id"),
                new DynamicFieldOptions("[[person-display-name]]",
                                        "Person",
                                        "Nome de exibição",
                                        db,
                                        "Person",
                                        "DisplayName",
                                        "Id"),
      #endregion
      #region Others
                new DynamicFieldOptions("[[description]]",
                                        "Others",
                                        "Descrição do e-mail"),
      #endregion
      #region Attachment
                new DynamicFieldOptions("[[attachment-url]]",
                                        "Attachment",
                                        "Url",
                                        db,
                                        "Attachment",
                                        "Url",
                                        "Id"),
                new DynamicFieldOptions("[[attachment-url]]",
                                        "Attachment",
                                        "Url",
                                        db,
                                        "Attachment",
                                        "Url",
                                        "Id"),
      #endregion
      #region Phone
                new DynamicFieldOptions("[[phone-number]]",
                                        "Phone",
                                        "Number",
                                        db,
                                        "Phone",
                                        "Number",
                                        "Id")
      #endregion
      );
    }
  }
}

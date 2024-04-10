using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace AgilleApi.Data.ContextDb
{
    public partial class Context : DbContext
    {
        private readonly ContextLogger _contextLogger;

        public Context(DbContextOptions<Context> options, ContextLogger contextLogger)
        : base(options)
        {
            _contextLogger = contextLogger;
        }
        
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is Entity && (e.State == EntityState.Modified));

            foreach (EntityEntry entityEntry in entries)
                ((Entity)entityEntry.Entity).LastUpdateAt = DateTime.Now;

            CreateLogs();

            return base.SaveChanges();
        }
        
        private void CreateLogs()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is ILoggable);

            var logs = entries.Select(e => _contextLogger.CreateLog(e)).Where(e => e != null).ToList();
            if (logs.Any())
                AddRange(logs);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<TemplateProfilePermissions> Template_profile_permissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<PersonBase> Persons { get; set; }
        public DbSet<JuridicalPersonBase> JuridicalPersons { get; set; }
        public DbSet<PhysicalPersonBase> PhysicalPersons { get; set; }
        public DbSet<DynamicFieldOptions> FieldOptions { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailPerson> EmailPerson { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressPerson> AddressPerson { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<MessageQueue> Messages { get; set; }
        public DbSet<MessageTemplate> MessageTemplates { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StatusCategory> StatusCategories { get; set; }
        public DbSet<ImportFile> ImportFiles {get;set;}
        public DbSet<InvoiceEntry> InvoiceEntries { get; set; }
        public DbSet<TransactionEntry> TransactionEntries { get; set; }
        public DbSet<DivergencyEntry> DivergencyEntries { get; set; }
        public DbSet<DataCrossing> DataCrossings { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<NoticeDivergencyEntry> NoticeDivergencyEntries { get; set; }
        public DbSet<JuridicalPersonNotices> JuridicalPersonNotices { get; set; }
        public DbSet<Taxpayer> Taxpayers { get; set; }
        public DbSet<CompanyCardRate> CompanyCardRates { get; set; }
        public DbSet<CardCrossingReport> CardCrossingReports { get; set; }
        public DbSet<TaxProcedure> TaxProcedures { get; set; }
        public DbSet<CardDivergencyEntry> CardDivergencyEntries { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceTypeDescription> ServiceTypeDescriptions { get; set; }
        public DbSet<JuridicalPersonServiceTypeDescription> JuridicalPersonServiceTypeDescriptions { get; set; }
        public DbSet<TaxAction> TaxActions { get; set; }
        public DbSet<ReturnProtocol> ReturnProtocols { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Propriety> Proprieties { get; set; }
        public DbSet<ProprietyCharacteristics> ProprietyCharacteristics { get; set; }
        public DbSet<ProprietyContact> ProprietyContacts { get; set; }
        public DbSet<ProprietyAddress> ProprietyAddress { get; set; }    
        public DbSet<ProprietyOwners> ProprietyOwners { get; set; }
        public DbSet<ProprietyAttachment> ProprietyAttachments { get; set; }
        public DbSet<TaxStage> TaxStages { get; set; }
        public DbSet<TaxStageAttachment> TaxStageAttachments { get; set; }
        public DbSet<TaxParam> TaxParams { get; set; }
        public DbSet<Coordenate> Coordenates { get; set; }
        public DbSet<ProprietyCattle> ProprietyCattles { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistAttachment> ChecklistAttachments { get; set; }
        public DbSet<UnionTransfers> UnionTransfers { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<BareLandValue> BareLandValues { get; set; }
        public DbSet<TaxPayerDeclaration> TaxPayerDeclarations { get; set; }
        public DbSet<CultureType> CultureTypes { get; set; }
        public DbSet<CultureDeclaration> CultureDeclarations { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionAttachment> CollectionAttachments { get; set; }
        public DbSet<Domain.Entities.Index> Indices { get; set; }
        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<RubricAccount> RubricAccounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseAttachment> ExpenseAttachments { get; set; }
        public DbSet<FPMLaunch> FPMLaunches { get; set; }
        public DbSet<Verification> Verification { get; set; }
        public DbSet<RelatedEntity> RelatedEntities { get; set; }
        public DbSet<CrawlerFile> CrawlerFile { get; set; }
    }
}
using AgilleApi.API.Middleware;
using AgilleApi.Data.ContextDb;
using AgilleApi.Data.Repository;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.Services.Specialize.PDF.Implementations;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using GoogleApis.Services;
using GoogleApis.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Notifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ItoApi.Startup;

public class Startup
{
    //TODO: Add to configuration
    private static readonly string API_KEY_MIDDLEWARE = "2ED26FDF-32ED-4FC1-BC36-66018DBC7F40";
    private static readonly string MIDDLEWARE_API_URL = "https://agille-middleware.erikneves.com.br/api/v1";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    private static void AddScopeds(IServiceCollection services)
    {
        services.AddTransient<IGoogleServices, GoogleServices>();
        services.AddTransient<IFacebookServices, FacebookServices>();

        services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        services.AddTransient<IRazorPageRenderer, RazorPageRendererService>();
        services.AddTransient<IPDFGenerator, PDFGeneratorService>();

        services.AddRazorPages();

        services.AddScoped<Context, Context>();
        services.AddScoped<ContextLogger, ContextLogger>();
        services.AddScoped<ISessionServices, SessionServices>();
        services.AddScoped<ProfileServices, ProfileServices>();
        services.AddScoped<AddressServices, AddressServices>();
        services.AddScoped<IAddressService, AddressServices>();
        services.AddScoped<LoginService, LoginService>();
        services.AddScoped<EmailServices, EmailServices>();
        services.AddScoped<PhoneServices, PhoneServices>();
        services.AddScoped<UserServices, UserServices>();
        services.AddScoped<PermissionServices, PermissionServices>();
        services.AddScoped<SocialMediaServices, SocialMediaServices>();
        services.AddScoped<JuridicalPersonServices, JuridicalPersonServices>();
        services.AddScoped<IJuridicalPersonServices, JuridicalPersonServices>();
        services.AddScoped<PhysicalPersonServices, PhysicalPersonServices>();
        services.AddScoped<DynamicFieldsServices, DynamicFieldsServices>();
        services.AddScoped<ParamServices, ParamServices>();
        services.AddScoped<EmailNotificationService, EmailNotificationService>();
        services.AddScoped<PushNotificationService, PushNotificationService>();
        services.AddScoped<AttachmentServices, AttachmentServices>();
        services.AddScoped<IAttachmentServices, AttachmentServices>();
        services.AddScoped<TaxpayerServices, TaxpayerServices>();

        services.AddScoped<MyProfileServices, MyProfileServices>();

        services.AddScoped<MessageServices, MessageServices>();
        services.AddScoped<MessageTemplateServices, MessageTemplateServices>();
        services.AddScoped<StatusServices, StatusServices>();

        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();

        services.AddScoped<ITemplateProfilePermissionsRepository, TemplateProfilePermissionsRepository>();
        services.AddScoped<IDynamicFieldsRepository, DynamicFieldsRepository>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<IJuridicalPersonRepository, JuridicalPersonRepository>();
        services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IOperatorRepository, OperatorRepository>();
        services.AddScoped<IServerRepository, ServerRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IParamRepository, ParamRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IPermissionGroupRepository, PermissionGroupRepository>();
        services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
        services.AddScoped<IPermissionManagerServices, PermissionManagerMiddlewareServices>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IAttachmentRepository, AttachmentRepository>();

        //Agille
        services.AddScoped<IImportFileRepository, ImportFileRepository>();
        services.AddScoped<ImportFileServices, ImportFileServices>();
        services.AddScoped<ITransactionEntryRepository, TransactionEntryRepository>();
        services.AddScoped<TransactionEntryServices, TransactionEntryServices>();
        services.AddScoped<IDataCrossingRepository, DataCrossingRepository>();
        services.AddScoped<DataCrossingServices, DataCrossingServices>();
        services.AddScoped<IInvoiceEntryRepository, InvoiceEntryRepository>();
        services.AddScoped<IDivergencyEntryRepository, DivergencyEntryRepository>();
        services.AddScoped<ManualEntryServices, ManualEntryServices>();
        services.AddScoped<DivergencyEntryServices, DivergencyEntryServices>();
        services.AddScoped<IDivergencyEntryServices, DivergencyEntryServices>();
        services.AddScoped<INoticeTemplateRepository, NoticeTemplateRepository>();
        services.AddScoped<NoticeTemplateServices, NoticeTemplateServices>();
        services.AddScoped<INoticeTemplateServices, NoticeTemplateServices>();
        services.AddScoped<INoticeRepository, NoticeRepository>();
        services.AddScoped<NoticeServices, NoticeServices>();
        services.AddScoped<INoticeDivergencyEntryRepository, NoticeDivergencyEntryRepository>();
        services.AddScoped<IJuridicalPersonNoticesRepository, JuridicalPersonNoticesRepository>();
        services.AddScoped<ITaxpayerRepository, TaxpayerRepository>();
        services.AddScoped<ITenantServices, TenantServices>();
        services.AddScoped<IEntitiesRepository, EntitiesRepository>();
        services.AddScoped<ICompanyCardRateRepository, CompanyCardRateRepository>();
        services.AddScoped<CompanyCardRateServices, CompanyCardRateServices>();
        services.AddScoped<ICardCrossingServices, CardCrossingServices>();
        services.AddScoped<ICardCrossingReportRepository, CardCrossingReportRepository>();
        services.AddScoped<ICardDivergencyEntryRepository, CardDivergencyEntryRepository>();
        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
        services.AddScoped<IServiceTypeDescriptionRepository, ServiceTypeDescriptionRepository>();
        services.AddScoped<ServiceTypeServices, ServiceTypeServices>();
        services.AddScoped<IJuridicalPersonServiceTypeDescriptionRepository, JuridicalPersonServiceTypeDescriptionRepository>();
        services.AddScoped<ITaxActionRepository, TaxActionRepository>();
        services.AddScoped<IReturnProtocolReporitory, ReturnProtocolReporitory>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<NotificationServices, NotificationServices>();
        services.AddScoped<INotificationServices, NotificationServices>();
        services.AddScoped<IPersonServices, PersonServices>();
        services.AddScoped<IOperatorServices, OperatorServices>();
        services.AddScoped<IServerServices, ServerServices>();
        services.AddScoped<IAddressPersonRepository, AddressPersonRepository>();
        services.AddScoped<IPersonFinderServices, PersonFinderServices>();
        services.AddScoped<IAuditRepository, AuditRepository>();
        services.AddScoped<IAuditServices, AuditServices>();

        services.AddScoped<IGenericRepository<TransactionEntry>, TransactionEntryRepository>();
        services.AddScoped<IGenericRepository<InvoiceEntry>, InvoiceEntryRepository>();
        services.AddScoped<IImportFileReplacementServices, ImportFileReplacementServices>();
        services.AddScoped<IInvalidateDivergenciesServices, InvalidateDivergenciesServices>();

        // Generic entities content Module
        services.AddScoped<IEntitiesServices, EntitiesServices>();

        // Itr includes
        services.AddScoped<IProprietyServices, ProprietyServices>();
        services.AddScoped<IProprietyRepository, ProprietyRepository>();
        services.AddScoped<IProprietyContactRepository, ProprietyContactRepository>();
        services.AddScoped<IProprietyCharacteristicsRepository, ProprietyCharacteristicsRepository>();
        services.AddScoped<IProprietyAddressRepository, ProprietyAddressRepository>();
        services.AddScoped<IProprietyOwnerRepository, ProprietyOwnerRepository>();
        services.AddScoped<IProprietyAttachmentRepository, ProprietyAttachmentRepository>();
        services.AddScoped<ITaxProcedureServices, TaxProcedureServices>();
        services.AddScoped<ITaxProcedureRepository, TaxProcedureRepository>();
        services.AddScoped<ITaxStageServices, TaxStageServices>();
        services.AddScoped<ITaxStageRepository, TaxStageRepository>();
        services.AddScoped<ITaxStageAttachmentRepository, TaxStageAttachmentRepository>();
        services.AddScoped<ITaxParamRepository, TaxParamRepository>();
        services.AddScoped<ICoordenateRepository, CoordenateRepository>();
        services.AddScoped<ProprietyParser, ProprietyParser>();
        services.AddScoped<PersonParser, PersonParser>();
        services.AddScoped<IPersonImportServices, PersonImportServices>();
        services.AddScoped<ICourierServices, CourierServices>();
        services.AddScoped<IProprietySecondaryServices, ProprietySecondaryServices>();
        services.AddScoped<IProprietyCattleServices, ProprietyCattleServices>();
        services.AddScoped<IProprietyCattleRepository, ProprietyCattleRepository>();
        services.AddScoped<IChecklistRepository, ChecklistRepository>();
        services.AddScoped<IChecklistAttachmentRepository, ChecklistAttachmentRepository>();
        services.AddScoped<IChecklistServices, ChecklistServices>();
        services.AddScoped<IUnionTransfersRepository, UnionTransfersRepository>();
        services.AddScoped<IUnionTransfersServices, UnionTransfersServices>();
        services.AddScoped<IBareLandValueRepository, BareLandValueRepository>();
        services.AddScoped<IBareLandValueServices, BareLandValueServices>();
        services.AddScoped<ITaxPayerDeclarationRepository, TaxPayerDeclarationRepository>();
        services.AddScoped<ITaxPayerDeclarationServices, TaxPayerDeclarationServices>();
        services.AddScoped<IITRDeclarationServices, ITRDeclarationServices>();
        services.AddScoped<IImageLoaderServices, ImageLoaderServices>();
        services.AddScoped<ILogosServices, LogosServices>();
        services.AddScoped<ITaxProcessServices, TaxProcessServices>();
        services.AddScoped<IARServices, ARServices>();
        services.AddScoped<TaxPayerDeclarationParser>();
        services.AddScoped<ICultureTypeServices, CultureTypeServices>();
        services.AddScoped<ICultureTypeRepository, CultureTypeRepository>();
        services.AddScoped<ICultureDeclarationServices, CultureDeclarationServices>();
        services.AddScoped<ICultureDeclarationRepository, CultureDeclarationRepository>();
        services.AddScoped<IReportServices, ReportServices>();
        services.AddScoped<IVerificationServices, VerificationServices>();
        services.AddScoped<IVerificationCalculateServices, VerificationCalculateServices>();
        services.AddScoped<IVerificationRepository, VerificationRepository>();
                

        services.AddScoped<IRevenueRepository, RevenueRepository>();
        services.AddScoped<IRevenueServices, RevenueServices>();
        services.AddScoped<ICollectionRepository, CollectionRepository>();
        services.AddScoped<ICollectionAttachmentRepository, CollectionAttachmentRepository>();
        services.AddScoped<ICollectionServices, CollectionServices>();
        services.AddScoped<IIndexRepository, IndexRepository>();
        services.AddScoped<IIndexServices, IndexServices>();
        services.AddScoped<IRubricRepository, RubricRepository>();
        services.AddScoped<IRubricAccountRepository, RubricAccountRepository>();
        services.AddScoped<IRubricServices, RubricServices>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IExpenseAttachmentRepository, ExpenseAttachmentRepository>();
        services.AddScoped<IExpenseServices, ExpenseServices>();
        services.AddScoped<IFPMLaunchRepository, FPMLaunchRepository>();
        services.AddScoped<IFPMLaunchServices, FPMLaunchServices>();
        services.AddScoped<IRelatedEntityRepository, RelatedEntityRepository>();
        services.AddScoped<IRelatedEntityServices, RelatedEntityServices>();
        services.AddScoped<IAgiprevCalculationServices, AgiprevCalculationServices>();
        services.AddScoped<IAgiprevCalculationMonthServices, AgiprevCalculationMonthServices>();
        services.AddScoped<IAgiprevCrawlerServices, AgiprevCrawlerServices>();
        services.AddScoped<ICrawlerFileRepository, CrawlerFileRepository>();

        //Generic services
        services.AddScoped<IImportParser<TransactionEntry>, TransactionImportParserV2>();
        services.AddScoped<IImportParser<InvoiceEntry>, ManualImportParserV2>();
        services.AddScoped<ImportFileFetcher, ImportFileFetcher>();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var middlewareApi = Environment.GetEnvironmentVariable("MIDDLEWARE_API");
        services.AddHttpContextAccessor();
        services.AddScoped<MiddlewareClient, MiddlewareClient>((arg) => new MiddlewareClient(API_KEY_MIDDLEWARE, !string.IsNullOrEmpty(middlewareApi) ? middlewareApi : MIDDLEWARE_API_URL));
        services.AddScoped<IMiddlewareClient, MiddlewareClient>((arg) => new MiddlewareClient(API_KEY_MIDDLEWARE, !string.IsNullOrEmpty(middlewareApi) ? middlewareApi : MIDDLEWARE_API_URL));
        services.AddDbContext<Context>((serviceProvider, options) =>
            GetConnectionString(
                options,
                serviceProvider.GetService<IHttpContextAccessor>(),
                serviceProvider.GetService<MiddlewareClient>()));

        /*services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
        })
        .AddEntityFrameworkStores<Context>()
        .AddDefaultTokenProviders();*/

        AddScopeds(services);


        //services.Configure<ApiBehaviorOptions>(options => {
        //  options.SuppressConsumesConstraintForFormFileParameters = true;
        //  options.SuppressInferBindingSourcesForParameters = true;
        //  options.SuppressModelStateInvalidFilter = true;
        //});

        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        byte[] key = Encoding.ASCII.GetBytes(Configuration["ApiSecret"]);
        services.AddAuthentication(a =>
        {
            a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(a =>
        {
            a.RequireHttpsMetadata = false;
            a.SaveToken = true;
            a.TokenValidationParameters = new TokenValidationParameters()
            {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
            };
        });

        services.Configure<PasswordHasherOptions>(options =>
        options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
        );


        services.AddSwaggerGen(config =>
        {
        config.SwaggerDoc(
            "v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API",
            Version = "v1"
        }
            );
        });
    }

    private DbContextOptionsBuilder GetConnectionString(DbContextOptionsBuilder options, IHttpContextAccessor contextAccessor, MiddlewareClient middlewareServices)
    {
        var ctx = contextAccessor.HttpContext;
        string tenantId = ctx != null ? GetTenantId(ctx) : null;
        string connectionString = tenantId != null ?
            middlewareServices.GetConnectionStringFromMiddleware(tenantId)
            : Configuration.GetConnectionString("Context");
  
        return options.UseSqlServer(connectionString);
    }

    private static string GetTenantId(HttpContext ctx)
    {
        return ctx.Request.Headers["TenantId"];
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        CultureInfo ptBR = new CultureInfo("pt-BR");

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(ptBR),
            SupportedCultures = new List<CultureInfo> { ptBR },
            SupportedUICultures = new List<CultureInfo> { ptBR }
        });

        // Exception Middleware
        app.UseMiddleware(typeof(DomainErrorMiddleware));

        using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            using (Context context = serviceScope.ServiceProvider.GetService<Context>())
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                var systemName = configuration["SystemName"];

                List<MessageTemplate> messagesTemplates = new List<MessageTemplate>();

                messagesTemplates.AddRange(new[] {
                            new MessageTemplate(
                            "confirmation-account-email",
                            "confirmation-account-email",
                            "Email de confirma��o",
                            $"[[person-name]], agora voc� faz parte da plataforma {systemName}. Digite o c�digo de confirma��o abaixo na tela de valida��o do aplicativo para continuar. Seu c�digo de confirma��o: [[user-token]]",
                            false,
                            MessageType.Email
                        )});

                MessageTemplateSeed.Seed(context, messagesTemplates);
            }
        }

        using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            using (Context context = serviceScope.ServiceProvider.GetService<Context>())
            {

                //Utilizada para load de permiss�es padr�es de CRUD
                //groups.Add("permission (role)", "system (scope)");

                Dictionary<string, string> groups = new Dictionary<string, string>();
                groups.Add("company", "Base-System");
                groups.Add("department", "Base-System");
                groups.Add("user", "Base-System");
                groups.Add("physical-person", "Base-System");
                groups.Add("juridical-person", "Base-System");
                groups.Add("profile", "Base-System");
                groups.Add("message", "Base-system");
                groups.Add("message-template", "Base-system");

                PermissionsSeed.Seed(context, groups);

                //Utilizada para load de permiss�es customizadas de CRUD
                //string[] operationsCustomName = new string[] { "operation-custom", "operation-custom" };
                //Dictionary<string, string> groupsCustom = new Dictionary<string, string>();
                //groups.Add("permission (role)", "system (scope)");
                //PermissionsSeed.Seed(context, groupsCustom, operationsCustomName);

                PermissionsSeed.AdministratorUserSeed(context);

                // 0A30685B-319F-4A50-B2BA-766702BA488D	2021-05-10 00:00:00.000000	2021-05-11 14:25:20.664804	recovery-password	[[user-token]] informa que um bloqueio foi adicionado para o chamado. [[description]] [[person-name]	1	Assunto	0	1
            }
        }

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
        endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        });

        ApplyMigrations(app);
    }

    private static void ApplyMigrations(IApplicationBuilder app)
    {
        var env = Environment.GetEnvironmentVariable("RUN_MIGRATIONS")?.ToLower();
        var apply = env == "true" || env == "1";

        if (!apply)
            return;

        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
        scope.ServiceProvider.GetRequiredService<Context>().Database.Migrate();
    }
}
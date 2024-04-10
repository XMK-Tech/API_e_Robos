using System;
using System.ComponentModel;

namespace AgilleApi.Domain.Enums;

public enum DefaultPermissionType
{
    ManageUsers = 0,
    ManageFranchise = 1,
    ManageEntities = 2,
    ManagePermissions = 3,
}
public enum ServerCategory
{
    [Description("Null")]
    Null = 0,
    [Description("Empregado")]
    Employee = 1,
    [Description("Trabalhador avulso")]
    FreelanceWorker = 2,
    [Description("Trabalhador não vinculado ao RGPS")]
    WorkerNotLinkedToTheRGPS = 3,
    [Description("Empregado sob contrato de trabalho")]
    EmployeeUnderEmploymentContract = 4,
    [Description("Contribuinte individual")]
    IndividualTaxpayer = 5,
    [Description("Empregado doméstico")]
    Housekeeper = 6
}
public enum AgiPrevPersonType
{
    [Description("Null")]
    Null = 0,
    [Description("Operador")]
    Operator = 1,
    [Description("Server")]
    Server = 2,
}

public enum ErrorType
{
    NotFound,
    Forbidden,
    Unauthorized,
    BadRequest,
    Conflict,
    Unknow
}

public enum ImportType
{
    Transactions,
    Invoice
}

public enum ImportStatus
{
    WaitingForDownload,
    Typing,
    WaitingForValidation,
    ApprovedByValidator,
    RejectedByValidator,
    Processing,
    Done,
    DeniedForDuplicity,
    WaitingForReplacementValidation,
    ApprovedReplacement,
    Replaced
}

public enum NoticeType
{
    [Description("Notificação")]
    Notice = 0,
    [Description("Aviso")]
    Warning = 1,
    [Description("Constatação")]
    Realization = 2,
    [Description("Lançamento")]
    Launch = 3,
    [Description("Intimação")]
    Subpoena = 4,
}

public enum Module
{
    ISS = 0,
    ITR = 1,
    DTE = 2,
}

public enum NoticeBaseRate
{
    [Description("Taxa declarada pela operadora.")]
    Declared = 0,
    [Description("Taxa média calculada pelo sistema.")]
    Average = 1,
    [Description("Null")]
    Null = 2,
}

public enum NoticeStatus
{
    [Description("Emitida")]
    Issued = 0,
    [Description("Entregue no prazo")]
    DeliveredOnTime = 1,
    [Description("Entregue após o vencimento")]
    DeliveredAfterExpiration = 2,
    [Description("Respondida no prazo")]
    AnsweredOnTime = 3,
    [Description("Respondida após o prazo")]
    AnsweredAfterExpiration = 4,
    [Description("Encerrada")]
    Closed = 5,
    [Description("Encaminhada para processo Fiscal")]
    ForwardedToTaxProcess = 6,
}

public enum SignedBy
{
    [Description("Contribuinte")]
    Taxpayer = 0,
    [Description("Testemunha")]
    Witness = 1,
}

public enum ChecklistStatus
{
    [Description("Pendente")]
    Pending = 0,
    [Description("Enviado")]
    Sent = 1,
    [Description("Aprovado")]
    Approved = 2,
    [Description("Reprovado")]
    Disapproved = 3,
}

public enum ChecklistAuditorFilter
{
    [Description("Concluído")]
    Done = 1,
    [Description("Em progresso")]
    InProgress = 2,
}

public enum AuditType
{
    [Description("Default")]
    None = 0,
    [Description("Create")]
    Create = 1,
    [Description("Update")]
    Update = 2,
    [Description("Delete")]
    Delete = 3,
    [Description("Login")]
    Login = 4,
    [Description("Logout")]
    Logout = 5,
}

public enum DataCrossingStatus
{
    Pending,
    Done,
    Error,
    Processing
}

public enum TransactionType
{
    Null,
    Income = 1,
    Expense = 2
}

public enum TransactionEntryType
{
    DEBIT = 0,
    CREDIT = 1,
    UNINFORMED = 2,
}

public enum ProfileExcludeType
{
    FullExclude = 1,
    ExcludeAndMoveDataToNewProfile = 2
}

public enum DeparmentExcludeType
{
    FullExclude = 1,
    ExcludeAndMoveDataToNewDepartment = 2
}

public enum MessageStatus
{
    Null,
    NAFILA = 1,
    ENVIADA = 2,
    FALHAAOENVIAR = 3
}

public enum MessageType
{
    Null,
    Email = 1,
    PushNotification = 2
}

public enum NotificationPriority
{
    [Description("Baixa")]
    Low = 0,
    [Description("Normal")]
    Normal = 1,
    [Description("Alta")]
    High = 2,
}

public enum TaxStageType
{
    [Description("Notificação de lançamento")]
    ReleaseNotification = 0,
    [Description("Constatação de intimação")]
    NoticeWarn = 1,
    [Description("Intimação")]
    Notice = 2,
    [Description("Resposta a notificação de lançamento")]
    ReplyToReleaseNotification = 3,
    [Description("Resposta a constatação de intimação")]
    ReplyToNoticeWarn = 4,
    [Description("Resposta a intimação")]
    ReplyToNotification = 5,
}

public enum ProcessStatus
{
    [Description("Emitida")]
    Issued = 0,
    [Description("Entregue no prazo")]
    DeliveredOnTime = 1,
    [Description("Entregue após o vencimento")]
    DeliveredAfterExpiration = 2,
    [Description("Respondida no prazo")]
    AnsweredOnTime = 3,
    [Description("Respondida após o prazo")]
    AnsweredAfterExpiration = 4,
    [Description("Encerrada")]
    Closed = 5,
    [Description("Encaminhada para processo Fiscal")]
    ForwardedToTaxProcess = 6,
    [Description("Em andamento")]
    InProgress = 7,
    [Description("Cancelada")]
    Canceled = 8,
    [Description("Reposta da Intimação")]
    Response = 9
}

public enum ProcedureParamType
{
    Null = 0,
    Improvement = 1,
    EnvironmentalArea = 2,
    UsedArea = 3,
    BareLandTalue = 4
}

public enum ProcedureStatus
{
    Null = 0,
    NotStarted = 1,
    InProgress = 2,
    Finished = 3
}

public enum UnionTransfersStatus
{
    [Description("Ativa")]
    Active = 0,
    [Description("Inativa")]
    Inactive = 1,
}

public enum ContactExcludeOption
{
    Null,
    FullExclude = 1,
    ExcludeWithOutUser = 2
}

public enum PersonType
{
    [Description("Null")]
    Null = 0,
    [Description("Juridical")]
    Juridical = 1,
    [Description("Physical")]
    Physical = 2,
}

public enum AddressType
{
    Null = 0,
    Residential = 1,
    Commercial = 2,
    Others = 3
}

public enum AddressFunction
{
    Common = 0,
    Correspondence = 1,
    Alternative = 2,
}

public enum PhoneType
{
    Null = 0,
    [Description("Residencial")]
    Residential = 1,
    [Description("Comercial")]
    Commercial = 2,
    [Description("Celular")]
    Mobile = 3,
    [Description("Outro")]
    Others = 4
}

public enum Gender
{
    NotSet = 0,
    Male = 1,
    Female = 2,
    Other = 3,
}

public enum SocialMediaEnum
{
    Null = 0,
    Facebook = 1,
    Instagram = 2,
    WebSite = 3,
    Twitter = 4,
    LinkedIn = 5,
    YouTube = 6
}

public enum ProprietyType
{ // Farm derivations
    Null,
    Chacara = 1,
    Fazenda = 2,    // Farm
    Estancia = 3,
    Haras = 4,
    Fishing = 5,
    Ranch = 6,
    Sitio = 7,
    Other = 8
}

public enum SettlementType
{
    Null,
    Domain = 1,
    Possession = 2
}

public enum CultureTypeOptions
{
    [Description("Null")]
    Null = 0,
    [Description("Pisciculturas")]
    FishFarms = 1,
    [Description("Agricultura")]
    Agriculture = 2,
    [Description("Pecuária")]
    Livestock = 3
}

public enum ReportType
{
    CSV = 0,
    PDF = 1,
    XML = 2,
    XLSX = 3
}

public enum Month
{
    [Description("Null")]
    Null = 0,
    [Description("Janeiro")]
    January = 1,
    [Description("Fevereiro")]
    February = 2,
    [Description("Março")]
    March = 3,
    [Description("Abril")]
    April = 4,
    [Description("Maio")]
    May = 5,
    [Description("Junho")]
    June = 6,
    [Description("Julho")]
    July = 7,
    [Description("Agosto")]
    August = 8,
    [Description("Setembro")]
    September = 9,
    [Description("Outubro")]
    October = 10,
    [Description("Novembro")]
    November = 11,
    [Description("Dezembro")]
    December = 12
}

public enum CollectionAttachmentType
{
    [Description("Comprovante")]
    PaymentVucher = 0,
    [Description("DARF")]
    DARF = 1
}

public enum IndexType
{
    [Description("SELIC")]
    SELIC = 0,
    [Description("IPCA")]
    IPCA = 1,
}

public enum RubricAccountStatus
{
    [Description("Ativo")]
    Active = 0,
    [Description("Inativo")]
    Inactive = 1
}

public enum RubricAccountOrigin
{
    [Description("Débito")]
    Debit = 0,
    [Description("Crédito")]
    Credit = 1
}

public enum EffortType
{
    [Description("Reforço")]
    Reinforcement = 0,
    [Description("Correção")]
    Fix = 1,
}

public enum RelatedEntityType
{
    [Description("Prefeitura")]
    CityHall = 0,
    [Description("Autarquia")]
    TransitAuthority = 1,
    [Description("Fundação")]
    Foundation = 2
}

public enum ExpenseType
{
    [Description("Orçamentária")]
    Budgetary = 0,
    [Description("Extra ")]
    Extra = 1
}

public static class EnumHelper
{
    public static string GetDescription<T>(this T enumValue)
        where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            return null;

        var description = enumValue.ToString();
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

        if (fieldInfo != null)
        {
            var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                description = ((DescriptionAttribute)attrs[0]).Description;
            }
        }

        return description;
    }
}
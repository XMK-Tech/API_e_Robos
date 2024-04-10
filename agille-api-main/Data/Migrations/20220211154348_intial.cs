using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: false),
                    UrlMetadata = table.Column<string>(maxLength: 500, nullable: false),
                    ExternalId = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: false),
                    Owner = table.Column<string>(maxLength: 200, nullable: false),
                    OwnerId = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicFieldOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    DisplayTable = table.Column<string>(maxLength: 50, nullable: false),
                    DisplayColumn = table.Column<string>(maxLength: 50, nullable: false),
                    Schema = table.Column<string>(maxLength: 50, nullable: true),
                    Table = table.Column<string>(maxLength: 50, nullable: true),
                    Column = table.Column<string>(maxLength: 50, nullable: true),
                    ColumnKey = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFieldOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessagesTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    TemplateName = table.Column<string>(maxLength: 100, nullable: true),
                    Subject = table.Column<string>(maxLength: 200, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    SendCopyToMyself = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Param",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Param", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Document = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    ProfilePicUrl = table.Column<string>(maxLength: 600, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    OwnerProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Profile_OwnerProfileId",
                        column: x => x.OwnerProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<int>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    OwnerPermissionId = table.Column<Guid>(nullable: false),
                    PermissionGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Permission_OwnerPermissionId",
                        column: x => x.OwnerPermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailPerson",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailPerson", x => new { x.EmailId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_EmailPerson_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmailPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(maxLength: 600, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    EmailId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    SetPasswordToken = table.Column<string>(maxLength: 200, nullable: true),
                    CustomPermissions = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TokenPushNotifications = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Color = table.Column<string>(maxLength: 10, nullable: false),
                    StatusCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_StatusCategories_StatusCategoryId",
                        column: x => x.StatusCategoryId,
                        principalTable: "StatusCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<int>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProfilePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProfilePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateProfilePermissions_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateProfilePermissions_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    SendFrom = table.Column<string>(maxLength: 200, nullable: true),
                    SendTo = table.Column<string>(maxLength: 200, nullable: true),
                    SendCopyMyself = table.Column<string>(maxLength: 50, nullable: true),
                    SendCopyTo = table.Column<string>(maxLength: 50, nullable: true),
                    Subject = table.Column<string>(maxLength: 300, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Data = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Observation = table.Column<string>(maxLength: 250, nullable: true),
                    MessageTemplateId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_MessagesTemplates_MessageTemplateId",
                        column: x => x.MessageTemplateId,
                        principalTable: "MessagesTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.PermissionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(maxLength: 200, nullable: false),
                    Owner = table.Column<string>(maxLength: 200, nullable: true),
                    OwnerId = table.Column<string>(maxLength: 200, nullable: true),
                    Complement = table.Column<string>(maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 9, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddress", x => new { x.AddressId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAddress_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    Detail = table.Column<string>(maxLength: 200, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JuridicalPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    EstablishmentFormat = table.Column<string>(nullable: true),
                    StateRegistration = table.Column<string>(maxLength: 200, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    PhysicalPersonBaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicalPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridicalPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JuridicalPerson_PhysicalPerson_PhysicalPersonBaseId",
                        column: x => x.PhysicalPersonBaseId,
                        principalTable: "PhysicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("5c5c1392-c85a-4947-958b-e9b2e16f0ce3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 587, DateTimeKind.Local).AddTicks(3243), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("983bd49c-2d8d-4c16-a432-4c0021b79976"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2780), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cf95bc2b-2519-4090-9fcb-23ff988b198e"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2861), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2a530fcf-7ea7-4663-9875-2078478465ea"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2865), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("75982482-6f6d-4bb9-b3f9-94c883970659"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2867), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("55ecb081-7733-4827-94d9-953884e98b87"), "[[description]]", null, null, new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2869), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a3f04abd-4aef-4224-82a1-8a198bc18501"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2871), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d52e0c7d-a6e0-4675-9c76-0fd6a5dbacaf"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2873), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("587ce86b-da3e-4af2-b353-ea01f1e51d2b"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2882), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailPerson_PersonId",
                table: "EmailPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPerson_PersonId",
                table: "JuridicalPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPerson_PhysicalPersonBaseId",
                table: "JuridicalPerson",
                column: "PhysicalPersonBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTemplateId",
                table: "Messages",
                column: "MessageTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_OwnerPermissionId",
                table: "Permission",
                column: "OwnerPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroupId",
                table: "Permission",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_PersonId",
                table: "PersonAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PersonId",
                table: "Phone",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPerson_CompanyId",
                table: "PhysicalPerson",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPerson_PersonId",
                table: "PhysicalPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_OwnerProfileId",
                table: "Profile",
                column: "OwnerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_PersonId",
                table: "SocialMedia",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_StatusCategoryId",
                table: "Status",
                column: "StatusCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProfilePermissions_PermissionId",
                table: "TemplateProfilePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProfilePermissions_ProfileId",
                table: "TemplateProfilePermissions",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmailId",
                table: "User",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileId",
                table: "User",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserId",
                table: "UserPermission",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalPerson_JuridicalPerson_CompanyId",
                table: "PhysicalPerson",
                column: "CompanyId",
                principalTable: "JuridicalPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuridicalPerson_Person_PersonId",
                table: "JuridicalPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalPerson_Person_PersonId",
                table: "PhysicalPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_JuridicalPerson_PhysicalPerson_PhysicalPersonBaseId",
                table: "JuridicalPerson");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "DynamicFieldOptions");

            migrationBuilder.DropTable(
                name: "EmailPerson");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Param");

            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TemplateProfilePermissions");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "MessagesTemplates");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "StatusCategories");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PermissionGroup");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PhysicalPerson");

            migrationBuilder.DropTable(
                name: "JuridicalPerson");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ItrMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("109ac90f-884b-42b5-b967-2a7aefbaa765"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("40b37410-e7f6-4dff-948f-6e1b747fc01a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45a23180-b7d7-4252-89ee-5e7b49b96a01"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("69f6d73c-4b90-4004-8808-e24271b15d05"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("82135c9f-4856-4359-9579-30db552833e0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87da6d0d-54b2-42e4-b30b-9f07b8fb976a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9028599b-df2f-48c7-9be7-6f26ccc859cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c978a021-f1a7-4c82-9a62-903fdf494e2e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e770c720-e7ac-4334-b415-e42faf8c1b5d"));

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProprietyAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietyAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProprietyAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProprietyCharacteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasElectricity = table.Column<bool>(type: "bit", nullable: false),
                    HasPhone = table.Column<bool>(type: "bit", nullable: false),
                    HasInternet = table.Column<bool>(type: "bit", nullable: false),
                    HasNaturalWaterSpring = table.Column<bool>(type: "bit", nullable: false),
                    HasFishingPotential = table.Column<bool>(type: "bit", nullable: false),
                    HasPotentialForEcotourism = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietyCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProprietyContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneType = table.Column<int>(type: "int", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietyContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propriety",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CibNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DeclaredArea = table.Column<double>(type: "float", nullable: false),
                    IncraCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalRegistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CARNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacteristicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasSettlement = table.Column<bool>(type: "bit", nullable: false),
                    SettlementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementType = table.Column<int>(type: "int", nullable: true),
                    HasPropertyCertificate = table.Column<bool>(type: "bit", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasRegularizedLegalReserve = table.Column<bool>(type: "bit", nullable: false),
                    LegalReserveArea = table.Column<double>(type: "float", nullable: false),
                    HasSquattersInTheArea = table.Column<bool>(type: "bit", nullable: false),
                    OccupancyPercentage = table.Column<double>(type: "float", nullable: false),
                    OccupancyTime = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propriety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propriety_ProprietyAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ProprietyAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Propriety_ProprietyCharacteristics_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalTable: "ProprietyCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propriety_ProprietyContact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ProprietyContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxProcedure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntimationYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CibNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParamType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProprietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxProcedure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxProcedure_Propriety_ProprietyId",
                        column: x => x.ProprietyId,
                        principalTable: "Propriety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0f6f1909-77d5-46b9-86cc-092155e21116"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7283), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4ffb9d68-0a1c-4bc3-aea8-a26b71cb54ba"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7245), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5c67a79e-eeb3-48b7-98d0-664f352a5036"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7293), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a17b8141-ace3-4017-b44f-d3accef7a640"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7291), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c3080984-4889-4a91-a8cf-5a8a585640f6"), "[[description]]", null, null, new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7289), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("cdd5a586-491a-40b0-b3a7-2a28eadd54ea"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7294), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("e8e5335b-06c7-418e-a18b-cb8a25e3e9f4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7287), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f1b723e8-5052-4398-8b7d-31074114c5ec"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7261), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fca26b5b-bd30-4829-b8d1-501bb447fbf8"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 26, 19, 43, 51, 45, DateTimeKind.Local).AddTicks(7266), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propriety_AddressId",
                table: "Propriety",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Propriety_CharacteristicsId",
                table: "Propriety",
                column: "CharacteristicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Propriety_ContactId",
                table: "Propriety",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyAddress_AddressId",
                table: "ProprietyAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxProcedure_ProprietyId",
                table: "TaxProcedure",
                column: "ProprietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxProcedure");

            migrationBuilder.DropTable(
                name: "Propriety");

            migrationBuilder.DropTable(
                name: "ProprietyAddress");

            migrationBuilder.DropTable(
                name: "ProprietyCharacteristics");

            migrationBuilder.DropTable(
                name: "ProprietyContact");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1909-77d5-46b9-86cc-092155e21116"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ffb9d68-0a1c-4bc3-aea8-a26b71cb54ba"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5c67a79e-eeb3-48b7-98d0-664f352a5036"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a17b8141-ace3-4017-b44f-d3accef7a640"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c3080984-4889-4a91-a8cf-5a8a585640f6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cdd5a586-491a-40b0-b3a7-2a28eadd54ea"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e8e5335b-06c7-418e-a18b-cb8a25e3e9f4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f1b723e8-5052-4398-8b7d-31074114c5ec"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fca26b5b-bd30-4829-b8d1-501bb447fbf8"));

            migrationBuilder.DropColumn(
                name: "District",
                table: "Address");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("109ac90f-884b-42b5-b967-2a7aefbaa765"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4720), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("40b37410-e7f6-4dff-948f-6e1b747fc01a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4739), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("45a23180-b7d7-4252-89ee-5e7b49b96a01"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4717), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("69f6d73c-4b90-4004-8808-e24271b15d05"), "[[description]]", null, null, new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4725), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("82135c9f-4856-4359-9579-30db552833e0"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4647), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("87da6d0d-54b2-42e4-b30b-9f07b8fb976a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4735), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9028599b-df2f-48c7-9be7-6f26ccc859cc"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 103, DateTimeKind.Local).AddTicks(6202), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c978a021-f1a7-4c82-9a62-903fdf494e2e"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4723), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e770c720-e7ac-4334-b415-e42faf8c1b5d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4741), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

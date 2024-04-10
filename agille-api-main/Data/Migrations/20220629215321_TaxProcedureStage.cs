using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class TaxProcedureStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("078fe48e-d131-4818-926d-1c97d33e643a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("369bbbf6-5f29-4eda-9cd1-e3ceec1506b8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4240c5f3-9763-472a-9819-bdca3b3435d3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("62b0b154-dff3-46b6-9c7d-7cfccbb99f12"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("775609e1-4fde-4d54-aa03-afedfa8a7a68"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8a03d284-5d94-4473-8cd2-12491fc72e89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8efece32-5d46-41ca-b400-1ab1e8271084"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9a66d7e4-e005-4e6d-9b8e-91b1104405cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e23e4dfb-5eae-476e-b1c0-86f5f1bcf47e"));

            migrationBuilder.CreateTable(
                name: "TaxStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CutOffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ARCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxProcedureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxStages_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaxStages_TaxProcedure_TaxProcedureId",
                        column: x => x.TaxProcedureId,
                        principalTable: "TaxProcedure",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("00bf261b-8ec6-4cd9-9633-a32d7f9341cf"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7478), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("0b8bd282-c9ac-4163-a4f4-e996c6bae9f7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7476), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("21331873-7ed3-406d-8920-a887bbed03df"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7464), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8458ac22-b218-488c-9a24-43247b0d9e8d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7461), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b3386b44-a848-4064-8f8f-a5fd6c1099b1"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7460), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b6335b8b-3446-4d07-8d87-9159cc42833a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7474), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("bf174a1a-c389-48ae-ad95-6d3bc3ff53a3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7463), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f9689929-f683-4df8-9245-261fa82f5844"), "[[description]]", null, null, new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7465), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("faada050-983b-40b5-91f7-118ad23469dd"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7444), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxStages_AttachmentId",
                table: "TaxStages",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxStages_TaxProcedureId",
                table: "TaxStages",
                column: "TaxProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxStages");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("00bf261b-8ec6-4cd9-9633-a32d7f9341cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0b8bd282-c9ac-4163-a4f4-e996c6bae9f7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21331873-7ed3-406d-8920-a887bbed03df"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8458ac22-b218-488c-9a24-43247b0d9e8d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3386b44-a848-4064-8f8f-a5fd6c1099b1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6335b8b-3446-4d07-8d87-9159cc42833a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf174a1a-c389-48ae-ad95-6d3bc3ff53a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f9689929-f683-4df8-9245-261fa82f5844"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("faada050-983b-40b5-91f7-118ad23469dd"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("078fe48e-d131-4818-926d-1c97d33e643a"), "[[description]]", null, null, new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4995), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("369bbbf6-5f29-4eda-9cd1-e3ceec1506b8"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4985), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4240c5f3-9763-472a-9819-bdca3b3435d3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4962), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("62b0b154-dff3-46b6-9c7d-7cfccbb99f12"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4998), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("775609e1-4fde-4d54-aa03-afedfa8a7a68"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4315), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("8a03d284-5d94-4473-8cd2-12491fc72e89"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4996), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8efece32-5d46-41ca-b400-1ab1e8271084"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4299), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9a66d7e4-e005-4e6d-9b8e-91b1104405cc"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4973), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e23e4dfb-5eae-476e-b1c0-86f5f1bcf47e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4298), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

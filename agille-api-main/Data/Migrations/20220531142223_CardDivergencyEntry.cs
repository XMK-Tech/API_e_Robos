using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CardDivergencyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c8e4c61-c4a8-450e-a079-ba5b48df3f89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("22a62d11-959e-4b3a-9091-dc690d363d1d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5fa36da4-77e0-4a4e-985a-2232de4465cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("63580f10-08af-43ec-ab75-d4908bf00309"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8debddbb-a755-43b1-a140-639da0b0ff57"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c04919e6-42c7-4b64-ac34-a3f038a1b6ab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d53633de-e0f3-4b20-b515-8bd3c9414149"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e794f244-32db-43a2-af40-7d927cdbe8c5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fe5dd84f-0d13-42c4-8247-3e5962ff87ca"));

            migrationBuilder.CreateTable(
                name: "CardDivergencyEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Difference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDivergencyEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardDivergencyEntry_CardCrossingReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "CardCrossingReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3297d2dc-a4fe-4c3e-819d-a2031c5bf418"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5683), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("41c0b725-d457-4afb-bf5d-8c967618dc70"), "[[description]]", null, null, new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5694), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("52c5353d-504d-420c-809b-95058c95f132"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5684), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("67eb85d0-b017-4060-ace9-17b242cd1547"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5695), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("71d97eee-0a45-4229-9e22-567dadef72ac"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5692), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("790cf7a4-a1b6-4783-9e22-c9e0847bd255"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5686), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9dfe07c1-5bcc-49bf-a5c3-6455b778dbb2"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5672), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("abbf0962-1d81-4590-8d49-9ad44fc28138"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5698), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("db9a82fa-acf0-4e6b-baca-9c631a4d221e"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 31, 11, 22, 22, 341, DateTimeKind.Local).AddTicks(5697), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardDivergencyEntry_ReportId",
                table: "CardDivergencyEntry",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDivergencyEntry");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3297d2dc-a4fe-4c3e-819d-a2031c5bf418"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("41c0b725-d457-4afb-bf5d-8c967618dc70"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("52c5353d-504d-420c-809b-95058c95f132"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("67eb85d0-b017-4060-ace9-17b242cd1547"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("71d97eee-0a45-4229-9e22-567dadef72ac"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("790cf7a4-a1b6-4783-9e22-c9e0847bd255"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9dfe07c1-5bcc-49bf-a5c3-6455b778dbb2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("abbf0962-1d81-4590-8d49-9ad44fc28138"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db9a82fa-acf0-4e6b-baca-9c631a4d221e"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c8e4c61-c4a8-450e-a079-ba5b48df3f89"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3673), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("22a62d11-959e-4b3a-9091-dc690d363d1d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3674), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5fa36da4-77e0-4a4e-985a-2232de4465cf"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3654), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("63580f10-08af-43ec-ab75-d4908bf00309"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3658), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8debddbb-a755-43b1-a140-639da0b0ff57"), "[[description]]", null, null, new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3657), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c04919e6-42c7-4b64-ac34-a3f038a1b6ab"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3640), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d53633de-e0f3-4b20-b515-8bd3c9414149"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3655), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e794f244-32db-43a2-af40-7d927cdbe8c5"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3651), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fe5dd84f-0d13-42c4-8247-3e5962ff87ca"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3653), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

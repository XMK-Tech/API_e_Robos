using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CardDivergencyEntryII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDivergencyEntry_CardCrossingReport_ReportId",
                table: "CardDivergencyEntry");

            migrationBuilder.DropTable(
                name: "CardCrossing");

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

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOnAverageRate",
                table: "CardDivergencyEntry",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOnDeclaredRate",
                table: "CardDivergencyEntry",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRate",
                table: "CardDivergencyEntry",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeclaredRate",
                table: "CardDivergencyEntry",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorId",
                table: "CardDivergencyEntry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TransactionsCount",
                table: "CardDivergencyEntry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("19929eb6-aa4f-41fe-86a4-989ed908e036"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8055), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("2aa8b7d1-d1d3-4eb2-bd44-a5b20aa52ec8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8053), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("30653aa8-2281-4fea-85a2-1d06ddce7ea3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8049), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("33cd84c3-7008-4ea0-a783-b4159a82ef70"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8050), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("66d2a1f3-d3e7-409f-a3e5-97531541b6a3"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8058), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("6aa434d3-a2fe-4273-9eeb-be5109c4a8e6"), "[[description]]", null, null, new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8052), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a48c511c-9c51-4e0f-aed5-fa22b3b3fe2c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8048), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bb2ea101-80d9-4d58-a183-4b49dd86d57c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8035), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("eeb1d47a-18d5-4fe8-9377-4f30b9b6480f"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8046), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CardDivergencyEntry_CardCrossingReport_ReportId",
                table: "CardDivergencyEntry",
                column: "ReportId",
                principalTable: "CardCrossingReport",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDivergencyEntry_CardCrossingReport_ReportId",
                table: "CardDivergencyEntry");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("19929eb6-aa4f-41fe-86a4-989ed908e036"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b7d1-d1d3-4eb2-bd44-a5b20aa52ec8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30653aa8-2281-4fea-85a2-1d06ddce7ea3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("33cd84c3-7008-4ea0-a783-b4159a82ef70"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("66d2a1f3-d3e7-409f-a3e5-97531541b6a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6aa434d3-a2fe-4273-9eeb-be5109c4a8e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a48c511c-9c51-4e0f-aed5-fa22b3b3fe2c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bb2ea101-80d9-4d58-a183-4b49dd86d57c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("eeb1d47a-18d5-4fe8-9377-4f30b9b6480f"));

            migrationBuilder.DropColumn(
                name: "AmountOnAverageRate",
                table: "CardDivergencyEntry");

            migrationBuilder.DropColumn(
                name: "AmountOnDeclaredRate",
                table: "CardDivergencyEntry");

            migrationBuilder.DropColumn(
                name: "AverageRate",
                table: "CardDivergencyEntry");

            migrationBuilder.DropColumn(
                name: "DeclaredRate",
                table: "CardDivergencyEntry");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "CardDivergencyEntry");

            migrationBuilder.DropColumn(
                name: "TransactionsCount",
                table: "CardDivergencyEntry");

            migrationBuilder.CreateTable(
                name: "CardCrossing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountOnAverageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountOnDeclaredRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeclaredRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeclaredTransactedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCrossing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardCrossing_CardCrossingReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "CardCrossingReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardCrossing_JuridicalPerson_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_CardCrossing_OperatorId",
                table: "CardCrossing",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CardCrossing_ReportId",
                table: "CardCrossing",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDivergencyEntry_CardCrossingReport_ReportId",
                table: "CardDivergencyEntry",
                column: "ReportId",
                principalTable: "CardCrossingReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

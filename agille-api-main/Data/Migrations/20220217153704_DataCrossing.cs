using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class DataCrossing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("080c6772-8074-4e90-86ab-170dd233483d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("144ffe50-35d0-44d3-8445-2b1813a359cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2ea34356-c91f-4c6b-911a-d8acbb15b58d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ebb2fbc-65f5-44bf-b307-bbf2ae77980b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7f3f77b2-776e-4c89-975b-0b74ac5f4331"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a0dcca4a-903d-4acc-b5b2-657d19a73e10"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c085fc32-b5e2-4440-b35f-eb392889b450"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db5726f3-ac2c-4227-8dc4-b35ddfd3f409"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e130f46a-a6b2-4e48-9485-3df962c2ae37"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReferenceDate",
                table: "TransactionEntry",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MunicipalCode",
                table: "InvoiceEntry",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReferenceDate",
                table: "InvoiceEntry",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DivergencyEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    InvoiceValue = table.Column<decimal>(nullable: false),
                    TransactionValue = table.Column<decimal>(nullable: false),
                    Difference = table.Column<decimal>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ReferenceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivergencyEntry", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("a6adfd44-d991-40aa-9470-e8952abc317c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 159, DateTimeKind.Local).AddTicks(8755), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8057d53c-d625-4b9e-a0c3-bd767e4939eb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9653), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f00549c3-2160-49f5-b810-7f407467b5d2"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9749), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4c257b36-79ab-4eda-8d58-f84d7d3d4c04"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9753), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("54872ec9-6c0e-4cd0-a3d1-a34e44e01c75"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9756), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ca5d1511-c7dc-46cc-8812-26aae89d967d"), "[[description]]", null, null, new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9758), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("14f27a7f-9dee-442f-8dc5-e69d7fae1215"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9761), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("948e2fc9-2de4-49d0-a672-38405ef85e8c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9763), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("92ad0134-ac08-4f62-87aa-f924e439a3b5"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9773), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivergencyEntry");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14f27a7f-9dee-442f-8dc5-e69d7fae1215"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c257b36-79ab-4eda-8d58-f84d7d3d4c04"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("54872ec9-6c0e-4cd0-a3d1-a34e44e01c75"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8057d53c-d625-4b9e-a0c3-bd767e4939eb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("92ad0134-ac08-4f62-87aa-f924e439a3b5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("948e2fc9-2de4-49d0-a672-38405ef85e8c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a6adfd44-d991-40aa-9470-e8952abc317c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ca5d1511-c7dc-46cc-8812-26aae89d967d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f00549c3-2160-49f5-b810-7f407467b5d2"));

            migrationBuilder.DropColumn(
                name: "ReferenceDate",
                table: "TransactionEntry");

            migrationBuilder.DropColumn(
                name: "MunicipalCode",
                table: "InvoiceEntry");

            migrationBuilder.DropColumn(
                name: "ReferenceDate",
                table: "InvoiceEntry");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("7f3f77b2-776e-4c89-975b-0b74ac5f4331"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 73, DateTimeKind.Local).AddTicks(1227), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c085fc32-b5e2-4440-b35f-eb392889b450"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2467), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2ea34356-c91f-4c6b-911a-d8acbb15b58d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2564), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e130f46a-a6b2-4e48-9485-3df962c2ae37"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2568), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("db5726f3-ac2c-4227-8dc4-b35ddfd3f409"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2571), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a0dcca4a-903d-4acc-b5b2-657d19a73e10"), "[[description]]", null, null, new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2574), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("080c6772-8074-4e90-86ab-170dd233483d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2586), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4ebb2fbc-65f5-44bf-b307-bbf2ae77980b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2589), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("144ffe50-35d0-44d3-8445-2b1813a359cc"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2591), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixExpenseReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("43620abe-3c95-44c4-9903-1ddb94262c2f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a4324f4-f210-4fde-81cc-186c524645a4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b58bf93-6d5c-4860-ae93-3e557707be0a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6d1bc5f5-8a80-4350-a333-8c4d16cc47a6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7a6c246f-ba58-4a1d-b703-818e10b5d444"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a95607c2-1601-4bed-a557-599431885f8a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1476f07-bb13-4d87-9617-b0b934352777"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f71bcbc1-9e37-4723-8691-b10f8e9457d2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fed4b041-d6ad-4e25-8aa5-5e6cf5e37a46"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c3fd70e-a23d-475d-89c9-5666d18e4431"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9201), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("569276e5-2e0c-4c81-b223-1c3e6f79794b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9161), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("90bce2c0-fd7c-4b05-859f-b51f5171358c"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9202), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a1bf10c3-0f7a-41b4-a63a-7a2901dfd363"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9177), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a1c8783c-fdbe-4b5a-a81d-38962a84342d"), "[[person-name]]", "Name", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9179), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a63cc665-e280-427d-a5d8-67bfdf6a4ab5"), "[[description]]", null, null, new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9200), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d8ec8ea0-c9a0-490c-9a2a-aa972adee329"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9204), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("df9839bc-d2eb-4c30-aa00-a1d8cfe178b8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9181), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e07a0c7f-1bc6-4473-9748-20cc3b0d3cea"), "[[person-document]]", "Document", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9180), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c3fd70e-a23d-475d-89c9-5666d18e4431"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("569276e5-2e0c-4c81-b223-1c3e6f79794b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90bce2c0-fd7c-4b05-859f-b51f5171358c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a1bf10c3-0f7a-41b4-a63a-7a2901dfd363"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a1c8783c-fdbe-4b5a-a81d-38962a84342d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a63cc665-e280-427d-a5d8-67bfdf6a4ab5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d8ec8ea0-c9a0-490c-9a2a-aa972adee329"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("df9839bc-d2eb-4c30-aa00-a1d8cfe178b8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e07a0c7f-1bc6-4473-9748-20cc3b0d3cea"));

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Expenses");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("43620abe-3c95-44c4-9903-1ddb94262c2f"), "[[person-document]]", "Document", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4702), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6a4324f4-f210-4fde-81cc-186c524645a4"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4719), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6b58bf93-6d5c-4860-ae93-3e557707be0a"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4699), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6d1bc5f5-8a80-4350-a333-8c4d16cc47a6"), "[[description]]", null, null, new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4705), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("7a6c246f-ba58-4a1d-b703-818e10b5d444"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4685), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a95607c2-1601-4bed-a557-599431885f8a"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4717), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d1476f07-bb13-4d87-9617-b0b934352777"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4720), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f71bcbc1-9e37-4723-8691-b10f8e9457d2"), "[[person-name]]", "Name", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4701), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fed4b041-d6ad-4e25-8aa5-5e6cf5e37a46"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4703), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

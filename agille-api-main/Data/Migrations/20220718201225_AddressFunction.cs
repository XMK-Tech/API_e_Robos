using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddressFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e00f16a-1149-4988-90e2-ec7da8e81121"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49812518-3060-48c4-a8fa-bda30e852998"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4dbc6fa9-1ba9-422c-90b4-c9ddfee9ab96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("801a9170-36af-4d39-8595-a74d3a805685"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fc427e2-0eeb-439b-8349-d78398f1f89c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d07e281f-0826-4218-a002-83984f0386ff"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db0c01b1-0d26-422b-97af-9e7427cb85f4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddc2e04-91ee-4427-a59c-c2d8cbfc3388"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e845af8f-2a7b-4834-b7a5-e4a3ead9c882"));

            migrationBuilder.DropColumn(
                name: "IsMailingAddress",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Function",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("022919e5-3b52-4ae7-b35e-f2443e00d623"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4316), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("0938d8f1-6392-4faa-b799-3906ef2019a7"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4292), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("16827738-19ad-4292-bdc5-83f021ffd075"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4320), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("23111caa-f9d0-4886-b301-cdefab9cc372"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4311), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5687551c-695e-472b-8e40-aef2eb2e7cd4"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4314), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6de42962-15a4-4520-bf99-5eb2928665c4"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4319), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b1479363-a797-4ed3-afbb-71c395223179"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4312), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e34ad880-3b0d-4419-a020-04718681da79"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4324), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f3b9c3b7-380c-4c07-9c42-c4aa409c69e8"), "[[description]]", null, null, new DateTime(2022, 7, 18, 17, 12, 23, 773, DateTimeKind.Local).AddTicks(4317), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("022919e5-3b52-4ae7-b35e-f2443e00d623"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0938d8f1-6392-4faa-b799-3906ef2019a7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("16827738-19ad-4292-bdc5-83f021ffd075"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("23111caa-f9d0-4886-b301-cdefab9cc372"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5687551c-695e-472b-8e40-aef2eb2e7cd4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6de42962-15a4-4520-bf99-5eb2928665c4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b1479363-a797-4ed3-afbb-71c395223179"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e34ad880-3b0d-4419-a020-04718681da79"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f3b9c3b7-380c-4c07-9c42-c4aa409c69e8"));

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Address");

            migrationBuilder.AddColumn<bool>(
                name: "IsMailingAddress",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3e00f16a-1149-4988-90e2-ec7da8e81121"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(395), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("49812518-3060-48c4-a8fa-bda30e852998"), "[[description]]", null, null, new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(394), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("4dbc6fa9-1ba9-422c-90b4-c9ddfee9ab96"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(405), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("801a9170-36af-4d39-8595-a74d3a805685"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(407), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("9fc427e2-0eeb-439b-8349-d78398f1f89c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(391), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d07e281f-0826-4218-a002-83984f0386ff"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(374), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("db0c01b1-0d26-422b-97af-9e7427cb85f4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(393), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("dddc2e04-91ee-4427-a59c-c2d8cbfc3388"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(389), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e845af8f-2a7b-4834-b7a5-e4a3ead9c882"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(387), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class PersonImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56559283-6ca0-451a-bd18-591ec4e59fbf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7fbc588d-25b9-4ccc-99f8-e7388d66fc34"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87f45c48-4511-47ff-a0b4-041ea97dfb5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3afb0d5-820e-4ad2-8922-7fa985044456"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ba7545dd-e0b6-4b74-8014-f8a6d2e67061"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c9787d47-486e-429b-9801-97aae4bcfd93"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cb6f8991-5459-4f2a-860c-870a10f2991f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1e9a74b-2ffe-4122-aeb7-c0ca96eef635"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fe064e28-1cba-4dd4-8c5d-a9422bb361f0"));

            migrationBuilder.AddColumn<string>(
                name: "CibNumber",
                table: "Person",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmunityYears",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Person",
                type: "datetime2",
                nullable: true);

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
                    { new Guid("2c1df0e0-6f1b-4292-a17c-132bfa91e7e6"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2605), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("3581e975-eea2-4a61-8c19-405c111af825"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2634), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8b711da9-046b-40aa-a3e9-c2097046a3df"), "[[description]]", null, null, new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2624), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("9df7ccce-0090-4832-aff5-eb086c3b181c"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2623), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a24e763a-8780-4350-a430-35c5b6f636b7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2618), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a4c8d4e3-07c4-464f-adfd-0e0fc7dc586c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2620), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a5a868af-f6b0-43fd-8b42-3a0fbe55bc3f"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2636), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c760a0a7-b5d6-4ae4-b333-818972e373f4"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2621), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d8dc664e-c20a-44b3-a9d1-d7ad25219896"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2633), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2c1df0e0-6f1b-4292-a17c-132bfa91e7e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3581e975-eea2-4a61-8c19-405c111af825"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8b711da9-046b-40aa-a3e9-c2097046a3df"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9df7ccce-0090-4832-aff5-eb086c3b181c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a24e763a-8780-4350-a430-35c5b6f636b7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a4c8d4e3-07c4-464f-adfd-0e0fc7dc586c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a5a868af-f6b0-43fd-8b42-3a0fbe55bc3f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c760a0a7-b5d6-4ae4-b333-818972e373f4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d8dc664e-c20a-44b3-a9d1-d7ad25219896"));

            migrationBuilder.DropColumn(
                name: "CibNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ImmunityYears",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsMailingAddress",
                table: "Address");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("56559283-6ca0-451a-bd18-591ec4e59fbf"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8436), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7fbc588d-25b9-4ccc-99f8-e7388d66fc34"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8435), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("87f45c48-4511-47ff-a0b4-041ea97dfb5f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8459), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b3afb0d5-820e-4ad2-8922-7fa985044456"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8432), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ba7545dd-e0b6-4b74-8014-f8a6d2e67061"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8461), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c9787d47-486e-429b-9801-97aae4bcfd93"), "[[description]]", null, null, new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8437), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("cb6f8991-5459-4f2a-860c-870a10f2991f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8407), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d1e9a74b-2ffe-4122-aeb7-c0ca96eef635"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8462), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("fe064e28-1cba-4dd4-8c5d-a9422bb361f0"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8433), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

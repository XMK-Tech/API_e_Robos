using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class TaxStageUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1cd71fa4-ec79-4d30-877d-1e53b21822d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("480c6b19-c31e-4685-8e84-7fb9c69f10c2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7cdb2560-8013-4079-bc48-790e3e5b4660"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8c66513d-c41b-4305-8675-9ebbdf53cb16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3589bef-b0fd-4e6d-b184-6782bf70c65d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc183b83-b21c-4552-99df-89323d565a39"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c07396a6-ce62-4a3d-a31e-2df7ce13d83e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c275acdd-8d9e-4e57-b357-25f998965db5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db4164be-8254-487a-9512-b116a8ed51b0"));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "TaxStages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ARCode",
                table: "TaxStages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForwardTermUrl",
                table: "TaxStages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoiningTermUrl",
                table: "TaxStages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1712bbd4-0f4f-40f6-ad8b-55f34adcc19f"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4812), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("45bec66e-17ad-4678-8874-ebcf7d922063"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4820), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4ac980d0-fe3d-4362-927a-59fa0cd034ae"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4822), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("5a4439f4-408c-4703-9128-2bb0118677bd"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4814), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("60e0d741-0eda-4c6f-b77a-cafbe47f1579"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4816), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9f65debb-7378-488d-baf2-8fad165a8c52"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4817), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("abc54980-4852-4b4e-9f3a-3d906abba7e6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4823), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("b722de0a-0212-4c41-b299-d5f8b7b6b007"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4786), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c72591cc-3caf-4be1-a207-ca38585b2949"), "[[description]]", null, null, new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4819), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1712bbd4-0f4f-40f6-ad8b-55f34adcc19f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45bec66e-17ad-4678-8874-ebcf7d922063"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ac980d0-fe3d-4362-927a-59fa0cd034ae"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5a4439f4-408c-4703-9128-2bb0118677bd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("60e0d741-0eda-4c6f-b77a-cafbe47f1579"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9f65debb-7378-488d-baf2-8fad165a8c52"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("abc54980-4852-4b4e-9f3a-3d906abba7e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b722de0a-0212-4c41-b299-d5f8b7b6b007"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c72591cc-3caf-4be1-a207-ca38585b2949"));

            migrationBuilder.DropColumn(
                name: "ForwardTermUrl",
                table: "TaxStages");

            migrationBuilder.DropColumn(
                name: "JoiningTermUrl",
                table: "TaxStages");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "TaxStages",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ARCode",
                table: "TaxStages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1cd71fa4-ec79-4d30-877d-1e53b21822d9"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9449), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("480c6b19-c31e-4685-8e84-7fb9c69f10c2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9468), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7cdb2560-8013-4079-bc48-790e3e5b4660"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9435), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8c66513d-c41b-4305-8675-9ebbdf53cb16"), "[[description]]", null, null, new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9465), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a3589bef-b0fd-4e6d-b184-6782bf70c65d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9469), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("bc183b83-b21c-4552-99df-89323d565a39"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9467), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c07396a6-ce62-4a3d-a31e-2df7ce13d83e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9462), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c275acdd-8d9e-4e57-b357-25f998965db5"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9464), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("db4164be-8254-487a-9512-b116a8ed51b0"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9461), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

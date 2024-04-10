using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class PersonalDocumentNotMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0e4c01e4-737f-4683-a834-2924be5ca02f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c92f158-b376-4fd4-884a-728f90893117"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("96a198f4-ef57-4047-9870-f8328ae98d34"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9820f6de-5027-410b-b23b-6dba6461cb96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fb00898-baca-41a8-9cf4-552883a789b3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b0963e49-6f75-4c6c-95e1-443247ea7acc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f627f2e4-f99c-439f-8bc9-57f032bffada"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fc23e503-8395-4221-9802-f2149265e3fe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffeced63-3fab-4eaf-b449-1c81f0673f83"));

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2d206cd1-2332-4185-aa9e-71cfaed4733b"), "[[person-name]]", "Name", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2131), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("49f7425b-db87-43f8-a648-1bae1d0b8e49"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2137), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("76655464-737b-4951-97cf-e23c29f48c52"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2106), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("7f8adad8-7284-4b9a-872b-3ad0ae29418d"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2133), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8e58ed02-8379-4eb9-a760-b0267989d412"), "[[person-document]]", "Document", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2132), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bf16c135-3dac-4dbc-ae51-e4e29a8ce54a"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2136), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d26368a9-8270-4421-8e4d-3f81aedda71d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2122), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e5b20684-469b-4451-a235-70417cdf2b42"), "[[description]]", null, null, new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2135), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("fa2f4394-bb91-4fa5-8655-c4f27fa20164"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 6, 1, 17, 22, 2, 742, DateTimeKind.Local).AddTicks(2138), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2d206cd1-2332-4185-aa9e-71cfaed4733b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49f7425b-db87-43f8-a648-1bae1d0b8e49"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("76655464-737b-4951-97cf-e23c29f48c52"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7f8adad8-7284-4b9a-872b-3ad0ae29418d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e58ed02-8379-4eb9-a760-b0267989d412"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf16c135-3dac-4dbc-ae51-e4e29a8ce54a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d26368a9-8270-4421-8e4d-3f81aedda71d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e5b20684-469b-4451-a235-70417cdf2b42"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fa2f4394-bb91-4fa5-8655-c4f27fa20164"));

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0e4c01e4-737f-4683-a834-2924be5ca02f"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5721), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c92f158-b376-4fd4-884a-728f90893117"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5722), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("96a198f4-ef57-4047-9870-f8328ae98d34"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5724), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9820f6de-5027-410b-b23b-6dba6461cb96"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5742), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9fb00898-baca-41a8-9cf4-552883a789b3"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5743), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("b0963e49-6f75-4c6c-95e1-443247ea7acc"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5719), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f627f2e4-f99c-439f-8bc9-57f032bffada"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5437), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fc23e503-8395-4221-9802-f2149265e3fe"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5740), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ffeced63-3fab-4eaf-b449-1c81f0673f83"), "[[description]]", null, null, new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5725), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixRequireFirstLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PhysicalPerson",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "PhysicalPerson",
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
                    { new Guid("1b392f61-ff81-40c5-bba9-b6268c7e32e2"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9781), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2e7a0e6d-5c7d-40c7-9522-9a9ba940d9c9"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9783), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("55eac420-8f89-4fe0-bf8f-387f502f50a0"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9768), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5cf6cc4c-878e-4617-8722-126b90acc270"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9786), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("80cc198b-dab0-40e3-af64-9bb5b6732511"), "[[description]]", null, null, new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9788), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("9a8fa397-830a-4008-bc06-e73714180889"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9789), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b4dae7fe-b71c-4b89-b535-457344faabb0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9794), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("bf41f715-efa4-4a30-987c-520a7bbaddcd"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9785), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c93e5924-730a-40f4-a876-f8f3ae0facc6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 4, 16, 37, 28, 337, DateTimeKind.Local).AddTicks(9790), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1b392f61-ff81-40c5-bba9-b6268c7e32e2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2e7a0e6d-5c7d-40c7-9522-9a9ba940d9c9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55eac420-8f89-4fe0-bf8f-387f502f50a0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5cf6cc4c-878e-4617-8722-126b90acc270"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("80cc198b-dab0-40e3-af64-9bb5b6732511"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9a8fa397-830a-4008-bc06-e73714180889"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b4dae7fe-b71c-4b89-b535-457344faabb0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf41f715-efa4-4a30-987c-520a7bbaddcd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c93e5924-730a-40f4-a876-f8f3ae0facc6"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PhysicalPerson",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "PhysicalPerson",
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
        }
    }
}

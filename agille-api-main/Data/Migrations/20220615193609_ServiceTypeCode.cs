using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ServiceTypeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0df539ef-51f2-415f-98fb-17d188046f3e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0ecb9436-691d-4e9e-b999-9129f354e05b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("241cc93e-83cb-44d1-9bf8-43224389f8c3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25e9e641-b6f1-420d-8315-0deefc9d6de5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2bb67751-59e5-44e0-a292-d4a4e107708e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30763c82-ce74-4325-96db-615a7ea72670"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56d85825-43d5-4730-ad29-0c53c99b99f3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("abbcbb63-34ed-41d7-99fc-ae2999fc86e1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6803ad6-35a2-452f-bb8d-bbe0bda075dd"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ServiceTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ServiceTypeDescriptions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignedBy",
                table: "ReturnProtocols",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("314401a9-5b4c-428a-a775-3a400838320a"), "[[description]]", null, null, new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4840), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3c91338e-b302-43e2-ae6e-95f0bb7547e2"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4807), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("56b049fa-895e-4064-83f8-50ac296e8e48"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4823), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("84278a61-2838-4356-91e0-3ac1da206329"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4820), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9bac6ea6-0792-47e3-ab09-4b8ba99f1923"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4841), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d525879c-f676-43d1-8762-f738141258f7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4843), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d9451a19-9c9a-4cc8-bb0c-f4c17fe71b8d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4822), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f28f9362-0796-4cf1-99a5-937d808436d8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4844), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f9780f39-1b2c-4de3-933c-b74ef8202fe8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4825), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("314401a9-5b4c-428a-a775-3a400838320a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c91338e-b302-43e2-ae6e-95f0bb7547e2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56b049fa-895e-4064-83f8-50ac296e8e48"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("84278a61-2838-4356-91e0-3ac1da206329"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9bac6ea6-0792-47e3-ab09-4b8ba99f1923"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d525879c-f676-43d1-8762-f738141258f7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d9451a19-9c9a-4cc8-bb0c-f4c17fe71b8d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f28f9362-0796-4cf1-99a5-937d808436d8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f9780f39-1b2c-4de3-933c-b74ef8202fe8"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ServiceTypeDescriptions");

            migrationBuilder.DropColumn(
                name: "SignedBy",
                table: "ReturnProtocols");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0df539ef-51f2-415f-98fb-17d188046f3e"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1962), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("0ecb9436-691d-4e9e-b999-9129f354e05b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1915), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("241cc93e-83cb-44d1-9bf8-43224389f8c3"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1942), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("25e9e641-b6f1-420d-8315-0deefc9d6de5"), "[[description]]", null, null, new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1949), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("2bb67751-59e5-44e0-a292-d4a4e107708e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1930), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("30763c82-ce74-4325-96db-615a7ea72670"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1947), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("56d85825-43d5-4730-ad29-0c53c99b99f3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1944), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("abbcbb63-34ed-41d7-99fc-ae2999fc86e1"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1960), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b6803ad6-35a2-452f-bb8d-bbe0bda075dd"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1957), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

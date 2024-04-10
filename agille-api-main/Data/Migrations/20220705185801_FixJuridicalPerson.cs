using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixJuridicalPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4685711c-9a5b-4975-b1c2-ca96e86ec4be"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5cd52d3b-e5df-4a3d-800f-997fa54c8459"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("71d90443-c133-476d-9cfa-88a5b2f1eca8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89ad4beb-0bd0-4494-8048-cc9930f81d40"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8ba4780d-6a99-437d-831b-965eefdcc9a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8dbeab96-04fe-4728-bae5-6b541e920ada"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fc6deda-85fa-4751-8d67-298ccc9cb9da"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b06ad924-5c54-4636-ad73-3b42fb4d3173"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f53869b1-95ea-479a-9922-7eb941f98dde"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0f60407a-e6f6-4991-b19a-fc1e883bb248"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5055), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("35af78fa-b296-491f-9d64-0076f9770b85"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5052), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3e097112-4c7c-4347-affc-e23252324241"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5034), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("88c5b74b-12bd-46b8-a7df-bb064800d180"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5038), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("89db1ecc-5aca-4044-8280-73b3ad96c32e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5036), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("90ade9ea-27f9-4dc0-8154-b8eeb24fa728"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5053), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9b2819f3-f7ef-4476-8eb7-43d99b29da89"), "[[description]]", null, null, new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5039), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("9f2dc1fd-fc4e-4e49-a2be-87a56b61e084"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5021), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a8bffa3b-7697-47a3-ba07-d11db626798d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5033), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0f60407a-e6f6-4991-b19a-fc1e883bb248"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("35af78fa-b296-491f-9d64-0076f9770b85"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e097112-4c7c-4347-affc-e23252324241"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("88c5b74b-12bd-46b8-a7df-bb064800d180"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89db1ecc-5aca-4044-8280-73b3ad96c32e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90ade9ea-27f9-4dc0-8154-b8eeb24fa728"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9b2819f3-f7ef-4476-8eb7-43d99b29da89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9f2dc1fd-fc4e-4e49-a2be-87a56b61e084"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a8bffa3b-7697-47a3-ba07-d11db626798d"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("4685711c-9a5b-4975-b1c2-ca96e86ec4be"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(185), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5cd52d3b-e5df-4a3d-800f-997fa54c8459"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(149), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("71d90443-c133-476d-9cfa-88a5b2f1eca8"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(169), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("89ad4beb-0bd0-4494-8048-cc9930f81d40"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(192), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("8ba4780d-6a99-437d-831b-965eefdcc9a3"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(167), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8dbeab96-04fe-4728-bae5-6b541e920ada"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(189), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9fc6deda-85fa-4751-8d67-298ccc9cb9da"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(182), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b06ad924-5c54-4636-ad73-3b42fb4d3173"), "[[description]]", null, null, new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(187), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f53869b1-95ea-479a-9922-7eb941f98dde"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 5, 15, 54, 39, 432, DateTimeKind.Local).AddTicks(191), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

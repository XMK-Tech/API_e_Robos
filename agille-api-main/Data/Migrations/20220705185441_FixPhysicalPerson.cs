using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixPhysicalPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeTemplate_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("05b94bc6-ebb8-44b6-96ce-3d80aa398572"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1f3ba616-0b8c-479f-b6c7-5f649c829320"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6e2adaeb-ff5c-4cd3-ac33-a528cdf57149"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("91355e0c-c83a-4671-8c65-96715ab73b91"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c10e9ae5-30fc-4b32-b366-1c8b66565b0c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("daabf202-7dfc-42cb-9b70-29ee85eb4327"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed3acb88-702b-4b76-926c-e7ff388b7e02"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("effa1221-3806-496b-9140-398725db6ce3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f478a2d9-2eea-44b5-91f9-4b01f4459daa"));

            migrationBuilder.CreateTable(
                name: "NoticeTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Template = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeTemplates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("ee259f00-26f0-4264-8684-52c01f040016"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 67, DateTimeKind.Local).AddTicks(562), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("801d0244-a7a3-45aa-944d-36966b782b62"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1585), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6b11d0dc-68a7-437e-9573-5575041bdd46"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1788), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ed386730-f3fd-48b4-9cd7-910e03deddb8"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1853), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("16c78fc9-203c-4115-af73-3bb569592ba5"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1859), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7fe01e9e-7e07-4ccf-a328-768d9c4a668b"), "[[description]]", null, null, new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1864), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3bc6e1a6-d7c0-4b2d-8f3b-cd0ab93c4291"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1870), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("25a0bd73-dedc-48ae-8162-380e834e4c2a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1875), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("1a36902b-4bda-4d00-be58-3c83177b27d8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1880), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeTemplates");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("16c78fc9-203c-4115-af73-3bb569592ba5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1a36902b-4bda-4d00-be58-3c83177b27d8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25a0bd73-dedc-48ae-8162-380e834e4c2a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3bc6e1a6-d7c0-4b2d-8f3b-cd0ab93c4291"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b11d0dc-68a7-437e-9573-5575041bdd46"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7fe01e9e-7e07-4ccf-a328-768d9c4a668b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("801d0244-a7a3-45aa-944d-36966b782b62"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed386730-f3fd-48b4-9cd7-910e03deddb8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ee259f00-26f0-4264-8684-52c01f040016"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("f478a2d9-2eea-44b5-91f9-4b01f4459daa"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 336, DateTimeKind.Local).AddTicks(7362), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("effa1221-3806-496b-9140-398725db6ce3"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(754), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("daabf202-7dfc-42cb-9b70-29ee85eb4327"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(954), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6e2adaeb-ff5c-4cd3-ac33-a528cdf57149"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(964), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ed3acb88-702b-4b76-926c-e7ff388b7e02"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(970), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("91355e0c-c83a-4671-8c65-96715ab73b91"), "[[description]]", null, null, new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(976), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("1f3ba616-0b8c-479f-b6c7-5f649c829320"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(1033), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("05b94bc6-ebb8-44b6-96ce-3d80aa398572"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(1038), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c10e9ae5-30fc-4b32-b366-1c8b66565b0c"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(1045), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

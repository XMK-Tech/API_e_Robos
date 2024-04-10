using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RefactPersonObs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("18249a06-04db-48a3-924a-b44826ec03ba"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("611b08ec-1812-4c45-9e2c-fd4d0d3e1195"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7da2269e-46a3-4d73-b61a-e19656e9d4fe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("96ae6a50-c6ce-4b88-b814-ed7001c18dd4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("99b58ab2-62f7-40a0-b8cf-23c4c586a1af"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c73183ea-c98a-4c6f-abf2-d7d02531e89e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d6322739-46af-49fb-9cfd-c3e9f8f647ce"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fb9bbdc7-031a-4516-9730-10257f037f8a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fca938f3-6f35-43d3-b6b0-7a487e3168a8"));

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Person",
                newName: "LegalRepresentativeObs");

            migrationBuilder.AddColumn<string>(
                name: "InventoryObs",
                table: "Person",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("01d8fe9a-f022-4266-82f0-156cbc421dfe"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(80), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4818eab3-016a-4d3e-95de-7ae8ee0cb8ea"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(81), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6c37a256-c005-4035-8b40-c0d8cd55c61f"), "[[description]]", null, null, new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(77), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("72b16edf-45c8-42ee-af78-f4331e3da2ec"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 946, DateTimeKind.Local).AddTicks(9974), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("85a9d4d3-e95f-457e-893e-7639f1acaa2b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 946, DateTimeKind.Local).AddTicks(9991), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bc67d427-a22f-48f7-8fd4-ac476d2a5720"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 946, DateTimeKind.Local).AddTicks(9989), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c2df0f4b-c10d-4efa-9846-fa85b63f8c27"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(76), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e5cfd3c0-9bad-4314-b178-ce98f25e38c8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(82), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f787fcc2-5ee9-4a15-8a00-e7e045188d3c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(65), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("01d8fe9a-f022-4266-82f0-156cbc421dfe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4818eab3-016a-4d3e-95de-7ae8ee0cb8ea"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6c37a256-c005-4035-8b40-c0d8cd55c61f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("72b16edf-45c8-42ee-af78-f4331e3da2ec"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("85a9d4d3-e95f-457e-893e-7639f1acaa2b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc67d427-a22f-48f7-8fd4-ac476d2a5720"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c2df0f4b-c10d-4efa-9846-fa85b63f8c27"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e5cfd3c0-9bad-4314-b178-ce98f25e38c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f787fcc2-5ee9-4a15-8a00-e7e045188d3c"));

            migrationBuilder.DropColumn(
                name: "InventoryObs",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "LegalRepresentativeObs",
                table: "Person",
                newName: "Note");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("18249a06-04db-48a3-924a-b44826ec03ba"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7881), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("611b08ec-1812-4c45-9e2c-fd4d0d3e1195"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7922), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7da2269e-46a3-4d73-b61a-e19656e9d4fe"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7921), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("96ae6a50-c6ce-4b88-b814-ed7001c18dd4"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7924), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("99b58ab2-62f7-40a0-b8cf-23c4c586a1af"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7914), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c73183ea-c98a-4c6f-abf2-d7d02531e89e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7917), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d6322739-46af-49fb-9cfd-c3e9f8f647ce"), "[[description]]", null, null, new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7920), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("fb9bbdc7-031a-4516-9730-10257f037f8a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7916), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fca938f3-6f35-43d3-b6b0-7a487e3168a8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 28, 20, 47, 42, 819, DateTimeKind.Local).AddTicks(7918), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

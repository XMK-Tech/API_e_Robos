using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class TaxStageNullableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c80ee6c-8d9b-4c11-ae99-a43351fda201"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("198bd2bb-36dc-47dd-8ce8-9de94642c58b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("425f413a-747e-492f-8722-c3840aae75c9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("66bfe7ce-b124-42c3-96ab-ad8ecae8fb45"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("738aca8a-3735-4372-b0b2-99ffc4ff147b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("99acc777-c883-4b47-a552-9544ddc984e4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a7b969c2-5a8a-4639-8cc0-f7c559079990"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e6bef4bd-5330-4ed0-986d-b6ef59797b67"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f1d73817-f1b8-4d0f-be20-87560aa92b78"));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "TaxStages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TaxStages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "FineAmount",
                table: "TaxStages",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("03c601d3-5014-4ec5-ac54-2537039b2eb7"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4259), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2d017004-ba30-4ce8-abf1-5b744c5202ab"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4105), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("4878cd9b-581e-46ae-9fbb-49419b22f6f3"), "[[description]]", null, null, new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4262), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("4c0f8dad-5367-456a-9e10-5d80a504b1d2"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4275), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5bcb71d9-f7ae-41a4-b0dd-a3e087ff0eac"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4263), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("98493dfe-ae69-472f-bede-45fae76b32ee"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4161), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b56d34fb-9b41-4c16-9328-18991563e4eb"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4261), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b6d00756-25f2-4d7b-8e48-d8ae0e9fff55"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4257), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f6769e24-40a7-42f0-899e-4da5ff36a2ee"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 12, 16, 47, 36, 292, DateTimeKind.Local).AddTicks(4265), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("03c601d3-5014-4ec5-ac54-2537039b2eb7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2d017004-ba30-4ce8-abf1-5b744c5202ab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4878cd9b-581e-46ae-9fbb-49419b22f6f3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c0f8dad-5367-456a-9e10-5d80a504b1d2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5bcb71d9-f7ae-41a4-b0dd-a3e087ff0eac"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("98493dfe-ae69-472f-bede-45fae76b32ee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b56d34fb-9b41-4c16-9328-18991563e4eb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6d00756-25f2-4d7b-8e48-d8ae0e9fff55"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f6769e24-40a7-42f0-899e-4da5ff36a2ee"));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "TaxStages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TaxStages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FineAmount",
                table: "TaxStages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c80ee6c-8d9b-4c11-ae99-a43351fda201"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8752), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("198bd2bb-36dc-47dd-8ce8-9de94642c58b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8737), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("425f413a-747e-492f-8722-c3840aae75c9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8753), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("66bfe7ce-b124-42c3-96ab-ad8ecae8fb45"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8734), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("738aca8a-3735-4372-b0b2-99ffc4ff147b"), "[[description]]", null, null, new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8739), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("99acc777-c883-4b47-a552-9544ddc984e4"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8733), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a7b969c2-5a8a-4639-8cc0-f7c559079990"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8736), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e6bef4bd-5330-4ed0-986d-b6ef59797b67"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8755), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f1d73817-f1b8-4d0f-be20-87560aa92b78"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 12, 15, 0, 53, 918, DateTimeKind.Local).AddTicks(8719), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

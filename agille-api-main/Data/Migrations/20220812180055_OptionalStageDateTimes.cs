using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class OptionalStageDateTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("10b97002-ec73-4152-95b9-c0d5c7fe851f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2042f80c-b05b-416b-93da-e0e5f9c13ba5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4b902496-b1eb-4182-923b-256afdb019c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("66f8c2e0-ee45-4e81-bd79-cad8a08e1164"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("75338ca0-3367-4fed-a83b-3a78f3b1aaa5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7dd449cb-a05c-4e27-85b7-5dc040464afb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("adb9f055-fcfd-4c6e-85d7-f9c44b2a90b6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c0fc7564-4ded-42d1-877f-3e66ebbe8cbb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e9a42df9-00e4-403d-954c-d16899e7ddb1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CutOffDate",
                table: "TaxStages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CertificationDate",
                table: "TaxStages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CutOffDate",
                table: "TaxStages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CertificationDate",
                table: "TaxStages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("10b97002-ec73-4152-95b9-c0d5c7fe851f"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8143), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2042f80c-b05b-416b-93da-e0e5f9c13ba5"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8172), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4b902496-b1eb-4182-923b-256afdb019c8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8148), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("66f8c2e0-ee45-4e81-bd79-cad8a08e1164"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8147), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("75338ca0-3367-4fed-a83b-3a78f3b1aaa5"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8170), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7dd449cb-a05c-4e27-85b7-5dc040464afb"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8125), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("adb9f055-fcfd-4c6e-85d7-f9c44b2a90b6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8173), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c0fc7564-4ded-42d1-877f-3e66ebbe8cbb"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8146), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e9a42df9-00e4-403d-954c-d16899e7ddb1"), "[[description]]", null, null, new DateTime(2022, 8, 8, 19, 28, 38, 445, DateTimeKind.Local).AddTicks(8169), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }
    }
}

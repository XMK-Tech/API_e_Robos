using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class DeclarationRequiredFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("509e493e-d416-4972-8280-e723c1454056"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("51f429b6-1ab7-4ad7-b9ef-65783bef2c87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("565772fa-3ad4-44fa-b8ba-6ae27e596f1f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5d7df43a-94cb-48dc-af4c-896bf29ee6ea"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6dd283fd-a506-452d-b6b0-a5895cd801a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e80056a-8c6e-46ad-aee2-76f94903e629"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("94a75b4c-4a77-43e5-b54b-6fcd95a4214a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a13f99e7-48aa-441d-bfd2-2d39f05c7694"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f7b49139-6e35-45bb-b764-d8e8fc0c3074"));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "TaxPayerDeclarations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("21e73a58-2526-4b36-8195-a353bc7d972e"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1846), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("50a89126-5a42-4a3b-8de9-f7197f1db4dd"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1845), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("734adbf8-3af1-477f-b6e4-697c6e24cdfd"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1850), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("ab6b2ea6-8259-47ce-bb60-1ae0b64cdd1d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1836), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b1891c52-d835-4bbe-9a83-0f7bacc98df7"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1841), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c5a7a5c0-1c0b-4576-8a7c-2c15b264248e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1840), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d35094e3-2f07-406d-a303-c7ae0fe08e57"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1817), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("dac506e7-0b1b-47a7-bff0-603f7f64150f"), "[[description]]", null, null, new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1842), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("e416a0c4-a5c5-4e98-a20a-538ff4b3c045"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 23, 15, 10, 41, 490, DateTimeKind.Local).AddTicks(1838), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21e73a58-2526-4b36-8195-a353bc7d972e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("50a89126-5a42-4a3b-8de9-f7197f1db4dd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("734adbf8-3af1-477f-b6e4-697c6e24cdfd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ab6b2ea6-8259-47ce-bb60-1ae0b64cdd1d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b1891c52-d835-4bbe-9a83-0f7bacc98df7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c5a7a5c0-1c0b-4576-8a7c-2c15b264248e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d35094e3-2f07-406d-a303-c7ae0fe08e57"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dac506e7-0b1b-47a7-bff0-603f7f64150f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e416a0c4-a5c5-4e98-a20a-538ff4b3c045"));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "TaxPayerDeclarations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("509e493e-d416-4972-8280-e723c1454056"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5124), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("51f429b6-1ab7-4ad7-b9ef-65783bef2c87"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5158), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("565772fa-3ad4-44fa-b8ba-6ae27e596f1f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5155), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("5d7df43a-94cb-48dc-af4c-896bf29ee6ea"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5138), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6dd283fd-a506-452d-b6b0-a5895cd801a8"), "[[description]]", null, null, new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5144), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("8e80056a-8c6e-46ad-aee2-76f94903e629"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5141), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("94a75b4c-4a77-43e5-b54b-6fcd95a4214a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5140), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a13f99e7-48aa-441d-bfd2-2d39f05c7694"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5157), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f7b49139-6e35-45bb-b764-d8e8fc0c3074"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5143), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

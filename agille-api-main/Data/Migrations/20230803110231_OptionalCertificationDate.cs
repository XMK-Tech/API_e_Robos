using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class OptionalCertificationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2367fb8a-b7fd-4694-ba97-445ba8688bcd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("29e07ee3-ee80-40f3-ba4d-5d0d20f266ee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30a54090-40b8-4942-8665-bda5fae9fcd0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45157cae-95e5-4136-bd8e-dc8552b3db0b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("48bcdebb-846c-4591-90db-a06c87ab3c58"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("878ddd21-c371-42aa-9e4b-af39fdb5f34a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a7ae6717-fcaa-4120-8b57-0a4b19877da1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b80e6170-d5c9-43ba-81e3-6e102376184d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fae99031-b5be-4fb0-abdf-20333a29b725"));

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
                    { new Guid("526cfbb6-5df8-4277-862b-f43dc4651938"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(795), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("53157dbf-0485-47d6-aee4-62c2d2b0fec9"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(786), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("70e43e47-5f78-47f8-859b-b8f9188e6e95"), "[[person-name]]", "Name", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(778), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7ab0919a-ad0d-4aa9-b82e-20971214a4a8"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(775), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("7ab69543-6a9a-4df9-84c1-2728581d8cfd"), "[[description]]", null, null, new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(784), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("819fadd5-992d-4f40-a6d2-2bd449ca1835"), "[[person-document]]", "Document", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(780), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("94fa3c43-5b7a-4b8d-a419-64935353f29b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(748), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9c46ea2c-b513-4769-8814-e26a22a0d110"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(788), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d1d2dd1e-51c0-4e64-8de5-baeba4175c12"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(781), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("526cfbb6-5df8-4277-862b-f43dc4651938"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("53157dbf-0485-47d6-aee4-62c2d2b0fec9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e43e47-5f78-47f8-859b-b8f9188e6e95"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ab0919a-ad0d-4aa9-b82e-20971214a4a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ab69543-6a9a-4df9-84c1-2728581d8cfd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("819fadd5-992d-4f40-a6d2-2bd449ca1835"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("94fa3c43-5b7a-4b8d-a419-64935353f29b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9c46ea2c-b513-4769-8814-e26a22a0d110"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1d2dd1e-51c0-4e64-8de5-baeba4175c12"));

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
                    { new Guid("2367fb8a-b7fd-4694-ba97-445ba8688bcd"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7975), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("29e07ee3-ee80-40f3-ba4d-5d0d20f266ee"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7999), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("30a54090-40b8-4942-8665-bda5fae9fcd0"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7998), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("45157cae-95e5-4136-bd8e-dc8552b3db0b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7979), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("48bcdebb-846c-4591-90db-a06c87ab3c58"), "[[person-name]]", "Name", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7976), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("878ddd21-c371-42aa-9e4b-af39fdb5f34a"), "[[person-document]]", "Document", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7978), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a7ae6717-fcaa-4120-8b57-0a4b19877da1"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7952), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b80e6170-d5c9-43ba-81e3-6e102376184d"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7996), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("fae99031-b5be-4fb0-abdf-20333a29b725"), "[[description]]", null, null, new DateTime(2023, 8, 3, 7, 45, 31, 473, DateTimeKind.Local).AddTicks(7981), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ProprietyAreaDeclarations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("38d3559b-219c-4246-847e-e1f5baaf0a0d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e7fe08c-ace7-4e31-b5ae-04a88c0bfc13"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("556e724b-4cda-4ad5-8559-6d639f83e366"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5b00c4cc-524e-4ffe-b07e-85f730dea354"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9c57b3cb-5bd3-448c-bc85-36b3a9a668c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a4d799ce-6325-4be8-85ba-85a1476d2536"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec3fb199-f681-4c60-8e09-2c829aa0623b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fa8cd34f-be22-4ad3-9fc3-38e536c11fdc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffa40514-e117-4dcb-a6bf-e1f35466ea6f"));

            migrationBuilder.AddColumn<decimal>(
                name: "BusyWithImprovements",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LegalReserve",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PermanentPreservation",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Reforestation",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BusyWithImprovements",
                table: "Propriety");

            migrationBuilder.DropColumn(
                name: "LegalReserve",
                table: "Propriety");

            migrationBuilder.DropColumn(
                name: "PermanentPreservation",
                table: "Propriety");

            migrationBuilder.DropColumn(
                name: "Reforestation",
                table: "Propriety");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("38d3559b-219c-4246-847e-e1f5baaf0a0d"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9784), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3e7fe08c-ace7-4e31-b5ae-04a88c0bfc13"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9813), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("556e724b-4cda-4ad5-8559-6d639f83e366"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9782), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5b00c4cc-524e-4ffe-b07e-85f730dea354"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9789), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9c57b3cb-5bd3-448c-bc85-36b3a9a668c8"), "[[description]]", null, null, new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9805), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a4d799ce-6325-4be8-85ba-85a1476d2536"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9786), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ec3fb199-f681-4c60-8e09-2c829aa0623b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9766), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fa8cd34f-be22-4ad3-9fc3-38e536c11fdc"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9807), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ffa40514-e117-4dcb-a6bf-e1f35466ea6f"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9809), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

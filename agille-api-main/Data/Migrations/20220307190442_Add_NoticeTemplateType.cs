using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class Add_NoticeTemplateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("078605a7-8080-4421-8bf1-5f8f83259512"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2ebb54ca-0050-42ba-bd89-fae0b6dca11c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("437641e4-8a88-4a99-bf1b-c4a581e62ab0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9cfbf0b3-a38e-457d-b415-5e5a43d1fc11"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bee404f2-d415-44d5-b383-e780f2aacef8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c0b783b4-c113-4ca2-b5c1-b98e0a5cfa79"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c60ab035-0fc9-4e0b-824d-1546ec04584c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c95e95ce-0007-4ae9-9245-b0b2e1b76efc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fe91bdec-41bc-4c47-a5c9-c0138d6ff115"));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "NoticeTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("93cd57c7-1e4e-430a-a3cc-e2f672ecd846"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 714, DateTimeKind.Local).AddTicks(9153), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("09b4f278-383d-4af7-bac4-9091af648d19"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8168), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("356eefdd-1dd0-48ff-a0df-75ea6bbe0bda"), "[[person-name]]", "Name", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8247), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b46f2ac7-fc98-480e-9857-9e22b9d1d262"), "[[person-document]]", "Document", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8250), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f3295492-26bd-4310-bbed-b9c60299b066"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8252), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1a10ddd0-5e3b-4e3d-b6d3-4f003c9af896"), "[[description]]", null, null, new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8255), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("1101be31-2dc3-4fe0-a82c-0f631b037461"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8257), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7923a17a-cd6a-4398-ac66-2a3de50c4e3d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8265), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9f78f1a5-0b05-4ea9-91b6-677a76f0146f"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8267), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09b4f278-383d-4af7-bac4-9091af648d19"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1101be31-2dc3-4fe0-a82c-0f631b037461"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1a10ddd0-5e3b-4e3d-b6d3-4f003c9af896"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("356eefdd-1dd0-48ff-a0df-75ea6bbe0bda"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7923a17a-cd6a-4398-ac66-2a3de50c4e3d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("93cd57c7-1e4e-430a-a3cc-e2f672ecd846"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9f78f1a5-0b05-4ea9-91b6-677a76f0146f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b46f2ac7-fc98-480e-9857-9e22b9d1d262"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f3295492-26bd-4310-bbed-b9c60299b066"));

            migrationBuilder.DropColumn(
                name: "Type",
                table: "NoticeTemplates");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2ebb54ca-0050-42ba-bd89-fae0b6dca11c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 786, DateTimeKind.Local).AddTicks(762), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c60ab035-0fc9-4e0b-824d-1546ec04584c"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1013), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9cfbf0b3-a38e-457d-b415-5e5a43d1fc11"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1099), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c95e95ce-0007-4ae9-9245-b0b2e1b76efc"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1103), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("437641e4-8a88-4a99-bf1b-c4a581e62ab0"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1105), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("078605a7-8080-4421-8bf1-5f8f83259512"), "[[description]]", null, null, new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1108), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("bee404f2-d415-44d5-b383-e780f2aacef8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1110), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("fe91bdec-41bc-4c47-a5c9-c0138d6ff115"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1113), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c0b783b4-c113-4ca2-b5c1-b98e0a5cfa79"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 25, 6, 28, 5, 787, DateTimeKind.Local).AddTicks(1124), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

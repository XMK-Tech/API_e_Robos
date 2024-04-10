using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeTemplateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13dfd941-a1bd-4d9d-92ae-7ebbb892236b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("61c45116-1839-4d55-9c43-9d7cdac9d309"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("78ba2284-40f6-4002-9cfd-74bc542ae819"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("88a8ba16-c137-4212-8113-06fe33723ada"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("897a050f-818a-4c19-b41a-74de0738b269"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ad6593bc-51c9-459b-94d1-a6f1dfbfb1d5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cfd776af-06c0-48f9-9334-f87dd1a3394b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dbee62f3-e520-4694-85b5-4504a58c4b2f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ebda47ea-2db7-429e-841d-a263e89e0db4"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NoticeTemplates",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NoticeTemplates");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("897a050f-818a-4c19-b41a-74de0738b269"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 259, DateTimeKind.Local).AddTicks(3963), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("78ba2284-40f6-4002-9cfd-74bc542ae819"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3572), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("13dfd941-a1bd-4d9d-92ae-7ebbb892236b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3647), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("dbee62f3-e520-4694-85b5-4504a58c4b2f"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3651), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ad6593bc-51c9-459b-94d1-a6f1dfbfb1d5"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3653), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("88a8ba16-c137-4212-8113-06fe33723ada"), "[[description]]", null, null, new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3655), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ebda47ea-2db7-429e-841d-a263e89e0db4"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3658), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cfd776af-06c0-48f9-9334-f87dd1a3394b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3672), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("61c45116-1839-4d55-9c43-9d7cdac9d309"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3675), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

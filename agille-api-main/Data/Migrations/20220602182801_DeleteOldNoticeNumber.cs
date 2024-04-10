using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class DeleteOldNoticeNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c823c4b-338b-4c62-9eb2-3ce3f0bf46c2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1edbc52b-1069-4c2f-a971-4787fdfae71d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("40ea5a39-8712-420e-87bc-4814f5752a1e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("70fb1efd-a098-4394-8ba5-f7ffb4c79306"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("969d31a7-012b-4df8-925c-1dfc6a8b5fe0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b7d36eea-1825-46bc-bae6-421346d26023"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cfa57ff1-addb-4228-8e4a-1dccac6aa65a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d794f007-9515-41c8-9192-3441f1359897"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fd815838-dbba-4642-9ce8-76b0cc9ffd42"));

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Notices");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresIn",
                table: "NoticeTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Notices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("02191cbb-b94d-4023-bc35-388f0a9fd5d1"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(488), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("505ba0a8-b1d7-4eaa-b722-eb5e96164ae5"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(503), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("55cdd6e2-84f2-4a5c-a917-e4b89790f584"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(505), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("681abd7a-7d57-4302-be83-4e4dc5f44110"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(484), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6b134673-55db-4eed-874d-daa34b1fae59"), "[[description]]", null, null, new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(501), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6e37902f-9e47-457e-b164-c1400ce2b0e6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(511), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("8b3322cd-c485-4a6c-acd1-4cd15198870c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(486), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a6e1ba1e-38ab-4391-a37d-2f326ace659b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(471), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d2b51e60-9b3a-4c3a-9669-56abf23674f1"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 2, 15, 27, 59, 769, DateTimeKind.Local).AddTicks(490), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("02191cbb-b94d-4023-bc35-388f0a9fd5d1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("505ba0a8-b1d7-4eaa-b722-eb5e96164ae5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55cdd6e2-84f2-4a5c-a917-e4b89790f584"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("681abd7a-7d57-4302-be83-4e4dc5f44110"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b134673-55db-4eed-874d-daa34b1fae59"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6e37902f-9e47-457e-b164-c1400ce2b0e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8b3322cd-c485-4a6c-acd1-4cd15198870c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a6e1ba1e-38ab-4391-a37d-2f326ace659b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d2b51e60-9b3a-4c3a-9669-56abf23674f1"));

            migrationBuilder.DropColumn(
                name: "ExpiresIn",
                table: "NoticeTemplates");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Notices");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Notices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c823c4b-338b-4c62-9eb2-3ce3f0bf46c2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7358), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("1edbc52b-1069-4c2f-a971-4787fdfae71d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7356), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("40ea5a39-8712-420e-87bc-4814f5752a1e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7353), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("70fb1efd-a098-4394-8ba5-f7ffb4c79306"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7354), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("969d31a7-012b-4df8-925c-1dfc6a8b5fe0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7361), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("b7d36eea-1825-46bc-bae6-421346d26023"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7337), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cfa57ff1-addb-4228-8e4a-1dccac6aa65a"), "[[description]]", null, null, new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7355), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d794f007-9515-41c8-9192-3441f1359897"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7351), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fd815838-dbba-4642-9ce8-76b0cc9ffd42"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7350), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

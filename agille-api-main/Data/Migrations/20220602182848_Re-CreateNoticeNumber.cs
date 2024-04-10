using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ReCreateNoticeNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Notices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1239397d-4ef2-47ab-87cd-77df305d1236"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7597), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("1de83833-ffb3-4981-840f-7830fa2e242b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7580), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2170eee8-9276-4b20-8062-aea4510fe60c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7582), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("68320e13-a203-4f60-90ee-53d5e4fe869a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7595), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("68881c20-0682-42ef-8aa1-301a80261ad6"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7578), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6cac0b1c-88aa-4f80-8b4f-cb6acd6d834c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7558), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("7f51865f-84c8-4d85-99d1-2d7fc5826f5d"), "[[description]]", null, null, new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7591), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("8a31ca68-5354-4ef5-abe6-6f89b555ac66"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7593), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b069110e-d2f8-4771-94ab-c24d95f14088"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7583), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1239397d-4ef2-47ab-87cd-77df305d1236"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1de83833-ffb3-4981-840f-7830fa2e242b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2170eee8-9276-4b20-8062-aea4510fe60c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("68320e13-a203-4f60-90ee-53d5e4fe869a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("68881c20-0682-42ef-8aa1-301a80261ad6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6cac0b1c-88aa-4f80-8b4f-cb6acd6d834c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7f51865f-84c8-4d85-99d1-2d7fc5826f5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8a31ca68-5354-4ef5-abe6-6f89b555ac66"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b069110e-d2f8-4771-94ab-c24d95f14088"));

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Notices");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class TaxActionAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5419244e-9cd0-4e56-812f-cf4e3f50f494"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ed63e0d-f441-47c8-a784-7dcf78e0a947"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a97f390-315e-4056-baf1-16144e97bb5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7471dc47-18f1-4757-ab4b-2a6bf4da066c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3e6358f-e84c-4bab-80d5-56dea38b4567"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cf5d00c4-e332-4e15-a4a1-7362f0bb43bd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e29cfe15-014b-4e89-b9dc-3ba9d9239138"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f91b14da-6cf1-44c5-a590-3538bf121d80"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ff6e3847-4af5-40dd-8540-9b39902afa85"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId",
                table: "TaxActions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("13d0700c-9277-4e87-96f6-e18ad4e8f1a6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5486), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("334f802b-1786-4c13-a608-3d8784d1b4bc"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5474), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("489e477d-290e-4f77-8daf-43c53e306145"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5477), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4ba4a7c5-df39-4734-994f-ec0619f1fe2c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5454), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("87a61d86-6873-4244-8abd-14bd78dce6c6"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5473), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8e37107b-3a64-439b-81ae-a19ba558a7f5"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5471), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a05146ef-8cbe-400f-9dee-4dc8476c9479"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5485), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a0bb4b5f-aca0-4d4a-9fc6-5395fd8fc56b"), "[[description]]", null, null, new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5476), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("aace6f25-2507-4cb3-b20f-38131520ea7d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5470), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxActions_AttachmentId",
                table: "TaxActions",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxActions_Attachment_AttachmentId",
                table: "TaxActions",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxActions_Attachment_AttachmentId",
                table: "TaxActions");

            migrationBuilder.DropIndex(
                name: "IX_TaxActions_AttachmentId",
                table: "TaxActions");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13d0700c-9277-4e87-96f6-e18ad4e8f1a6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("334f802b-1786-4c13-a608-3d8784d1b4bc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("489e477d-290e-4f77-8daf-43c53e306145"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ba4a7c5-df39-4734-994f-ec0619f1fe2c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87a61d86-6873-4244-8abd-14bd78dce6c6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e37107b-3a64-439b-81ae-a19ba558a7f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a05146ef-8cbe-400f-9dee-4dc8476c9479"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a0bb4b5f-aca0-4d4a-9fc6-5395fd8fc56b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aace6f25-2507-4cb3-b20f-38131520ea7d"));

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "TaxActions");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("5419244e-9cd0-4e56-812f-cf4e3f50f494"), "[[description]]", null, null, new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8312), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("5ed63e0d-f441-47c8-a784-7dcf78e0a947"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8307), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6a97f390-315e-4056-baf1-16144e97bb5f"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8310), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7471dc47-18f1-4757-ab4b-2a6bf4da066c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8325), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b3e6358f-e84c-4bab-80d5-56dea38b4567"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8309), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cf5d00c4-e332-4e15-a4a1-7362f0bb43bd"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8327), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e29cfe15-014b-4e89-b9dc-3ba9d9239138"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8306), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f91b14da-6cf1-44c5-a590-3538bf121d80"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8328), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("ff6e3847-4af5-40dd-8540-9b39902afa85"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 26, 10, 12, 51, 645, DateTimeKind.Local).AddTicks(8289), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

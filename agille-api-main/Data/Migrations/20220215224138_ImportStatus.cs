using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class ImportStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportFile_Attachment_AttachmentId1",
                table: "ImportFile");

            migrationBuilder.DropIndex(
                name: "IX_ImportFile_AttachmentId1",
                table: "ImportFile");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("430a1a14-17b6-4ee3-a111-222d20d8fe2f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("70ef6162-6375-4ede-87e3-c752f83eb3de"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("84622185-ee74-4fe2-bc1b-15bae72e7ebe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a5c5b37d-9006-4de9-a290-70a4013d06d6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a6f29505-803c-46c9-8447-a6e3420853c2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3387bd8-6850-467e-978e-370d9ec26b9c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b8448b49-7522-4038-ae2e-b269767dbfb9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bfe8cfff-0dd8-4271-b55e-9ddc53422824"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c69c3fa2-354e-4077-b8d5-4db103dc35a7"));

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "ImportFile");

            migrationBuilder.AddColumn<Guid>(
                name: "ManualFileId",
                table: "ImportFile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ImportFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("f75e6411-b607-42b5-b345-7cef78244597"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 449, DateTimeKind.Local).AddTicks(8531), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ac365b92-e385-4d8a-84e2-cc1c8525d253"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8109), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6a879de8-da85-4365-81d0-f1567433c1a3"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8186), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3e72006-aa1b-4608-8d66-0abc09815b3b"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8191), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("0c4dd5e9-b343-49cb-9791-39e009a0aeb2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8193), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9876109f-049f-47b4-8d27-1af13ab87680"), "[[description]]", null, null, new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8195), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("257cbbab-b361-41d3-a924-53c62196b157"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8198), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("11493562-ad09-4caa-8558-9ab40658e10d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8209), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a9bf1842-483d-45b1-8f8e-4eec4019a158"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8212), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportFile_ManualFileId",
                table: "ImportFile",
                column: "ManualFileId",
                unique: true,
                filter: "[ManualFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportFile_Attachment_ManualFileId",
                table: "ImportFile",
                column: "ManualFileId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportFile_Attachment_ManualFileId",
                table: "ImportFile");

            migrationBuilder.DropIndex(
                name: "IX_ImportFile_ManualFileId",
                table: "ImportFile");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c4dd5e9-b343-49cb-9791-39e009a0aeb2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("11493562-ad09-4caa-8558-9ab40658e10d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("257cbbab-b361-41d3-a924-53c62196b157"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a879de8-da85-4365-81d0-f1567433c1a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9876109f-049f-47b4-8d27-1af13ab87680"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3e72006-aa1b-4608-8d66-0abc09815b3b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a9bf1842-483d-45b1-8f8e-4eec4019a158"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ac365b92-e385-4d8a-84e2-cc1c8525d253"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f75e6411-b607-42b5-b345-7cef78244597"));

            migrationBuilder.DropColumn(
                name: "ManualFileId",
                table: "ImportFile");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ImportFile");

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId1",
                table: "ImportFile",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("bfe8cfff-0dd8-4271-b55e-9ddc53422824"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 11, DateTimeKind.Local).AddTicks(4228), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c69c3fa2-354e-4077-b8d5-4db103dc35a7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7140), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("430a1a14-17b6-4ee3-a111-222d20d8fe2f"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7704), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b3387bd8-6850-467e-978e-370d9ec26b9c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7713), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a5c5b37d-9006-4de9-a290-70a4013d06d6"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7800), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a6f29505-803c-46c9-8447-a6e3420853c2"), "[[description]]", null, null, new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7810), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b8448b49-7522-4038-ae2e-b269767dbfb9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7814), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("70ef6162-6375-4ede-87e3-c752f83eb3de"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7823), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("84622185-ee74-4fe2-bc1b-15bae72e7ebe"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 15, 14, 25, 33, 14, DateTimeKind.Local).AddTicks(7838), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportFile_AttachmentId1",
                table: "ImportFile",
                column: "AttachmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportFile_Attachment_AttachmentId1",
                table: "ImportFile",
                column: "AttachmentId1",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class ImportAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1ab2c2e1-c36a-48a9-b230-cd59beef4499"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2466ff73-3a20-4c4b-8ddf-9c34056e36d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56ef9b24-7014-48b0-a968-52a30edf7cbe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5decad9d-46c9-4e94-8868-535d19ba2d48"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("674bd4e6-2749-4228-b35a-cf00b94f1e5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("73143919-221d-40e4-b527-1ce124cbacdb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a70b95f1-d980-4fe3-bfe9-e066aec30658"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e1503c94-e890-4e62-9338-2ada98c932bb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f9aaa349-cf39-449a-9835-cbfba24edd43"));

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "ImportFile");

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId",
                table: "ImportFile",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId1",
                table: "ImportFile",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    ImportFileId = table.Column<Guid>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceEntry_ImportFile_ImportFileId",
                        column: x => x.ImportFileId,
                        principalTable: "ImportFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    ImportFileId = table.Column<Guid>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionEntry_ImportFile_ImportFileId",
                        column: x => x.ImportFileId,
                        principalTable: "ImportFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ImportFile_AttachmentId",
                table: "ImportFile",
                column: "AttachmentId",
                unique: true,
                filter: "[AttachmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImportFile_AttachmentId1",
                table: "ImportFile",
                column: "AttachmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceEntry_ImportFileId",
                table: "InvoiceEntry",
                column: "ImportFileId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntry_ImportFileId",
                table: "TransactionEntry",
                column: "ImportFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportFile_Attachment_AttachmentId",
                table: "ImportFile",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportFile_Attachment_AttachmentId1",
                table: "ImportFile",
                column: "AttachmentId1",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportFile_Attachment_AttachmentId",
                table: "ImportFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportFile_Attachment_AttachmentId1",
                table: "ImportFile");

            migrationBuilder.DropTable(
                name: "InvoiceEntry");

            migrationBuilder.DropTable(
                name: "TransactionEntry");

            migrationBuilder.DropIndex(
                name: "IX_ImportFile_AttachmentId",
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
                name: "AttachmentId",
                table: "ImportFile");

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "ImportFile");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "ImportFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("73143919-221d-40e4-b527-1ce124cbacdb"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 658, DateTimeKind.Local).AddTicks(8015), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e1503c94-e890-4e62-9338-2ada98c932bb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8149), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1ab2c2e1-c36a-48a9-b230-cd59beef4499"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8245), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5decad9d-46c9-4e94-8868-535d19ba2d48"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8249), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a70b95f1-d980-4fe3-bfe9-e066aec30658"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8251), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f9aaa349-cf39-449a-9835-cbfba24edd43"), "[[description]]", null, null, new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8255), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("2466ff73-3a20-4c4b-8ddf-9c34056e36d9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8257), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("56ef9b24-7014-48b0-a968-52a30edf7cbe"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8278), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("674bd4e6-2749-4228-b35a-cf00b94f1e5d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8280), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

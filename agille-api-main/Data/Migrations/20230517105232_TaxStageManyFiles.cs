using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class TaxStageManyFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("08257c12-0dd2-4a49-848f-84f267aa9ddd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("120c7eb6-b67c-4778-a2da-7a547719e5a9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4713d68d-e174-421a-9b30-8076aa94d661"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8edc339b-3e27-4e93-8f8b-4817bca5b170"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aedbe384-0001-49de-aabc-fc28af8a7381"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c0f9af12-35fa-4f1a-9d2a-44b789c925ad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c25d0834-4d1a-434a-8271-1155c95c9090"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c67c3d7b-82b0-4e1f-996d-c95d2c05eec2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c9ddf02b-47cb-45b3-b65d-f537db146266"));

            migrationBuilder.CreateTable(
                name: "TaxStageAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxStageAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxStageAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaxStageAttachments_TaxStages_TaxStageId",
                        column: x => x.TaxStageId,
                        principalTable: "TaxStages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0a9cc927-aa35-485d-a014-bf59dc863332"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(298), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("739caf5e-f0f8-41fc-9dd5-edb8edb5dd53"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(281), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("773c05a8-73bd-47d6-b85b-eb211cfd10e1"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(284), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8bbceed1-a30c-4e67-b174-dab63a4a782d"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(283), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8bc5a2e0-e620-4204-a3f7-05ac3346db7b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(286), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b3437bcb-bc15-46ef-a140-3ed2d6fec56f"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(296), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cdb157bb-f1c6-4d3e-b012-b66f72d4e921"), "[[description]]", null, null, new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(295), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d1728202-1ef6-43a3-8869-4d43f7097c16"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(299), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("e634c2d5-4850-4ee7-9c81-fb4581c16911"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 17, 7, 52, 28, 940, DateTimeKind.Local).AddTicks(263), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxStageAttachments_AttachmentId",
                table: "TaxStageAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxStageAttachments_TaxStageId",
                table: "TaxStageAttachments",
                column: "TaxStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxStageAttachments");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0a9cc927-aa35-485d-a014-bf59dc863332"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("739caf5e-f0f8-41fc-9dd5-edb8edb5dd53"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("773c05a8-73bd-47d6-b85b-eb211cfd10e1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8bbceed1-a30c-4e67-b174-dab63a4a782d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8bc5a2e0-e620-4204-a3f7-05ac3346db7b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3437bcb-bc15-46ef-a140-3ed2d6fec56f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cdb157bb-f1c6-4d3e-b012-b66f72d4e921"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1728202-1ef6-43a3-8869-4d43f7097c16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e634c2d5-4850-4ee7-9c81-fb4581c16911"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("08257c12-0dd2-4a49-848f-84f267aa9ddd"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1275), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("120c7eb6-b67c-4778-a2da-7a547719e5a9"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1292), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4713d68d-e174-421a-9b30-8076aa94d661"), "[[person-document]]", "Document", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1291), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8edc339b-3e27-4e93-8f8b-4817bca5b170"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1297), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("aedbe384-0001-49de-aabc-fc28af8a7381"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1288), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c0f9af12-35fa-4f1a-9d2a-44b789c925ad"), "[[person-name]]", "Name", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1290), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c25d0834-4d1a-434a-8271-1155c95c9090"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1300), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c67c3d7b-82b0-4e1f-996d-c95d2c05eec2"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1295), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c9ddf02b-47cb-45b3-b65d-f537db146266"), "[[description]]", null, null, new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1294), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }
    }
}

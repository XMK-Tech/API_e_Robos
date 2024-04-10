using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ProprietyAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21e1fbc8-c128-4f6b-8e85-8f28e46a3855"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5cacf641-2646-476b-938a-21562f669e54"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("67319725-24e9-4804-b92c-1bfefcf6f364"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("83fabf4b-448e-4e47-bbcb-94d71d9e5725"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("926c1268-862c-4ca5-9c27-556d6500556c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e19248b3-64cc-4418-89e9-4b9f26eabd91"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f03e4229-42d3-4bb8-aa70-86a642a6bd16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f2e9322b-51d0-4760-8604-7d138ad53b6c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f8b66820-1ce0-4bba-9b2c-cd293f30c6c9"));

            migrationBuilder.CreateTable(
                name: "ProprietyAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProprietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProprietyId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietyAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProprietyAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProprietyAttachments_Propriety_ProprietyId",
                        column: x => x.ProprietyId,
                        principalTable: "Propriety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProprietyAttachments_Propriety_ProprietyId1",
                        column: x => x.ProprietyId1,
                        principalTable: "Propriety",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("17eef040-18ea-4480-88eb-989337a51a7f"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8708), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2391d9ad-6f46-4f36-99ee-89e44e30e4a1"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8702), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5ecfebd3-f85a-488b-a580-6d58d46f20d5"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8710), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6071e67c-8f6a-423a-bd71-e05c97861465"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8706), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8ae7d947-5900-451c-afce-9d2267136efb"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8715), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c57a8b10-9b5e-488d-b467-03a6f242ada3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8688), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cfa2c322-2eef-48ad-ae5c-ad70c6261dfc"), "[[description]]", null, null, new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8709), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("dd6efa41-5211-47b3-a9b3-0686244eed64"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8712), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("fec614e2-6f01-419d-b70e-61c7a1aadc88"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 25, 16, 27, 26, 329, DateTimeKind.Local).AddTicks(8705), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyAttachments_AttachmentId",
                table: "ProprietyAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyAttachments_ProprietyId",
                table: "ProprietyAttachments",
                column: "ProprietyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyAttachments_ProprietyId1",
                table: "ProprietyAttachments",
                column: "ProprietyId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProprietyAttachments");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("17eef040-18ea-4480-88eb-989337a51a7f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2391d9ad-6f46-4f36-99ee-89e44e30e4a1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ecfebd3-f85a-488b-a580-6d58d46f20d5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6071e67c-8f6a-423a-bd71-e05c97861465"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8ae7d947-5900-451c-afce-9d2267136efb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c57a8b10-9b5e-488d-b467-03a6f242ada3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cfa2c322-2eef-48ad-ae5c-ad70c6261dfc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dd6efa41-5211-47b3-a9b3-0686244eed64"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fec614e2-6f01-419d-b70e-61c7a1aadc88"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("21e1fbc8-c128-4f6b-8e85-8f28e46a3855"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8048), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5cacf641-2646-476b-938a-21562f669e54"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8055), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("67319725-24e9-4804-b92c-1bfefcf6f364"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8060), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("83fabf4b-448e-4e47-bbcb-94d71d9e5725"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8056), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("926c1268-862c-4ca5-9c27-556d6500556c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8050), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e19248b3-64cc-4418-89e9-4b9f26eabd91"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8033), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f03e4229-42d3-4bb8-aa70-86a642a6bd16"), "[[description]]", null, null, new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8053), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f2e9322b-51d0-4760-8604-7d138ad53b6c"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8052), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f8b66820-1ce0-4bba-9b2c-cd293f30c6c9"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 22, 16, 6, 27, 852, DateTimeKind.Local).AddTicks(8049), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

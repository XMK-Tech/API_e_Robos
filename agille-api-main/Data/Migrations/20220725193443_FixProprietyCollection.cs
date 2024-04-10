using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixProprietyCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProprietyAttachments_Propriety_ProprietyId1",
                table: "ProprietyAttachments");

            migrationBuilder.DropIndex(
                name: "IX_ProprietyAttachments_ProprietyId1",
                table: "ProprietyAttachments");

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

            migrationBuilder.DropColumn(
                name: "ProprietyId1",
                table: "ProprietyAttachments");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2b1dec12-f7b8-43ea-a3f9-7b72b2a23e60"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3033), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("62213704-ff7f-4dd2-bb21-220cfcb26625"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3068), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("7bbdb074-2e56-4e94-8664-bfdd128e445f"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3052), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7c2100a3-bd7b-48a4-93ee-bb483dfffb2b"), "[[description]]", null, null, new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3053), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a4ed6ebf-c28c-4088-ba0c-369166fc3d39"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3050), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ae2672b8-60ab-46aa-b4c4-6b9e6c5ef407"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3047), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c8ad22d4-e78f-49cb-a2d6-b7cf4520fd71"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3066), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e594e0e2-a1fd-4720-913e-4eee645e0e8b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3055), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e6817fa7-8429-4930-a319-c1de7f0974a0"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 25, 16, 34, 41, 553, DateTimeKind.Local).AddTicks(3049), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2b1dec12-f7b8-43ea-a3f9-7b72b2a23e60"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("62213704-ff7f-4dd2-bb21-220cfcb26625"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7bbdb074-2e56-4e94-8664-bfdd128e445f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7c2100a3-bd7b-48a4-93ee-bb483dfffb2b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a4ed6ebf-c28c-4088-ba0c-369166fc3d39"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ae2672b8-60ab-46aa-b4c4-6b9e6c5ef407"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c8ad22d4-e78f-49cb-a2d6-b7cf4520fd71"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e594e0e2-a1fd-4720-913e-4eee645e0e8b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e6817fa7-8429-4930-a319-c1de7f0974a0"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProprietyId1",
                table: "ProprietyAttachments",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "IX_ProprietyAttachments_ProprietyId1",
                table: "ProprietyAttachments",
                column: "ProprietyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProprietyAttachments_Propriety_ProprietyId1",
                table: "ProprietyAttachments",
                column: "ProprietyId1",
                principalTable: "Propriety",
                principalColumn: "Id");
        }
    }
}

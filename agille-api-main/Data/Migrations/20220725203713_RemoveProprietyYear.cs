using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RemoveProprietyYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Propriety");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("4c7ae303-47e3-4dd8-ac79-f2d4ec3f3244"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8556), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("63ff8e94-a492-4870-b330-423f3e99aad9"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8536), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6f450d17-6725-43fa-90a1-a6b682b51e4d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8571), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a51c1de1-1a7c-4d82-866b-7cc402ab3321"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8554), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("af994b78-a86c-458b-ac56-467f5509bcab"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8574), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("b6c38d04-5f72-4345-856e-551cf6985de9"), "[[description]]", null, null, new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8569), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c52ad694-3031-4157-994d-620efc9964ff"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8572), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d2b04d63-ebf8-427a-8ebc-bc36f0f35b00"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8553), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e452e9e0-7c72-49f3-8625-347b1a643b81"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 25, 17, 37, 11, 760, DateTimeKind.Local).AddTicks(8557), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c7ae303-47e3-4dd8-ac79-f2d4ec3f3244"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("63ff8e94-a492-4870-b330-423f3e99aad9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6f450d17-6725-43fa-90a1-a6b682b51e4d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a51c1de1-1a7c-4d82-866b-7cc402ab3321"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("af994b78-a86c-458b-ac56-467f5509bcab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6c38d04-5f72-4345-856e-551cf6985de9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c52ad694-3031-4157-994d-620efc9964ff"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d2b04d63-ebf8-427a-8ebc-bc36f0f35b00"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e452e9e0-7c72-49f3-8625-347b1a643b81"));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Propriety",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeTemplateModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14c4bdca-aa7a-4477-8c30-92b2affa1b0c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1712bbd4-0f4f-40f6-ad8b-55f34adcc19f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("606bce93-a24f-4245-83f8-359b39ec5769"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b4600af-013b-4888-82c9-68885c367d25"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("72dee710-8d2b-4b47-99b0-7c842ab2d7cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b722de0a-0212-4c41-b299-d5f8b7b6b007"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e71e6e37-3ddf-4b48-b46e-3f4eedef283b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ea8e037a-be5a-474a-a20f-d7a0117650a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fb547442-5041-4dea-a070-8dc72ebdf333"));

            migrationBuilder.AddColumn<int>(
                name: "Module",
                table: "NoticeTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("09310706-008e-4b72-87f7-89031a113144"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1224), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("175db536-d8cb-4b4a-803f-91a0dc66c9c9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1223), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("2984fc2d-a3d7-4aba-9c26-a2bf4cc78aae"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1207), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("481f6ec5-dfb1-4eb5-b53d-e1555d360f97"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1184), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("620278ac-db07-49c4-b927-4c2ccf062218"), "[[description]]", null, null, new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1208), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("829f22a8-bbc4-4fa3-8d0e-a757762e03e0"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1205), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8b877f55-b650-4295-9841-26b6d680af7c"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1202), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d9f7bde5-cb1b-4c55-b7b9-1d6a5b2fb960"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1204), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e28c65bc-0b2f-4f37-9af3-1bf5cecf199b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 21, 18, 39, 43, 329, DateTimeKind.Local).AddTicks(1222), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09310706-008e-4b72-87f7-89031a113144"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("175db536-d8cb-4b4a-803f-91a0dc66c9c9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2984fc2d-a3d7-4aba-9c26-a2bf4cc78aae"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("481f6ec5-dfb1-4eb5-b53d-e1555d360f97"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("620278ac-db07-49c4-b927-4c2ccf062218"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("829f22a8-bbc4-4fa3-8d0e-a757762e03e0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8b877f55-b650-4295-9841-26b6d680af7c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d9f7bde5-cb1b-4c55-b7b9-1d6a5b2fb960"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e28c65bc-0b2f-4f37-9af3-1bf5cecf199b"));

            migrationBuilder.DropColumn(
                name: "Module",
                table: "NoticeTemplates");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("14c4bdca-aa7a-4477-8c30-92b2affa1b0c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(408), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1712bbd4-0f4f-40f6-ad8b-55f34adcc19f"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4812), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("606bce93-a24f-4245-83f8-359b39ec5769"), "[[description]]", null, null, new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(422), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6b4600af-013b-4888-82c9-68885c367d25"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(417), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("72dee710-8d2b-4b47-99b0-7c842ab2d7cf"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(413), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b722de0a-0212-4c41-b299-d5f8b7b6b007"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 21, 15, 42, 26, 353, DateTimeKind.Local).AddTicks(4786), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e71e6e37-3ddf-4b48-b46e-3f4eedef283b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(460), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ea8e037a-be5a-474a-a20f-d7a0117650a3"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(455), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("fb547442-5041-4dea-a070-8dc72ebdf333"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(464), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

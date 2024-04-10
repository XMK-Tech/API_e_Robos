using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixSocialName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0269d268-00ad-469a-9892-ab8f4fcaa8d7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25e04345-f2bb-4f54-81b2-3e8fd32dd7e3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("34cdcb30-7613-4302-b1c2-e44a4ce64a52"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42f5593d-4b97-4ca1-b4de-ba30210dc76c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("52193b20-c252-4bdb-a84d-950092cf8025"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ac15549f-3329-47a6-85bb-68c5f7d74607"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c3d16d9e-7ed8-4060-bff5-cda3c8ff5fe0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d6b0833d-a667-4664-9793-3f2e516c5dcf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f5e3ce17-9e09-44ce-81aa-49303cb33a3c"));

            migrationBuilder.AlterColumn<string>(
                name: "SocialName",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("14c4bdca-aa7a-4477-8c30-92b2affa1b0c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(408), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("606bce93-a24f-4245-83f8-359b39ec5769"), "[[description]]", null, null, new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(422), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6b4600af-013b-4888-82c9-68885c367d25"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(417), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("72dee710-8d2b-4b47-99b0-7c842ab2d7cf"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(413), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8be7d6ec-cf03-467b-8fb9-57e393c6e2c9"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(370), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("aeb95533-55fc-4dcf-9e35-0e7df35acdd7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(403), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e71e6e37-3ddf-4b48-b46e-3f4eedef283b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(460), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ea8e037a-be5a-474a-a20f-d7a0117650a3"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(455), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("fb547442-5041-4dea-a070-8dc72ebdf333"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 19, 14, 56, 41, 834, DateTimeKind.Local).AddTicks(464), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14c4bdca-aa7a-4477-8c30-92b2affa1b0c"));

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
                keyValue: new Guid("8be7d6ec-cf03-467b-8fb9-57e393c6e2c9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aeb95533-55fc-4dcf-9e35-0e7df35acdd7"));

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

            migrationBuilder.AlterColumn<string>(
                name: "SocialName",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0269d268-00ad-469a-9892-ab8f4fcaa8d7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6884), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("25e04345-f2bb-4f54-81b2-3e8fd32dd7e3"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6893), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("34cdcb30-7613-4302-b1c2-e44a4ce64a52"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6859), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("42f5593d-4b97-4ca1-b4de-ba30210dc76c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6910), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("52193b20-c252-4bdb-a84d-950092cf8025"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6916), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("ac15549f-3329-47a6-85bb-68c5f7d74607"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6887), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c3d16d9e-7ed8-4060-bff5-cda3c8ff5fe0"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6913), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d6b0833d-a667-4664-9793-3f2e516c5dcf"), "[[description]]", null, null, new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6908), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f5e3ce17-9e09-44ce-81aa-49303cb33a3c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 19, 14, 41, 47, 813, DateTimeKind.Local).AddTicks(6890), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

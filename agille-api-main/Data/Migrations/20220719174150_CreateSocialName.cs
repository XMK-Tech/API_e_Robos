using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CreateSocialName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1cd71fa4-ec79-4d30-877d-1e53b21822d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("480c6b19-c31e-4685-8e84-7fb9c69f10c2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7cdb2560-8013-4079-bc48-790e3e5b4660"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8c66513d-c41b-4305-8675-9ebbdf53cb16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3589bef-b0fd-4e6d-b184-6782bf70c65d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc183b83-b21c-4552-99df-89323d565a39"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c07396a6-ce62-4a3d-a31e-2df7ce13d83e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c275acdd-8d9e-4e57-b357-25f998965db5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db4164be-8254-487a-9512-b116a8ed51b0"));

            migrationBuilder.AddColumn<string>(
                name: "SocialName",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SocialName",
                table: "Person");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1cd71fa4-ec79-4d30-877d-1e53b21822d9"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9449), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("480c6b19-c31e-4685-8e84-7fb9c69f10c2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9468), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7cdb2560-8013-4079-bc48-790e3e5b4660"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9435), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8c66513d-c41b-4305-8675-9ebbdf53cb16"), "[[description]]", null, null, new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9465), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a3589bef-b0fd-4e6d-b184-6782bf70c65d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9469), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("bc183b83-b21c-4552-99df-89323d565a39"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9467), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c07396a6-ce62-4a3d-a31e-2df7ce13d83e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9462), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c275acdd-8d9e-4e57-b357-25f998965db5"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9464), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("db4164be-8254-487a-9512-b116a8ed51b0"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 18, 15, 24, 48, 413, DateTimeKind.Local).AddTicks(9461), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

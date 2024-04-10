using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CreateProprietyLinkedCib : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e00f16a-1149-4988-90e2-ec7da8e81121"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49812518-3060-48c4-a8fa-bda30e852998"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4dbc6fa9-1ba9-422c-90b4-c9ddfee9ab96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("801a9170-36af-4d39-8595-a74d3a805685"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fc427e2-0eeb-439b-8349-d78398f1f89c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d07e281f-0826-4218-a002-83984f0386ff"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db0c01b1-0d26-422b-97af-9e7427cb85f4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddc2e04-91ee-4427-a59c-c2d8cbfc3388"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e845af8f-2a7b-4834-b7a5-e4a3ead9c882"));

            migrationBuilder.AddColumn<string>(
                name: "LinkedCib",
                table: "Propriety",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LinkedCib",
                table: "Propriety");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3e00f16a-1149-4988-90e2-ec7da8e81121"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(395), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("49812518-3060-48c4-a8fa-bda30e852998"), "[[description]]", null, null, new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(394), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("4dbc6fa9-1ba9-422c-90b4-c9ddfee9ab96"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(405), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("801a9170-36af-4d39-8595-a74d3a805685"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(407), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("9fc427e2-0eeb-439b-8349-d78398f1f89c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(391), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d07e281f-0826-4218-a002-83984f0386ff"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(374), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("db0c01b1-0d26-422b-97af-9e7427cb85f4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(393), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("dddc2e04-91ee-4427-a59c-c2d8cbfc3388"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(389), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e845af8f-2a7b-4834-b7a5-e4a3ead9c882"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(387), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ExpenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("01e3f27c-e720-4e06-951b-77b9dc1e2426"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1ef141cb-7597-48d7-9fbb-e4ef024739c5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55a0dcb7-4816-4dc5-9a36-6cfb1e74fd4c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6df401c5-0372-4b42-afa3-3bb7b165ffe6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ee66f6e-8244-4892-83c3-58d17c765fe1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("adeae847-6f2b-425f-8cff-1973ea5ad838"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b0c2c640-49c2-426e-9dd3-7f065af94995"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b60d5afd-cc0d-45c0-a927-c0db5774a539"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f8f82ae6-19f9-4924-86ba-493e37bc8fb8"));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3c1e2953-4f43-4d85-802a-0e10aca6cf11"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8618), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3e4c2228-df4f-4254-b1a8-cede94ffb960"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8622), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7ab0f679-d5a2-4a47-899f-8c88161f71ce"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8621), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7fbd3e57-141f-4fbd-9fe0-6a6061df26b7"), "[[description]]", null, null, new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8620), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("88998412-5a45-44c6-9c57-305dbb657943"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8617), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("97b0789e-eaf5-4818-a49b-80fd366e5a16"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8614), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c27297bd-bedb-4182-93b2-9d19f3780430"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8626), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("cb9ca6ef-7f3d-4278-a8dc-5ba6db9ee28d"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8599), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cdc5a020-e97a-4dca-8bf1-e98a8fbc7d82"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8615), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c1e2953-4f43-4d85-802a-0e10aca6cf11"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e4c2228-df4f-4254-b1a8-cede94ffb960"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ab0f679-d5a2-4a47-899f-8c88161f71ce"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7fbd3e57-141f-4fbd-9fe0-6a6061df26b7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("88998412-5a45-44c6-9c57-305dbb657943"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97b0789e-eaf5-4818-a49b-80fd366e5a16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c27297bd-bedb-4182-93b2-9d19f3780430"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cb9ca6ef-7f3d-4278-a8dc-5ba6db9ee28d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cdc5a020-e97a-4dca-8bf1-e98a8fbc7d82"));

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Expenses");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("01e3f27c-e720-4e06-951b-77b9dc1e2426"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4399), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1ef141cb-7597-48d7-9fbb-e4ef024739c5"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4376), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("55a0dcb7-4816-4dc5-9a36-6cfb1e74fd4c"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4418), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("6df401c5-0372-4b42-afa3-3bb7b165ffe6"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4417), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7ee66f6e-8244-4892-83c3-58d17c765fe1"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4400), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("adeae847-6f2b-425f-8cff-1973ea5ad838"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4398), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b0c2c640-49c2-426e-9dd3-7f065af94995"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4396), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b60d5afd-cc0d-45c0-a927-c0db5774a539"), "[[description]]", null, null, new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4414), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f8f82ae6-19f9-4924-86ba-493e37bc8fb8"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 16, 12, 9, 54, 837, DateTimeKind.Local).AddTicks(4415), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

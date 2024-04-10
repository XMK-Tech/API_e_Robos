using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class CreateTransactionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("16d27fce-c22f-4c3b-b062-cf24310de142"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("29535f85-f637-43df-a142-34e34ee55bd8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7691fca6-972c-407a-bee0-c13b40ea79a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3e60430-b36b-4ae3-843b-ed6008e60383"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d4929947-e532-43ae-ad8b-92096a7a02fd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db22c6db-420f-4d1c-823d-8e833ddc4757"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dcc18eff-994e-45cd-a89c-38401232f5d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f58ceda8-6638-4cae-bc9f-2c42936c791d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fd28330d-8707-4055-b631-8ef8b3559014"));

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "TransactionEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("9028599b-df2f-48c7-9be7-6f26ccc859cc"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 103, DateTimeKind.Local).AddTicks(6202), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("82135c9f-4856-4359-9579-30db552833e0"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4647), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("45a23180-b7d7-4252-89ee-5e7b49b96a01"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4717), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("109ac90f-884b-42b5-b967-2a7aefbaa765"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4720), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c978a021-f1a7-4c82-9a62-903fdf494e2e"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4723), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("69f6d73c-4b90-4004-8808-e24271b15d05"), "[[description]]", null, null, new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4725), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("87da6d0d-54b2-42e4-b30b-9f07b8fb976a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4735), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("40b37410-e7f6-4dff-948f-6e1b747fc01a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4739), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e770c720-e7ac-4334-b415-e42faf8c1b5d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4741), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("109ac90f-884b-42b5-b967-2a7aefbaa765"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("40b37410-e7f6-4dff-948f-6e1b747fc01a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45a23180-b7d7-4252-89ee-5e7b49b96a01"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("69f6d73c-4b90-4004-8808-e24271b15d05"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("82135c9f-4856-4359-9579-30db552833e0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87da6d0d-54b2-42e4-b30b-9f07b8fb976a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9028599b-df2f-48c7-9be7-6f26ccc859cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c978a021-f1a7-4c82-9a62-903fdf494e2e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e770c720-e7ac-4334-b415-e42faf8c1b5d"));

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "TransactionEntry");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("db22c6db-420f-4d1c-823d-8e833ddc4757"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 195, DateTimeKind.Local).AddTicks(9889), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f58ceda8-6638-4cae-bc9f-2c42936c791d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2059), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("29535f85-f637-43df-a142-34e34ee55bd8"), "[[person-name]]", "Name", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2144), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7691fca6-972c-407a-bee0-c13b40ea79a8"), "[[person-document]]", "Document", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2147), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fd28330d-8707-4055-b631-8ef8b3559014"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2149), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3e60430-b36b-4ae3-843b-ed6008e60383"), "[[description]]", null, null, new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2151), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("16d27fce-c22f-4c3b-b062-cf24310de142"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2159), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("dcc18eff-994e-45cd-a89c-38401232f5d9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2161), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d4929947-e532-43ae-ad8b-92096a7a02fd"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2163), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

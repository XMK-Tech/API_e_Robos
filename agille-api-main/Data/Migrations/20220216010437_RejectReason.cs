using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class RejectReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c4dd5e9-b343-49cb-9791-39e009a0aeb2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("11493562-ad09-4caa-8558-9ab40658e10d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("257cbbab-b361-41d3-a924-53c62196b157"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a879de8-da85-4365-81d0-f1567433c1a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9876109f-049f-47b4-8d27-1af13ab87680"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3e72006-aa1b-4608-8d66-0abc09815b3b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a9bf1842-483d-45b1-8f8e-4eec4019a158"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ac365b92-e385-4d8a-84e2-cc1c8525d253"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f75e6411-b607-42b5-b345-7cef78244597"));

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "ImportFile",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("7f3f77b2-776e-4c89-975b-0b74ac5f4331"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 73, DateTimeKind.Local).AddTicks(1227), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c085fc32-b5e2-4440-b35f-eb392889b450"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2467), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2ea34356-c91f-4c6b-911a-d8acbb15b58d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2564), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e130f46a-a6b2-4e48-9485-3df962c2ae37"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2568), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("db5726f3-ac2c-4227-8dc4-b35ddfd3f409"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2571), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a0dcca4a-903d-4acc-b5b2-657d19a73e10"), "[[description]]", null, null, new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2574), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("080c6772-8074-4e90-86ab-170dd233483d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2586), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4ebb2fbc-65f5-44bf-b307-bbf2ae77980b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2589), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("144ffe50-35d0-44d3-8445-2b1813a359cc"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 15, 22, 4, 37, 74, DateTimeKind.Local).AddTicks(2591), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("080c6772-8074-4e90-86ab-170dd233483d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("144ffe50-35d0-44d3-8445-2b1813a359cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2ea34356-c91f-4c6b-911a-d8acbb15b58d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ebb2fbc-65f5-44bf-b307-bbf2ae77980b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7f3f77b2-776e-4c89-975b-0b74ac5f4331"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a0dcca4a-903d-4acc-b5b2-657d19a73e10"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c085fc32-b5e2-4440-b35f-eb392889b450"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db5726f3-ac2c-4227-8dc4-b35ddfd3f409"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e130f46a-a6b2-4e48-9485-3df962c2ae37"));

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "ImportFile");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("f75e6411-b607-42b5-b345-7cef78244597"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 449, DateTimeKind.Local).AddTicks(8531), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ac365b92-e385-4d8a-84e2-cc1c8525d253"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8109), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6a879de8-da85-4365-81d0-f1567433c1a3"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8186), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3e72006-aa1b-4608-8d66-0abc09815b3b"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8191), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("0c4dd5e9-b343-49cb-9791-39e009a0aeb2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8193), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9876109f-049f-47b4-8d27-1af13ab87680"), "[[description]]", null, null, new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8195), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("257cbbab-b361-41d3-a924-53c62196b157"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8198), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("11493562-ad09-4caa-8558-9ab40658e10d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8209), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a9bf1842-483d-45b1-8f8e-4eec4019a158"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 15, 19, 41, 38, 450, DateTimeKind.Local).AddTicks(8212), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

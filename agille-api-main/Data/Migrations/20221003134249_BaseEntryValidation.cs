using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class BaseEntryValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13d0700c-9277-4e87-96f6-e18ad4e8f1a6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("334f802b-1786-4c13-a608-3d8784d1b4bc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("489e477d-290e-4f77-8daf-43c53e306145"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ba4a7c5-df39-4734-994f-ec0619f1fe2c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87a61d86-6873-4244-8abd-14bd78dce6c6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e37107b-3a64-439b-81ae-a19ba558a7f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a05146ef-8cbe-400f-9dee-4dc8476c9479"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a0bb4b5f-aca0-4d4a-9fc6-5395fd8fc56b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aace6f25-2507-4cb3-b20f-38131520ea7d"));

            migrationBuilder.AddColumn<bool>(
                name: "IsInvalid",
                table: "TransactionEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvalid",
                table: "InvoiceEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("25c9a96f-36ab-4cdb-afd4-bfafdb829a6a"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4178), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("3c5b1b65-5325-4931-8b39-2c919453664e"), "[[description]]", null, null, new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4168), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("52139313-3682-49f4-ba2e-51cc606c3d6e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4165), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6c09f13c-92ee-4498-91b4-6e22bef17f93"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4175), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("93c6d3b9-f2a9-4f31-bc8c-1926c0f062bd"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4162), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b2d2a184-03b4-4635-859f-333a823203e2"), "[[person-name]]", "Name", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4163), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b3d1db5c-0c7c-44f3-bf58-262a199304f5"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4146), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b87816ba-9488-4c1f-8e57-8b55d57f467d"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4166), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bca93db8-b5b0-4989-b261-db29aaf1b3d0"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 10, 3, 10, 42, 45, 564, DateTimeKind.Local).AddTicks(4177), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25c9a96f-36ab-4cdb-afd4-bfafdb829a6a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c5b1b65-5325-4931-8b39-2c919453664e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("52139313-3682-49f4-ba2e-51cc606c3d6e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6c09f13c-92ee-4498-91b4-6e22bef17f93"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("93c6d3b9-f2a9-4f31-bc8c-1926c0f062bd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b2d2a184-03b4-4635-859f-333a823203e2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3d1db5c-0c7c-44f3-bf58-262a199304f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b87816ba-9488-4c1f-8e57-8b55d57f467d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bca93db8-b5b0-4989-b261-db29aaf1b3d0"));

            migrationBuilder.DropColumn(
                name: "IsInvalid",
                table: "TransactionEntry");

            migrationBuilder.DropColumn(
                name: "IsInvalid",
                table: "InvoiceEntry");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("13d0700c-9277-4e87-96f6-e18ad4e8f1a6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5486), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("334f802b-1786-4c13-a608-3d8784d1b4bc"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5474), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("489e477d-290e-4f77-8daf-43c53e306145"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5477), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4ba4a7c5-df39-4734-994f-ec0619f1fe2c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5454), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("87a61d86-6873-4244-8abd-14bd78dce6c6"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5473), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8e37107b-3a64-439b-81ae-a19ba558a7f5"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5471), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a05146ef-8cbe-400f-9dee-4dc8476c9479"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5485), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a0bb4b5f-aca0-4d4a-9fc6-5395fd8fc56b"), "[[description]]", null, null, new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5476), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("aace6f25-2507-4cb3-b20f-38131520ea7d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 28, 21, 6, 53, 754, DateTimeKind.Local).AddTicks(5470), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

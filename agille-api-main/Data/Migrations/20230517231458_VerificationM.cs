using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class VerificationM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("037e3440-fce2-4aa8-9d47-d2032cfa009f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0dc6b465-d670-4bb7-b7b9-91aa02e073da"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1ccd58de-2788-4468-8441-897e1cec00ae"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("32729c53-079c-4562-b550-89cff3e0f733"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("732f7fc4-9986-4c6e-98f2-10e759152f6e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a36c7f34-c63b-4799-90a2-876b6648bc9a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cd9368c8-6a31-4a47-a960-39739d5262da"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d83623a5-41de-4802-8731-a6f91156eb49"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed11af5d-955e-4ace-9c5f-e96c89a9c7e9"));

            migrationBuilder.CreateTable(
                name: "Verification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueToArbitrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Exercice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verification", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1b38a941-e3fa-4c9a-bbbf-4e638c02df87"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5333), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3ed752f9-4c3f-4cc9-8860-c2035b35b66a"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5318), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7b71f37d-d186-4cbd-be4e-1fb30a0bc1ee"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5316), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9d254f77-a60d-4987-8a73-2eea38213031"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5301), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a11e8ca1-a98a-4ac3-89b0-c5b0f9df07c6"), "[[description]]", null, null, new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5332), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a174b04a-0dc1-4046-b4d0-30ef9e312a16"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5336), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("cd10055d-359c-4e62-92a5-49939bd34e5f"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5315), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ceab85c7-1c2d-48ea-a941-cb29eea0a84a"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5335), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f66450a6-3f94-4d8a-bccf-f8b08dbb9bab"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 17, 20, 14, 53, 924, DateTimeKind.Local).AddTicks(5313), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verification");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1b38a941-e3fa-4c9a-bbbf-4e638c02df87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3ed752f9-4c3f-4cc9-8860-c2035b35b66a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7b71f37d-d186-4cbd-be4e-1fb30a0bc1ee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9d254f77-a60d-4987-8a73-2eea38213031"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a11e8ca1-a98a-4ac3-89b0-c5b0f9df07c6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a174b04a-0dc1-4046-b4d0-30ef9e312a16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cd10055d-359c-4e62-92a5-49939bd34e5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ceab85c7-1c2d-48ea-a941-cb29eea0a84a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f66450a6-3f94-4d8a-bccf-f8b08dbb9bab"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("037e3440-fce2-4aa8-9d47-d2032cfa009f"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8228), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("0dc6b465-d670-4bb7-b7b9-91aa02e073da"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8227), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1ccd58de-2788-4468-8441-897e1cec00ae"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8242), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("32729c53-079c-4562-b550-89cff3e0f733"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8225), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("732f7fc4-9986-4c6e-98f2-10e759152f6e"), "[[description]]", null, null, new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8231), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a36c7f34-c63b-4799-90a2-876b6648bc9a"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8230), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cd9368c8-6a31-4a47-a960-39739d5262da"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8240), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d83623a5-41de-4802-8731-a6f91156eb49"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8239), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ed11af5d-955e-4ace-9c5f-e96c89a9c7e9"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 11, 10, 25, 9, 903, DateTimeKind.Local).AddTicks(8211), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

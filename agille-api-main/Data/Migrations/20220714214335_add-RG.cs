using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class addRG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1309abe4-59f0-4901-a161-b6c63ee77fa6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("15492e72-20d6-401d-af82-2117a4045aec"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("32351e42-cf59-4ae5-aa58-85e50361b14e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3d641269-6cd1-499b-a505-04bd79058fba"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6da2b120-2bbc-4efa-9801-3e73bc68654b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8f6c73c1-c95e-44e6-8b89-10f96a701cf4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9b6549f3-c589-4d06-a979-512a77c0eea7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a77f8096-5e1c-4a1d-af46-65a3277e59d1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aacdbc08-6a79-440a-9ec4-3a24b2351a47"));

            migrationBuilder.AddColumn<string>(
                name: "GeneralRecord",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("402df71a-7c53-4a58-84d5-7b167e444d33"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9101), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("48de4812-1551-42f0-a2f6-9b849943b0db"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9098), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8d4a44e6-d372-48e7-98db-724f011fff7a"), "[[description]]", null, null, new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9111), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ad19d7a2-1c3c-48b9-9837-4e6f738b5a29"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9103), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d06695c3-85a2-45b1-b25e-a6e9c35d6041"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9113), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("de295dba-5316-41f0-825a-1be37dd31760"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9115), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f16e5446-9fde-4865-a6a7-525be32ddcab"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9100), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f7ed0b0f-ce65-4fd8-803b-c251f6093bfe"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9112), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ff99eaa4-6f59-4122-944a-232aa2d6aa7f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 14, 18, 43, 33, 818, DateTimeKind.Local).AddTicks(9083), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("402df71a-7c53-4a58-84d5-7b167e444d33"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("48de4812-1551-42f0-a2f6-9b849943b0db"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8d4a44e6-d372-48e7-98db-724f011fff7a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ad19d7a2-1c3c-48b9-9837-4e6f738b5a29"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d06695c3-85a2-45b1-b25e-a6e9c35d6041"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("de295dba-5316-41f0-825a-1be37dd31760"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f16e5446-9fde-4865-a6a7-525be32ddcab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f7ed0b0f-ce65-4fd8-803b-c251f6093bfe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ff99eaa4-6f59-4122-944a-232aa2d6aa7f"));

            migrationBuilder.DropColumn(
                name: "GeneralRecord",
                table: "Person");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1309abe4-59f0-4901-a161-b6c63ee77fa6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5566), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("15492e72-20d6-401d-af82-2117a4045aec"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5547), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("32351e42-cf59-4ae5-aa58-85e50361b14e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5544), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3d641269-6cd1-499b-a505-04bd79058fba"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5540), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6da2b120-2bbc-4efa-9801-3e73bc68654b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5563), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8f6c73c1-c95e-44e6-8b89-10f96a701cf4"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5570), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("9b6549f3-c589-4d06-a979-512a77c0eea7"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5542), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a77f8096-5e1c-4a1d-af46-65a3277e59d1"), "[[description]]", null, null, new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5549), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("aacdbc08-6a79-440a-9ec4-3a24b2351a47"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5521), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

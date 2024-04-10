using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixRevenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("245eea86-3c0b-4f53-bf9e-cb9106214a47"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c63c34f-0ebc-46cd-b12b-64f8dfdb2f09"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("53fbf41d-c868-4bff-9417-0bb413c17d80"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56e9bc2f-5828-4e4f-b08b-ba9e51666c5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("60343580-ad01-41e3-bbfc-06e7887f82d7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("826b5173-d589-4d3d-abf9-b5d832b74917"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b4768979-0ab1-45ac-bdce-9af9bcf27127"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("efa2499d-b7d7-4769-af67-93750c6e1d85"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f609b3e8-6afc-4ad6-b90a-3d2061c95510"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingReference",
                table: "Revenues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingReference",
                table: "Revenues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("05c8c972-59a6-4342-ba3e-c6a4c5cc6bf9"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2451), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("11205a66-375b-4ab8-b54f-6f3ede99f797"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2454), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2465125a-6b31-4892-8f35-ae2794582f94"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2450), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("57f88f3b-7340-4ee7-9812-6e0ffaa63744"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2466), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("614514eb-499b-4c45-bdde-d1a01440a8b7"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2459), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6adb52af-70d6-498b-ab84-6e2c7549ec42"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2447), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("961b8c1a-c17c-437c-9b91-03adc94166f0"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2457), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c1ddeae9-a49b-4cfd-bb7a-0b3704dc6799"), "[[description]]", null, null, new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2455), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("db79bfb8-3e3f-4b40-9805-0cb0dc03c6da"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2415), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("05c8c972-59a6-4342-ba3e-c6a4c5cc6bf9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("11205a66-375b-4ab8-b54f-6f3ede99f797"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2465125a-6b31-4892-8f35-ae2794582f94"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("57f88f3b-7340-4ee7-9812-6e0ffaa63744"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("614514eb-499b-4c45-bdde-d1a01440a8b7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6adb52af-70d6-498b-ab84-6e2c7549ec42"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("961b8c1a-c17c-437c-9b91-03adc94166f0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c1ddeae9-a49b-4cfd-bb7a-0b3704dc6799"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db79bfb8-3e3f-4b40-9805-0cb0dc03c6da"));

            migrationBuilder.DropColumn(
                name: "EndingReference",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "StartingReference",
                table: "Revenues");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("245eea86-3c0b-4f53-bf9e-cb9106214a47"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8886), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c63c34f-0ebc-46cd-b12b-64f8dfdb2f09"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8861), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("53fbf41d-c868-4bff-9417-0bb413c17d80"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8894), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("56e9bc2f-5828-4e4f-b08b-ba9e51666c5f"), "[[description]]", null, null, new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8888), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("60343580-ad01-41e3-bbfc-06e7887f82d7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8878), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("826b5173-d589-4d3d-abf9-b5d832b74917"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8889), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b4768979-0ab1-45ac-bdce-9af9bcf27127"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8883), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("efa2499d-b7d7-4769-af67-93750c6e1d85"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8885), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f609b3e8-6afc-4ad6-b90a-3d2061c95510"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8891), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

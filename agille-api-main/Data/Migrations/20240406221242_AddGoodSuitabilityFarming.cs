using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddGoodSuitabilityFarming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c3fd70e-a23d-475d-89c9-5666d18e4431"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("569276e5-2e0c-4c81-b223-1c3e6f79794b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90bce2c0-fd7c-4b05-859f-b51f5171358c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a1bf10c3-0f7a-41b4-a63a-7a2901dfd363"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a1c8783c-fdbe-4b5a-a81d-38962a84342d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a63cc665-e280-427d-a5d8-67bfdf6a4ab5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d8ec8ea0-c9a0-490c-9a2a-aa972adee329"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("df9839bc-d2eb-4c30-aa00-a1d8cfe178b8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e07a0c7f-1bc6-4473-9748-20cc3b0d3cea"));

            migrationBuilder.AddColumn<decimal>(
                name: "GoodSuitabilityFarming",
                table: "BareLandValues",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PlantedPasture",
                table: "BareLandValues",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularFitnessFarming",
                table: "BareLandValues",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RestrictedAptitudeFarming",
                table: "BareLandValues",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1170148c-ffb8-440c-b003-64c169e5a004"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4477), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("29bb2704-217f-4dbc-ad2c-15a09ad85a98"), "[[attachment-url]]", "Url", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4484), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("2d286d4b-b661-48cd-83ee-28606028c394"), "[[phone-number]]", "Number", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4500), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("72096949-4334-4fb4-aca1-4dad5bbc59a8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4481), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("78d05b3c-caf1-4bff-a401-3497cf83d691"), "[[person-name]]", "Name", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4479), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c4e7ae3a-a306-436c-b9dc-1a6e6b689cc8"), "[[person-document]]", "Document", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4480), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c8fc64c4-a838-40d8-9726-ad5979e56cf4"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4458), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ecb55701-c5de-4817-a8e7-2eeabc937381"), "[[description]]", null, null, new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4482), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f2fb5515-392d-404e-9fe3-f8874858c80d"), "[[attachment-url]]", "Url", "Id", new DateTime(2024, 4, 6, 19, 12, 41, 826, DateTimeKind.Local).AddTicks(4499), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1170148c-ffb8-440c-b003-64c169e5a004"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("29bb2704-217f-4dbc-ad2c-15a09ad85a98"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2d286d4b-b661-48cd-83ee-28606028c394"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("72096949-4334-4fb4-aca1-4dad5bbc59a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("78d05b3c-caf1-4bff-a401-3497cf83d691"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c4e7ae3a-a306-436c-b9dc-1a6e6b689cc8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c8fc64c4-a838-40d8-9726-ad5979e56cf4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ecb55701-c5de-4817-a8e7-2eeabc937381"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f2fb5515-392d-404e-9fe3-f8874858c80d"));

            migrationBuilder.DropColumn(
                name: "GoodSuitabilityFarming",
                table: "BareLandValues");

            migrationBuilder.DropColumn(
                name: "PlantedPasture",
                table: "BareLandValues");

            migrationBuilder.DropColumn(
                name: "RegularFitnessFarming",
                table: "BareLandValues");

            migrationBuilder.DropColumn(
                name: "RestrictedAptitudeFarming",
                table: "BareLandValues");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c3fd70e-a23d-475d-89c9-5666d18e4431"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9201), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("569276e5-2e0c-4c81-b223-1c3e6f79794b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9161), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("90bce2c0-fd7c-4b05-859f-b51f5171358c"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9202), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a1bf10c3-0f7a-41b4-a63a-7a2901dfd363"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9177), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a1c8783c-fdbe-4b5a-a81d-38962a84342d"), "[[person-name]]", "Name", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9179), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a63cc665-e280-427d-a5d8-67bfdf6a4ab5"), "[[description]]", null, null, new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9200), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d8ec8ea0-c9a0-490c-9a2a-aa972adee329"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9204), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("df9839bc-d2eb-4c30-aa00-a1d8cfe178b8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9181), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e07a0c7f-1bc6-4473-9748-20cc3b0d3cea"), "[[person-document]]", "Document", "Id", new DateTime(2023, 9, 20, 10, 52, 41, 573, DateTimeKind.Local).AddTicks(9180), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

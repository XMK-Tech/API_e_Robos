using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddComponentArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "GoodSuitabilityFarming",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PlantedPasture",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularFitnessFarming",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RestrictedAptitudeFarming",
                table: "Propriety",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("217d01a0-c5bc-472c-955f-a83328b154b1"), "[[person-name]]", "Name", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1883), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3713cba6-b93d-4e62-b7b9-2accde558b11"), "[[attachment-url]]", "Url", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1889), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("41e9def5-9494-405c-b4ef-0905ba28e4ce"), "[[phone-number]]", "Number", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1904), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5480672e-a4e2-49c5-b0fa-d388b986153f"), "[[description]]", null, null, new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1888), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6d90508b-9554-45b5-bb31-e419d0602fd3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1861), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("bc759d8e-9fb5-4c9c-be86-a8b1e049aa81"), "[[person-document]]", "Document", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1885), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cf5d82e0-1c53-4e5f-8f4a-5173e8e98eab"), "[[attachment-url]]", "Url", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1902), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e4604c7a-4beb-41bb-81fb-785c5b92ea84"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1881), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("eba0e9b0-560c-4521-bb42-f6038ab88425"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2024, 4, 7, 15, 59, 41, 909, DateTimeKind.Local).AddTicks(1886), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("217d01a0-c5bc-472c-955f-a83328b154b1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3713cba6-b93d-4e62-b7b9-2accde558b11"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("41e9def5-9494-405c-b4ef-0905ba28e4ce"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5480672e-a4e2-49c5-b0fa-d388b986153f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6d90508b-9554-45b5-bb31-e419d0602fd3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc759d8e-9fb5-4c9c-be86-a8b1e049aa81"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cf5d82e0-1c53-4e5f-8f4a-5173e8e98eab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e4604c7a-4beb-41bb-81fb-785c5b92ea84"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("eba0e9b0-560c-4521-bb42-f6038ab88425"));

            migrationBuilder.DropColumn(
                name: "GoodSuitabilityFarming",
                table: "Propriety");

            migrationBuilder.DropColumn(
                name: "PlantedPasture",
                table: "Propriety");

            migrationBuilder.DropColumn(
                name: "RegularFitnessFarming",
                table: "Propriety");

            migrationBuilder.DropColumn(
                name: "RestrictedAptitudeFarming",
                table: "Propriety");

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
    }
}

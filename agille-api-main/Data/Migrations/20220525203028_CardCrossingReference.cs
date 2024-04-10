using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CardCrossingReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("22a0b1c3-6895-4460-bb34-58cecb100245"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2405ae5d-e4fc-469e-ba76-9da9b4d65429"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2b0112d6-6656-4e54-bed8-e61deec51998"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3900dfb8-e3ec-4872-a47f-c8b7f1bdcdf3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("729184de-6a2f-4d91-abfe-05f1bb1a3fc6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d98e7436-a601-4038-a3aa-a3eb957eba13"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ee8d4ee0-2a1d-46fe-8221-d2529fddfc33"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f4a291ab-d757-4fe2-bfab-89f0c195105b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fc11bfe6-b1b3-457e-af5b-ff674daaac37"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Reference",
                table: "CardCrossing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3fb4be2b-1104-4e68-846e-84590a782a62"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1064), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("47981f05-b8eb-45f1-96e6-876f473475db"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1062), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7df68cfe-7c34-4087-91a1-ccb249de99a9"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1053), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b08b146c-acde-42b4-8b35-6c422f309b98"), "[[description]]", null, null, new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1065), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b6afdc7d-2b76-45fa-b1c8-df8757232d7d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1069), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cc17b435-a091-4b86-bdc8-409fb62cf72a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1067), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("dd37779a-bcc2-4e9b-b718-eb892dc761a2"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1061), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ec186830-ec7b-4df3-8446-2de09bae9d63"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1072), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f618f4d2-b85e-41dd-bdde-c1e441ece5bc"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1041), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3fb4be2b-1104-4e68-846e-84590a782a62"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("47981f05-b8eb-45f1-96e6-876f473475db"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7df68cfe-7c34-4087-91a1-ccb249de99a9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b08b146c-acde-42b4-8b35-6c422f309b98"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6afdc7d-2b76-45fa-b1c8-df8757232d7d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cc17b435-a091-4b86-bdc8-409fb62cf72a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dd37779a-bcc2-4e9b-b718-eb892dc761a2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec186830-ec7b-4df3-8446-2de09bae9d63"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f618f4d2-b85e-41dd-bdde-c1e441ece5bc"));

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "CardCrossing");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("22a0b1c3-6895-4460-bb34-58cecb100245"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2902), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("2405ae5d-e4fc-469e-ba76-9da9b4d65429"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2881), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2b0112d6-6656-4e54-bed8-e61deec51998"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2871), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("3900dfb8-e3ec-4872-a47f-c8b7f1bdcdf3"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2899), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("729184de-6a2f-4d91-abfe-05f1bb1a3fc6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2900), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d98e7436-a601-4038-a3aa-a3eb957eba13"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2894), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ee8d4ee0-2a1d-46fe-8221-d2529fddfc33"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2883), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f4a291ab-d757-4fe2-bfab-89f0c195105b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2895), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fc11bfe6-b1b3-457e-af5b-ff674daaac37"), "[[description]]", null, null, new DateTime(2022, 5, 25, 13, 13, 26, 491, DateTimeKind.Local).AddTicks(2897), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }
    }
}

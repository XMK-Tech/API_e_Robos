using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RemoveUserConstrait : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardCrossingReport_User_RequestedById",
                table: "CardCrossingReport");

            migrationBuilder.DropIndex(
                name: "IX_CardCrossingReport_RequestedById",
                table: "CardCrossingReport");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("10c1cd0e-9024-4ad3-a2cf-313bc9b8d570"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("236677ac-a1f2-4d7f-8435-bce7158f59ad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42a17c66-40e9-48dd-8d64-5a1304b87b6b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45cbe9e2-6b5f-4f1f-9a09-8579e38d110b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("52e529f5-2c93-4e94-9bdc-c923c94e3e20"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89a1ab2f-859b-4606-b4d7-bf46d9ab7305"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aada6e77-e43a-4652-973e-318cf39bc4b3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d74eb1e3-5106-4970-9bc3-ca0b1685d14e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ebb6455b-e064-4019-befa-5b25afa9a642"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("10c1cd0e-9024-4ad3-a2cf-313bc9b8d570"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6494), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("236677ac-a1f2-4d7f-8435-bce7158f59ad"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6477), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("42a17c66-40e9-48dd-8d64-5a1304b87b6b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6508), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("45cbe9e2-6b5f-4f1f-9a09-8579e38d110b"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6492), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("52e529f5-2c93-4e94-9bdc-c923c94e3e20"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6507), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("89a1ab2f-859b-4606-b4d7-bf46d9ab7305"), "[[description]]", null, null, new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6505), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("aada6e77-e43a-4652-973e-318cf39bc4b3"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6490), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d74eb1e3-5106-4970-9bc3-ca0b1685d14e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6488), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ebb6455b-e064-4019-befa-5b25afa9a642"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6510), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCrossingReport_RequestedById",
                table: "CardCrossingReport",
                column: "RequestedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CardCrossingReport_User_RequestedById",
                table: "CardCrossingReport",
                column: "RequestedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

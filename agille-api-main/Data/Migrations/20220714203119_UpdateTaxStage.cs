using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class UpdateTaxStage : Migration
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

            migrationBuilder.AddColumn<decimal>(
                name: "FineAmount",
                table: "TaxStages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TrackingCode",
                table: "TaxStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3855b49b-09d6-4168-94a6-a644c1385420"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2354), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("5f3e9178-19a3-4f94-91ed-8634a03ee217"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2342), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6ea2b399-acca-4a82-9ff1-26622ba6d148"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2357), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("73265ced-1862-42b7-b0c4-585982233fe5"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2341), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("771d8c6f-7607-40b6-8595-0e2bba26500a"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2323), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8961e327-7581-4039-a033-3e31e624e3f2"), "[[description]]", null, null, new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2353), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b1237e2b-7c70-4065-8b09-a33574fb2409"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2351), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d9ccecf9-4367-4696-bda7-b7fe3c4c3893"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2355), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ef818404-bb84-4cac-abfb-4a3da50eec66"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2349), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3855b49b-09d6-4168-94a6-a644c1385420"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5f3e9178-19a3-4f94-91ed-8634a03ee217"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6ea2b399-acca-4a82-9ff1-26622ba6d148"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("73265ced-1862-42b7-b0c4-585982233fe5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("771d8c6f-7607-40b6-8595-0e2bba26500a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8961e327-7581-4039-a033-3e31e624e3f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b1237e2b-7c70-4065-8b09-a33574fb2409"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d9ccecf9-4367-4696-bda7-b7fe3c4c3893"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ef818404-bb84-4cac-abfb-4a3da50eec66"));

            migrationBuilder.DropColumn(
                name: "FineAmount",
                table: "TaxStages");

            migrationBuilder.DropColumn(
                name: "TrackingCode",
                table: "TaxStages");

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

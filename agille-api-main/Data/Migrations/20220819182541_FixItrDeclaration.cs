using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixItrDeclaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3901a2a1-60cf-4eac-b696-9f94c968cc23"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4055ed78-b76f-4463-b223-bc6639311e89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4e3e942e-6391-4e06-97b1-ff3a5f25bbed"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5136f9a3-ccc3-41be-a608-129d06ed9b53"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7bc0cb80-e6f7-428d-8b9b-d483271ab011"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8a1a4d6b-b4cc-40e2-923c-6f08b710f84c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90c1d470-19e1-48c5-a997-b24d387cacfb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ae921059-1a81-4442-8936-4fd48965fce6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f8d03850-4d3b-4919-b841-7744ebf7df1e"));

            migrationBuilder.RenameColumn(
                name: "EnvironmentalPreservation",
                table: "TaxPayerDeclarations",
                newName: "PermanentPreservationArea");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0f047949-61da-4091-aaa7-455c9b5d2080"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1381), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("11a4536f-3a4e-4ab8-8fa7-646c61fb7747"), "[[description]]", null, null, new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1369), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("13f30d07-5a50-49ef-8d30-60817942b61f"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1358), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("23bcfc03-e6a8-4f0e-92c7-21de9bf97f2d"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1362), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("36186670-2ea7-42b1-9787-8dec4c642a7c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1335), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("379a2d86-2971-4d35-b2dc-5423f53441c7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1374), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4f2f0b53-2d62-4206-aa68-0803a512bf5c"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1354), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8cc92510-521b-4c55-beb8-6ed90361cae2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1364), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b932caed-0124-45a3-8293-33d94f90d44e"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 19, 15, 25, 37, 773, DateTimeKind.Local).AddTicks(1371), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0f047949-61da-4091-aaa7-455c9b5d2080"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("11a4536f-3a4e-4ab8-8fa7-646c61fb7747"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13f30d07-5a50-49ef-8d30-60817942b61f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("23bcfc03-e6a8-4f0e-92c7-21de9bf97f2d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("36186670-2ea7-42b1-9787-8dec4c642a7c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("379a2d86-2971-4d35-b2dc-5423f53441c7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4f2f0b53-2d62-4206-aa68-0803a512bf5c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8cc92510-521b-4c55-beb8-6ed90361cae2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b932caed-0124-45a3-8293-33d94f90d44e"));

            migrationBuilder.RenameColumn(
                name: "PermanentPreservationArea",
                table: "TaxPayerDeclarations",
                newName: "EnvironmentalPreservation");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3901a2a1-60cf-4eac-b696-9f94c968cc23"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(715), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("4055ed78-b76f-4463-b223-bc6639311e89"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(706), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4e3e942e-6391-4e06-97b1-ff3a5f25bbed"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(707), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5136f9a3-ccc3-41be-a608-129d06ed9b53"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(710), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7bc0cb80-e6f7-428d-8b9b-d483271ab011"), "[[description]]", null, null, new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(709), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("8a1a4d6b-b4cc-40e2-923c-6f08b710f84c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(712), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("90c1d470-19e1-48c5-a997-b24d387cacfb"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(689), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ae921059-1a81-4442-8936-4fd48965fce6"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(705), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f8d03850-4d3b-4919-b841-7744ebf7df1e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 18, 21, 47, 52, 489, DateTimeKind.Local).AddTicks(703), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

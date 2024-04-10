using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RevenueM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("08257c12-0dd2-4a49-848f-84f267aa9ddd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("120c7eb6-b67c-4778-a2da-7a547719e5a9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4713d68d-e174-421a-9b30-8076aa94d661"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8edc339b-3e27-4e93-8f8b-4817bca5b170"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aedbe384-0001-49de-aabc-fc28af8a7381"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c0f9af12-35fa-4f1a-9d2a-44b789c925ad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c25d0834-4d1a-434a-8271-1155c95c9090"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c67c3d7b-82b0-4e1f-996d-c95d2c05eec2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c9ddf02b-47cb-45b3-b65d-f537db146266"));

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredictedDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredictedUpdated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PredictedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Collection = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revenues");

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

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("08257c12-0dd2-4a49-848f-84f267aa9ddd"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1275), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("120c7eb6-b67c-4778-a2da-7a547719e5a9"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1292), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4713d68d-e174-421a-9b30-8076aa94d661"), "[[person-document]]", "Document", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1291), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8edc339b-3e27-4e93-8f8b-4817bca5b170"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1297), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("aedbe384-0001-49de-aabc-fc28af8a7381"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1288), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c0f9af12-35fa-4f1a-9d2a-44b789c925ad"), "[[person-name]]", "Name", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1290), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c25d0834-4d1a-434a-8271-1155c95c9090"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1300), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c67c3d7b-82b0-4e1f-996d-c95d2c05eec2"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1295), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c9ddf02b-47cb-45b3-b65d-f537db146266"), "[[description]]", null, null, new DateTime(2023, 3, 2, 12, 8, 29, 926, DateTimeKind.Local).AddTicks(1294), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }
    }
}

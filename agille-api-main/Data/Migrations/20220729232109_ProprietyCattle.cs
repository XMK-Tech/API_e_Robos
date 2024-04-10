using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ProprietyCattle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("01d8fe9a-f022-4266-82f0-156cbc421dfe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4818eab3-016a-4d3e-95de-7ae8ee0cb8ea"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6c37a256-c005-4035-8b40-c0d8cd55c61f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("72b16edf-45c8-42ee-af78-f4331e3da2ec"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("85a9d4d3-e95f-457e-893e-7639f1acaa2b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc67d427-a22f-48f7-8fd4-ac476d2a5720"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c2df0f4b-c10d-4efa-9846-fa85b63f8c27"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e5cfd3c0-9bad-4314-b178-ce98f25e38c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f787fcc2-5ee9-4a15-8a00-e7e045188d3c"));

            migrationBuilder.CreateTable(
                name: "ProprietyCattles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProprietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cattle = table.Column<int>(type: "int", nullable: false),
                    Buffalos = table.Column<int>(type: "int", nullable: false),
                    Equine = table.Column<int>(type: "int", nullable: false),
                    Sheep = table.Column<int>(type: "int", nullable: false),
                    Goats = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietyCattles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProprietyCattles_Propriety_ProprietyId",
                        column: x => x.ProprietyId,
                        principalTable: "Propriety",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1105c695-98a7-477c-af8f-e12e53ed1b60"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5588), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("13925444-23b6-4e8f-99a3-e5b50fd85d43"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5574), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c884b14-e24c-493a-b03f-adb35c410b9b"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5571), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("49824613-1efd-41eb-a269-82947516d470"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5576), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5ccaf6cf-8490-48bc-b55e-1d6890c95021"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5552), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("aef11209-8a5f-4fad-be22-7dfd98e24da9"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5590), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c767c0c8-6f1d-4c88-a7dc-7df35b7c4b5b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5587), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d725e001-0841-4220-bcec-e5b0448ba131"), "[[description]]", null, null, new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5586), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f301dc09-0ca1-4d29-8fba-f52a8b4c656b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5573), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyCattles_ProprietyId",
                table: "ProprietyCattles",
                column: "ProprietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProprietyCattles");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1105c695-98a7-477c-af8f-e12e53ed1b60"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13925444-23b6-4e8f-99a3-e5b50fd85d43"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c884b14-e24c-493a-b03f-adb35c410b9b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49824613-1efd-41eb-a269-82947516d470"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ccaf6cf-8490-48bc-b55e-1d6890c95021"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aef11209-8a5f-4fad-be22-7dfd98e24da9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c767c0c8-6f1d-4c88-a7dc-7df35b7c4b5b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d725e001-0841-4220-bcec-e5b0448ba131"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f301dc09-0ca1-4d29-8fba-f52a8b4c656b"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("01d8fe9a-f022-4266-82f0-156cbc421dfe"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(80), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4818eab3-016a-4d3e-95de-7ae8ee0cb8ea"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(81), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6c37a256-c005-4035-8b40-c0d8cd55c61f"), "[[description]]", null, null, new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(77), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("72b16edf-45c8-42ee-af78-f4331e3da2ec"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 946, DateTimeKind.Local).AddTicks(9974), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("85a9d4d3-e95f-457e-893e-7639f1acaa2b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 946, DateTimeKind.Local).AddTicks(9991), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bc67d427-a22f-48f7-8fd4-ac476d2a5720"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 946, DateTimeKind.Local).AddTicks(9989), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c2df0f4b-c10d-4efa-9846-fa85b63f8c27"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(76), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e5cfd3c0-9bad-4314-b178-ce98f25e38c8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(82), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f787fcc2-5ee9-4a15-8a00-e7e045188d3c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 29, 14, 31, 19, 947, DateTimeKind.Local).AddTicks(65), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

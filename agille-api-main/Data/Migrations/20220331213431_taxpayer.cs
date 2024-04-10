using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class taxpayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1849e218-0c45-4522-a5cc-1fe39b3dd7a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2237f16d-9b60-47fe-9be3-23eb30429f4d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("289626d7-446c-448c-8c7d-69f9a56726ad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8caba80c-5b02-4990-8fda-aa3d072e469f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ab8591bc-e1fd-4687-b37f-a5cf4177c791"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf4d46bc-1042-4739-afb2-bae49afe5fda"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec33f229-9ab1-40f4-b19e-e109c03d0a5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f7a0e9ce-f2af-419d-8b4e-862d6f7379d5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fef2d094-967d-4bbd-8cf4-08eef3af8b62"));

            migrationBuilder.CreateTable(
                name: "Taxpayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    JuridicalPersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxpayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxpayers_JuridicalPerson_JuridicalPersonId",
                        column: x => x.JuridicalPersonId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxpayers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("db22c6db-420f-4d1c-823d-8e833ddc4757"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 195, DateTimeKind.Local).AddTicks(9889), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f58ceda8-6638-4cae-bc9f-2c42936c791d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2059), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("29535f85-f637-43df-a142-34e34ee55bd8"), "[[person-name]]", "Name", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2144), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7691fca6-972c-407a-bee0-c13b40ea79a8"), "[[person-document]]", "Document", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2147), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fd28330d-8707-4055-b631-8ef8b3559014"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2149), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3e60430-b36b-4ae3-843b-ed6008e60383"), "[[description]]", null, null, new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2151), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("16d27fce-c22f-4c3b-b062-cf24310de142"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2159), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("dcc18eff-994e-45cd-a89c-38401232f5d9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2161), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d4929947-e532-43ae-ad8b-92096a7a02fd"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 3, 31, 18, 34, 31, 197, DateTimeKind.Local).AddTicks(2163), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxpayers_JuridicalPersonId",
                table: "Taxpayers",
                column: "JuridicalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxpayers_UserId",
                table: "Taxpayers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxpayers");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("16d27fce-c22f-4c3b-b062-cf24310de142"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("29535f85-f637-43df-a142-34e34ee55bd8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7691fca6-972c-407a-bee0-c13b40ea79a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3e60430-b36b-4ae3-843b-ed6008e60383"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d4929947-e532-43ae-ad8b-92096a7a02fd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db22c6db-420f-4d1c-823d-8e833ddc4757"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dcc18eff-994e-45cd-a89c-38401232f5d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f58ceda8-6638-4cae-bc9f-2c42936c791d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fd28330d-8707-4055-b631-8ef8b3559014"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("8caba80c-5b02-4990-8fda-aa3d072e469f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 729, DateTimeKind.Local).AddTicks(2874), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("289626d7-446c-448c-8c7d-69f9a56726ad"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7468), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fef2d094-967d-4bbd-8cf4-08eef3af8b62"), "[[person-name]]", "Name", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7552), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1849e218-0c45-4522-a5cc-1fe39b3dd7a3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7556), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bf4d46bc-1042-4739-afb2-bae49afe5fda"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7558), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f7a0e9ce-f2af-419d-8b4e-862d6f7379d5"), "[[description]]", null, null, new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7560), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("2237f16d-9b60-47fe-9be3-23eb30429f4d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7562), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ab8591bc-e1fd-4687-b37f-a5cf4177c791"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7564), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ec33f229-9ab1-40f4-b19e-e109c03d0a5d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 3, 30, 18, 59, 38, 730, DateTimeKind.Local).AddTicks(7576), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class JurificalPersonNotices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09b4f278-383d-4af7-bac4-9091af648d19"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1101be31-2dc3-4fe0-a82c-0f631b037461"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1a10ddd0-5e3b-4e3d-b6d3-4f003c9af896"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("356eefdd-1dd0-48ff-a0df-75ea6bbe0bda"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7923a17a-cd6a-4398-ac66-2a3de50c4e3d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("93cd57c7-1e4e-430a-a3cc-e2f672ecd846"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9f78f1a5-0b05-4ea9-91b6-677a76f0146f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b46f2ac7-fc98-480e-9857-9e22b9d1d262"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f3295492-26bd-4310-bbed-b9c60299b066"));

            migrationBuilder.CreateTable(
                name: "JuridicalPersonNotices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    NoticeId = table.Column<Guid>(nullable: false),
                    JuridicalPersonId = table.Column<Guid>(nullable: false),
                    WasViewed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicalPersonNotices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridicalPersonNotices_JuridicalPerson_JuridicalPersonId",
                        column: x => x.JuridicalPersonId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridicalPersonNotices_Notices_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPersonNotices_JuridicalPersonId",
                table: "JuridicalPersonNotices",
                column: "JuridicalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPersonNotices_NoticeId",
                table: "JuridicalPersonNotices",
                column: "NoticeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuridicalPersonNotices");

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

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("93cd57c7-1e4e-430a-a3cc-e2f672ecd846"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 714, DateTimeKind.Local).AddTicks(9153), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("09b4f278-383d-4af7-bac4-9091af648d19"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8168), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("356eefdd-1dd0-48ff-a0df-75ea6bbe0bda"), "[[person-name]]", "Name", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8247), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b46f2ac7-fc98-480e-9857-9e22b9d1d262"), "[[person-document]]", "Document", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8250), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f3295492-26bd-4310-bbed-b9c60299b066"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8252), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1a10ddd0-5e3b-4e3d-b6d3-4f003c9af896"), "[[description]]", null, null, new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8255), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("1101be31-2dc3-4fe0-a82c-0f631b037461"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8257), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7923a17a-cd6a-4398-ac66-2a3de50c4e3d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8265), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9f78f1a5-0b05-4ea9-91b6-677a76f0146f"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 3, 7, 16, 4, 41, 715, DateTimeKind.Local).AddTicks(8267), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

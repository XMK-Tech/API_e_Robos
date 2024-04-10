using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CrawlerFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c1e2953-4f43-4d85-802a-0e10aca6cf11"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e4c2228-df4f-4254-b1a8-cede94ffb960"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ab0f679-d5a2-4a47-899f-8c88161f71ce"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7fbd3e57-141f-4fbd-9fe0-6a6061df26b7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("88998412-5a45-44c6-9c57-305dbb657943"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97b0789e-eaf5-4818-a49b-80fd366e5a16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c27297bd-bedb-4182-93b2-9d19f3780430"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cb9ca6ef-7f3d-4278-a8dc-5ba6db9ee28d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cdc5a020-e97a-4dca-8bf1-e98a8fbc7d82"));

            migrationBuilder.CreateTable(
                name: "CrawlerFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WasImported = table.Column<bool>(type: "bit", nullable: false),
                    DataDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Command = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Competence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrawlerFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrawlerFile_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0d9f85f3-42b6-4424-a396-9031d95cd6a8"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3435), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("20db6234-fb6d-4594-8023-dc8a4624cdda"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3438), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("2645eaf2-a5b0-41af-b486-74a5e75c65f2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3432), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("39471a10-041c-45dc-b7f9-cee6bab79759"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3412), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("4d47284d-ef51-46ec-8f19-39cb1df1a735"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3414), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("514acc24-c235-4e81-83ad-343aba9a25d4"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3415), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("55952d31-f1e4-45b9-affc-21a743d67612"), "[[description]]", null, null, new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3434), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("97d454a9-432d-4641-9e03-fcf378f29438"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3397), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b7859d0e-6b76-4a81-97be-8ca5c21577fd"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3436), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrawlerFile_AttachmentId",
                table: "CrawlerFile",
                column: "AttachmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrawlerFile");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0d9f85f3-42b6-4424-a396-9031d95cd6a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("20db6234-fb6d-4594-8023-dc8a4624cdda"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2645eaf2-a5b0-41af-b486-74a5e75c65f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("39471a10-041c-45dc-b7f9-cee6bab79759"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4d47284d-ef51-46ec-8f19-39cb1df1a735"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("514acc24-c235-4e81-83ad-343aba9a25d4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55952d31-f1e4-45b9-affc-21a743d67612"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97d454a9-432d-4641-9e03-fcf378f29438"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b7859d0e-6b76-4a81-97be-8ca5c21577fd"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3c1e2953-4f43-4d85-802a-0e10aca6cf11"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8618), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3e4c2228-df4f-4254-b1a8-cede94ffb960"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8622), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7ab0f679-d5a2-4a47-899f-8c88161f71ce"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8621), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7fbd3e57-141f-4fbd-9fe0-6a6061df26b7"), "[[description]]", null, null, new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8620), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("88998412-5a45-44c6-9c57-305dbb657943"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8617), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("97b0789e-eaf5-4818-a49b-80fd366e5a16"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8614), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c27297bd-bedb-4182-93b2-9d19f3780430"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8626), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("cb9ca6ef-7f3d-4278-a8dc-5ba6db9ee28d"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8599), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cdc5a020-e97a-4dca-8bf1-e98a8fbc7d82"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 17, 9, 57, 38, 707, DateTimeKind.Local).AddTicks(8615), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CollectionM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("05c8c972-59a6-4342-ba3e-c6a4c5cc6bf9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("11205a66-375b-4ab8-b54f-6f3ede99f797"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2465125a-6b31-4892-8f35-ae2794582f94"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("57f88f3b-7340-4ee7-9812-6e0ffaa63744"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("614514eb-499b-4c45-bdde-d1a01440a8b7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6adb52af-70d6-498b-ab84-6e2c7549ec42"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("961b8c1a-c17c-437c-9b91-03adc94166f0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c1ddeae9-a49b-4cfd-bb7a-0b3704dc6799"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db79bfb8-3e3f-4b40-9805-0cb0dc03c6da"));

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SelicValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollectionAttachments_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("96377bd3-9cc1-4951-a717-8e2287fcca59"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5022), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("979b5aa7-93c2-411a-931a-447810711b5d"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5031), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("98271e65-f9d8-44c1-9639-66956bc91e51"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5034), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("9fcb1db9-9876-4bdc-bf70-f573bf5b2379"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5023), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a0fdbc00-4ec9-4c9a-91a6-81e659d3e7f2"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5007), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a6b11d9d-33dd-41c7-b126-2e9797193ede"), "[[description]]", null, null, new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5030), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("deea7f6d-b56a-4f1b-ba6d-15742d6a2282"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5033), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ea4a1764-f555-4e26-8051-78b5bfc24c74"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(4991), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f0ea5392-3dd7-4e0d-81be-f66e606c5bbc"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 8, 7, 23, 36, 71, DateTimeKind.Local).AddTicks(5024), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionAttachments_AttachmentId",
                table: "CollectionAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionAttachments_CollectionId",
                table: "CollectionAttachments",
                column: "CollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionAttachments");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("96377bd3-9cc1-4951-a717-8e2287fcca59"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("979b5aa7-93c2-411a-931a-447810711b5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("98271e65-f9d8-44c1-9639-66956bc91e51"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fcb1db9-9876-4bdc-bf70-f573bf5b2379"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a0fdbc00-4ec9-4c9a-91a6-81e659d3e7f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a6b11d9d-33dd-41c7-b126-2e9797193ede"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("deea7f6d-b56a-4f1b-ba6d-15742d6a2282"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ea4a1764-f555-4e26-8051-78b5bfc24c74"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f0ea5392-3dd7-4e0d-81be-f66e606c5bbc"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("05c8c972-59a6-4342-ba3e-c6a4c5cc6bf9"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2451), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("11205a66-375b-4ab8-b54f-6f3ede99f797"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2454), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2465125a-6b31-4892-8f35-ae2794582f94"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2450), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("57f88f3b-7340-4ee7-9812-6e0ffaa63744"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2466), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("614514eb-499b-4c45-bdde-d1a01440a8b7"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2459), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6adb52af-70d6-498b-ab84-6e2c7549ec42"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2447), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("961b8c1a-c17c-437c-9b91-03adc94166f0"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2457), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c1ddeae9-a49b-4cfd-bb7a-0b3704dc6799"), "[[description]]", null, null, new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2455), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("db79bfb8-3e3f-4b40-9805-0cb0dc03c6da"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 4, 12, 6, 45, 738, DateTimeKind.Local).AddTicks(2415), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

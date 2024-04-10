using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ExpenseM : Migration
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
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Favored = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("01aaf7b5-173b-41cf-ae41-d01a05ea8b62"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2953), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6686982f-e31d-4cc5-93de-7d5f09a5b2f1"), "[[description]]", null, null, new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2958), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("81654942-364b-405c-ad89-ae2d1e4b46f2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2955), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("889ee450-5784-4d84-a4ab-7bcf1bff6ddb"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2972), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8b7fc5df-60b8-48d5-bef8-a3fd9bce78ab"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2950), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("99e9c654-a029-479b-a6d4-57ee87fd8327"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2931), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a93241d7-935f-4e18-9a4d-cef6f0f9b0a8"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2948), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("bbb5ae27-7e91-4110-a023-49e714383da9"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2974), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("efa29ce3-d34d-40d2-bb27-d4dd4b178f23"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 8, 8, 53, 7, 354, DateTimeKind.Local).AddTicks(2969), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseAttachments_AttachmentId",
                table: "ExpenseAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseAttachments_ExpenseId",
                table: "ExpenseAttachments",
                column: "ExpenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseAttachments");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("01aaf7b5-173b-41cf-ae41-d01a05ea8b62"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6686982f-e31d-4cc5-93de-7d5f09a5b2f1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("81654942-364b-405c-ad89-ae2d1e4b46f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("889ee450-5784-4d84-a4ab-7bcf1bff6ddb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8b7fc5df-60b8-48d5-bef8-a3fd9bce78ab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("99e9c654-a029-479b-a6d4-57ee87fd8327"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a93241d7-935f-4e18-9a4d-cef6f0f9b0a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bbb5ae27-7e91-4110-a023-49e714383da9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("efa29ce3-d34d-40d2-bb27-d4dd4b178f23"));

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

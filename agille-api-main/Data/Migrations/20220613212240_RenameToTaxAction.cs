using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RenameToTaxAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeHistorics");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25a06c7a-1b34-40b2-a07b-104c3c9f1ca4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30bbc5ad-ba3e-4e92-84d8-b8669be8d12e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3608fef0-3e5e-4491-8c80-4b098ef4c575"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("501ab48d-77a2-49d9-bb95-ffbb74b11e58"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ed8570c-8ac0-4fa0-89de-c55d8b9a7b4a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fdd8631-8cf6-4a9f-b4ac-fdb54b674437"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c5a7268d-8a07-43bc-8230-73bcb8770b4c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e5d261e1-f5a0-49ee-8866-fe0d5c42e6e7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffd5eee9-ab13-4374-a3c8-0b413615ca76"));

            migrationBuilder.CreateTable(
                name: "TaxActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    StatusHasChanged = table.Column<bool>(type: "bit", nullable: false),
                    FromStatus = table.Column<int>(type: "int", nullable: true),
                    ToStatus = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoticeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxActions_Notices_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notices",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("002240e1-c61b-4b96-9430-f395d93014cd"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2970), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("32247013-dd49-4ca6-889a-32fed5211d77"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2972), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("71668ac2-4a9d-450a-a203-fc7a880f1614"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2988), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9849e75a-9f1a-4283-9a91-92f0176a4ae0"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2989), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a255eff4-5a19-426a-ae65-80409fc23318"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2991), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("af536b8b-ca97-43b8-a13c-8635d206e5d8"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2955), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ca919442-2d88-4a99-b1e6-c0d23b49eab6"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2968), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("dc249cd1-12af-49d6-89c5-35626656e79e"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2973), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f48a859f-4540-438e-bc9e-e8ca0b90647a"), "[[description]]", null, null, new DateTime(2022, 6, 13, 18, 22, 38, 702, DateTimeKind.Local).AddTicks(2986), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxActions_NoticeId",
                table: "TaxActions",
                column: "NoticeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxActions");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("002240e1-c61b-4b96-9430-f395d93014cd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("32247013-dd49-4ca6-889a-32fed5211d77"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("71668ac2-4a9d-450a-a203-fc7a880f1614"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9849e75a-9f1a-4283-9a91-92f0176a4ae0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a255eff4-5a19-426a-ae65-80409fc23318"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("af536b8b-ca97-43b8-a13c-8635d206e5d8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ca919442-2d88-4a99-b1e6-c0d23b49eab6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dc249cd1-12af-49d6-89c5-35626656e79e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f48a859f-4540-438e-bc9e-e8ca0b90647a"));

            migrationBuilder.CreateTable(
                name: "NoticeHistorics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoticeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    FromStatus = table.Column<int>(type: "int", nullable: true),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusHasChanged = table.Column<bool>(type: "bit", nullable: false),
                    ToStatus = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeHistorics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeHistorics_Notices_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notices",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("25a06c7a-1b34-40b2-a07b-104c3c9f1ca4"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7332), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("30bbc5ad-ba3e-4e92-84d8-b8669be8d12e"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7334), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3608fef0-3e5e-4491-8c80-4b098ef4c575"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7318), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("501ab48d-77a2-49d9-bb95-ffbb74b11e58"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7336), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5ed8570c-8ac0-4fa0-89de-c55d8b9a7b4a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7351), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9fdd8631-8cf6-4a9f-b4ac-fdb54b674437"), "[[description]]", null, null, new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7350), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c5a7268d-8a07-43bc-8230-73bcb8770b4c"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7355), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("e5d261e1-f5a0-49ee-8866-fe0d5c42e6e7"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7348), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ffd5eee9-ab13-4374-a3c8-0b413615ca76"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7353), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeHistorics_NoticeId",
                table: "NoticeHistorics",
                column: "NoticeId");
        }
    }
}

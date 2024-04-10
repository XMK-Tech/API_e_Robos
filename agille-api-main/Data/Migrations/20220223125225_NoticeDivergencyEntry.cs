using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeDivergencyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivergencyEntry_Notices_NoticeId",
                table: "DivergencyEntry");

            migrationBuilder.DropIndex(
                name: "IX_DivergencyEntry_NoticeId",
                table: "DivergencyEntry");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("262584f8-c739-402a-89bc-cea098923d55"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2a6728ba-4735-47f7-97a0-f3fadfa0f51e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c047b77-f73b-4e8e-bc5f-5778cf71474f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4e11a7dd-314c-4db1-a25c-938f9bc5fff0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("82667613-3a6c-4b7d-9954-fd091ce43b82"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a71060b0-e9db-4543-b898-5746362d3a3d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cbfd1e7f-e5d5-4f22-bd24-290667f2e2da"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e3174d5d-3bb5-4751-908b-b7fccdf1907c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e4c0ee47-bb75-477b-8d70-6398414f026b"));

            migrationBuilder.DropColumn(
                name: "NoticeId",
                table: "DivergencyEntry");

            migrationBuilder.CreateTable(
                name: "NoticeDivergencyEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    NoticeId = table.Column<Guid>(nullable: false),
                    DivergencyEntryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeDivergencyEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeDivergencyEntries_DivergencyEntry_DivergencyEntryId",
                        column: x => x.DivergencyEntryId,
                        principalTable: "DivergencyEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeDivergencyEntries_Notices_NoticeId",
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
                    { new Guid("c027379a-306a-447b-be4f-8a572ff7f461"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 662, DateTimeKind.Local).AddTicks(43), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("09154846-a0b3-4662-9119-f560f11f2048"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(702), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("be6f6f0f-fa04-4fb9-8a3b-c50f4c4f74b4"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(790), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fafe5663-5669-47c4-93cd-3b143881129a"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(794), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b69eddf2-648d-4fcf-aa65-f37d1e7c8fc1"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(797), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a5b4fcee-2119-49aa-9c65-d618dc2a244b"), "[[description]]", null, null, new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(799), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d01ca534-7ee1-40a8-90d4-867c23e9dd65"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(812), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("34a7c493-8092-4b6a-b32e-6b76e7842042"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(815), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("09e7faf0-b7ff-49c0-a5e9-2d8b1438b2cf"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(817), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeDivergencyEntries_DivergencyEntryId",
                table: "NoticeDivergencyEntries",
                column: "DivergencyEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeDivergencyEntries_NoticeId",
                table: "NoticeDivergencyEntries",
                column: "NoticeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeDivergencyEntries");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09154846-a0b3-4662-9119-f560f11f2048"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09e7faf0-b7ff-49c0-a5e9-2d8b1438b2cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("34a7c493-8092-4b6a-b32e-6b76e7842042"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a5b4fcee-2119-49aa-9c65-d618dc2a244b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b69eddf2-648d-4fcf-aa65-f37d1e7c8fc1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("be6f6f0f-fa04-4fb9-8a3b-c50f4c4f74b4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c027379a-306a-447b-be4f-8a572ff7f461"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d01ca534-7ee1-40a8-90d4-867c23e9dd65"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fafe5663-5669-47c4-93cd-3b143881129a"));

            migrationBuilder.AddColumn<Guid>(
                name: "NoticeId",
                table: "DivergencyEntry",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("e4c0ee47-bb75-477b-8d70-6398414f026b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 344, DateTimeKind.Local).AddTicks(7355), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2a6728ba-4735-47f7-97a0-f3fadfa0f51e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(7849), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a71060b0-e9db-4543-b898-5746362d3a3d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8102), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cbfd1e7f-e5d5-4f22-bd24-290667f2e2da"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8107), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("262584f8-c739-402a-89bc-cea098923d55"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8109), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e3174d5d-3bb5-4751-908b-b7fccdf1907c"), "[[description]]", null, null, new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8112), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("4c047b77-f73b-4e8e-bc5f-5778cf71474f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8114), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("82667613-3a6c-4b7d-9954-fd091ce43b82"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8116), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4e11a7dd-314c-4db1-a25c-938f9bc5fff0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 23, 9, 30, 25, 345, DateTimeKind.Local).AddTicks(8125), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivergencyEntry_NoticeId",
                table: "DivergencyEntry",
                column: "NoticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DivergencyEntry_Notices_NoticeId",
                table: "DivergencyEntry",
                column: "NoticeId",
                principalTable: "Notices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

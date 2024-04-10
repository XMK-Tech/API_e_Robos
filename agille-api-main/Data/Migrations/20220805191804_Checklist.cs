using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class Checklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14131fb6-8354-4452-bd56-5a2ac3353e5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3ee8d2b3-d1e1-44d8-9c52-1878aca850ef"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55206045-c835-497a-af2f-5e07f35425d2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("57de6c63-79e5-458f-be88-6c8a15877a7a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5c059f80-0053-43a6-a927-201e499d2e4c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("77d58104-d412-4d84-bffa-3d9e394130c7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("84c2e815-77fe-4d27-b81f-42cf02f61611"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("951bb711-a409-4aab-a68b-1a92d4fb4e40"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("df007222-0454-49ff-b51c-f342abd80d24"));

            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("12316408-e78a-484c-90bc-9bbb2ea11239"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4974), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("21c1f132-e76e-4660-a86c-a32a3e6589ff"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4975), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("29838791-660f-4221-900c-aedcce02f85f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4943), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("37b40fa7-631e-4736-9d31-1a15b4af36b3"), "[[description]]", null, null, new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4972), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3f414d6e-2f1f-47be-ae24-e56439a3f466"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4969), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("615b37a4-c64e-49d5-92ba-c9213fb7dd16"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4968), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bf59da97-12a9-440f-b4b6-3756c18cb815"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4971), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d8a272b2-c635-4ec4-ac3b-aa52c080e839"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4957), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fd7d2869-e1c5-4cd7-9880-97f98e3ec3f4"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 5, 16, 18, 2, 944, DateTimeKind.Local).AddTicks(4977), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checklists");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("12316408-e78a-484c-90bc-9bbb2ea11239"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21c1f132-e76e-4660-a86c-a32a3e6589ff"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("29838791-660f-4221-900c-aedcce02f85f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("37b40fa7-631e-4736-9d31-1a15b4af36b3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3f414d6e-2f1f-47be-ae24-e56439a3f466"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("615b37a4-c64e-49d5-92ba-c9213fb7dd16"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf59da97-12a9-440f-b4b6-3756c18cb815"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d8a272b2-c635-4ec4-ac3b-aa52c080e839"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fd7d2869-e1c5-4cd7-9880-97f98e3ec3f4"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("14131fb6-8354-4452-bd56-5a2ac3353e5f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1615), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3ee8d2b3-d1e1-44d8-9c52-1878aca850ef"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1579), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("55206045-c835-497a-af2f-5e07f35425d2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1601), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("57de6c63-79e5-458f-be88-6c8a15877a7a"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1617), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5c059f80-0053-43a6-a927-201e499d2e4c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1598), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("77d58104-d412-4d84-bffa-3d9e394130c7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1616), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("84c2e815-77fe-4d27-b81f-42cf02f61611"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1596), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("951bb711-a409-4aab-a68b-1a92d4fb4e40"), "[[description]]", null, null, new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1603), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("df007222-0454-49ff-b51c-f342abd80d24"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1600), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

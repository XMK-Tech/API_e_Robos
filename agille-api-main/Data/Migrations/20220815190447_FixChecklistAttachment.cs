using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixChecklistAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistAttachments_Checklists_ChecklistId1",
                table: "ChecklistAttachments");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistAttachments_ChecklistId1",
                table: "ChecklistAttachments");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1a6ba89d-d3b2-430c-a231-0460619f3b48"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2b6ed129-c85c-42e8-b655-9743ba070ef3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2dcebba4-cc0d-44b6-b1c0-682ca15cb314"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("312dc115-6c19-487e-af0f-8fa27971a69a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("391859db-2dbc-47aa-ab36-e93299b4248a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8945c094-4df0-4b43-a24d-0277243b8a00"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaf691d3-dad7-427b-97c8-0fe64f50ae94"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b0455493-42f5-46e2-b1fb-8f3026f607fa"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d255b231-533e-41c9-89b8-6e4a10b76159"));

            migrationBuilder.DropColumn(
                name: "ChecklistId1",
                table: "ChecklistAttachments");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0b936859-e3cf-4776-9179-65fc64452c39"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7244), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c12d494-eab2-4517-ada5-031c2660152e"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7228), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("3ee996d1-bddf-4e7a-a4e9-8593652509d7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7249), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("59601d07-2193-4b76-bb62-9b8d8c591957"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7245), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3fa8ca8-5765-4c5a-9958-cb079bcfd20b"), "[[description]]", null, null, new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7248), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b4efdecf-623b-4b4b-b115-0d122e869f11"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7251), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b82f94be-375c-4ec0-bba8-10ccad2235ef"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7247), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c8585c34-750e-4a34-8acf-0e8b215dd1e9"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7242), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c8c7fd40-bcf2-4193-a0a1-9a60c766de58"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 15, 16, 4, 45, 708, DateTimeKind.Local).AddTicks(7254), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0b936859-e3cf-4776-9179-65fc64452c39"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c12d494-eab2-4517-ada5-031c2660152e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3ee996d1-bddf-4e7a-a4e9-8593652509d7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("59601d07-2193-4b76-bb62-9b8d8c591957"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3fa8ca8-5765-4c5a-9958-cb079bcfd20b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b4efdecf-623b-4b4b-b115-0d122e869f11"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b82f94be-375c-4ec0-bba8-10ccad2235ef"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c8585c34-750e-4a34-8acf-0e8b215dd1e9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c8c7fd40-bcf2-4193-a0a1-9a60c766de58"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChecklistId1",
                table: "ChecklistAttachments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1a6ba89d-d3b2-430c-a231-0460619f3b48"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(2996), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2b6ed129-c85c-42e8-b655-9743ba070ef3"), "[[description]]", null, null, new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(3006), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("2dcebba4-cc0d-44b6-b1c0-682ca15cb314"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(2993), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("312dc115-6c19-487e-af0f-8fa27971a69a"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(2994), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("391859db-2dbc-47aa-ab36-e93299b4248a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(3010), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8945c094-4df0-4b43-a24d-0277243b8a00"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(3008), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("aaf691d3-dad7-427b-97c8-0fe64f50ae94"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(2989), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b0455493-42f5-46e2-b1fb-8f3026f607fa"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(3011), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("d255b231-533e-41c9-89b8-6e4a10b76159"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 15, 15, 43, 43, 915, DateTimeKind.Local).AddTicks(2954), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAttachments_ChecklistId1",
                table: "ChecklistAttachments",
                column: "ChecklistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistAttachments_Checklists_ChecklistId1",
                table: "ChecklistAttachments",
                column: "ChecklistId1",
                principalTable: "Checklists",
                principalColumn: "Id");
        }
    }
}

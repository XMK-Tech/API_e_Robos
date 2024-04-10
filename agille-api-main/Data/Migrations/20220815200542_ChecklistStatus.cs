using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ChecklistStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "Checklists",
                newName: "Justification");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Checklists",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("03d77956-4cfd-41e1-8f02-9901ad78faef"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(902), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("2932c19f-54a1-477b-b03f-ab65a5080cdd"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(856), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("36101509-66da-4ad0-a046-1a500eebe72c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(904), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("58d779e1-6fcd-4653-838f-56810a02bd0a"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(854), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("76dd079d-dc1f-426c-a3a3-4b71a53f834c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(853), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("968b0358-c863-40b0-ad46-0e4e96dff995"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(841), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b1b7f7ea-e4f4-4287-8509-c3b083218af3"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(905), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("deb417be-81b1-47c8-8da5-5de9394cc154"), "[[description]]", null, null, new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(900), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("e244633e-687e-4e8c-9087-50068a03a43f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(825), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Justification",
                table: "Checklists",
                newName: "Identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Checklists",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}

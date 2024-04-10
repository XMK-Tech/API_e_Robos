using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeReturnProtocol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "ReturnProtocolId",
                table: "Notices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReturnProtocols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnProtocols", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1c9dccb2-a496-42c9-af80-12957ecbd8a0"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4039), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("3a9d4850-2f4c-4b01-80bc-df697b6e943c"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4069), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("49fd27d4-2980-4113-b4ce-073a083e47a8"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4042), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("59267764-a5ea-4d17-916e-a333515bbadf"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4016), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5d5af863-a672-4e4b-9a9f-05a5262f309e"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4043), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7646e183-3313-48bf-8721-2464c350e04c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4046), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9482fc44-7bce-4894-b8c2-c6fedf93c908"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4041), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a5128c46-290b-4e91-a919-ab8c2129fa03"), "[[description]]", null, null, new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4045), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b7d6c574-06fe-466d-97ac-cc8f62b95026"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 19, 22, 34, 168, DateTimeKind.Local).AddTicks(4068), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_ReturnProtocolId",
                table: "Notices",
                column: "ReturnProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_ReturnProtocols_ReturnProtocolId",
                table: "Notices",
                column: "ReturnProtocolId",
                principalTable: "ReturnProtocols",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_ReturnProtocols_ReturnProtocolId",
                table: "Notices");

            migrationBuilder.DropTable(
                name: "ReturnProtocols");

            migrationBuilder.DropIndex(
                name: "IX_Notices_ReturnProtocolId",
                table: "Notices");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1c9dccb2-a496-42c9-af80-12957ecbd8a0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3a9d4850-2f4c-4b01-80bc-df697b6e943c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49fd27d4-2980-4113-b4ce-073a083e47a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("59267764-a5ea-4d17-916e-a333515bbadf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5d5af863-a672-4e4b-9a9f-05a5262f309e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7646e183-3313-48bf-8721-2464c350e04c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9482fc44-7bce-4894-b8c2-c6fedf93c908"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a5128c46-290b-4e91-a919-ab8c2129fa03"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b7d6c574-06fe-466d-97ac-cc8f62b95026"));

            migrationBuilder.DropColumn(
                name: "ReturnProtocolId",
                table: "Notices");

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
        }
    }
}

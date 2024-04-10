using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class Notice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("16c78fc9-203c-4115-af73-3bb569592ba5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1a36902b-4bda-4d00-be58-3c83177b27d8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25a0bd73-dedc-48ae-8162-380e834e4c2a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3bc6e1a6-d7c0-4b2d-8f3b-cd0ab93c4291"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b11d0dc-68a7-437e-9573-5575041bdd46"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7fe01e9e-7e07-4ccf-a328-768d9c4a668b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("801d0244-a7a3-45aa-944d-36966b782b62"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed386730-f3fd-48b4-9cd7-910e03deddb8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ee259f00-26f0-4264-8684-52c01f040016"));

            migrationBuilder.AddColumn<Guid>(
                name: "NoticeId",
                table: "DivergencyEntry",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    TemplateId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notices_NoticeTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "NoticeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notices_TemplateId",
                table: "Notices",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DivergencyEntry_Notices_NoticeId",
                table: "DivergencyEntry",
                column: "NoticeId",
                principalTable: "Notices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivergencyEntry_Notices_NoticeId",
                table: "DivergencyEntry");

            migrationBuilder.DropTable(
                name: "Notices");

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

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("ee259f00-26f0-4264-8684-52c01f040016"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 67, DateTimeKind.Local).AddTicks(562), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("801d0244-a7a3-45aa-944d-36966b782b62"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1585), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6b11d0dc-68a7-437e-9573-5575041bdd46"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1788), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ed386730-f3fd-48b4-9cd7-910e03deddb8"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1853), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("16c78fc9-203c-4115-af73-3bb569592ba5"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1859), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7fe01e9e-7e07-4ccf-a328-768d9c4a668b"), "[[description]]", null, null, new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1864), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3bc6e1a6-d7c0-4b2d-8f3b-cd0ab93c4291"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1870), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("25a0bd73-dedc-48ae-8162-380e834e4c2a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1875), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("1a36902b-4bda-4d00-be58-3c83177b27d8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 21, 23, 43, 30, 70, DateTimeKind.Local).AddTicks(1880), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

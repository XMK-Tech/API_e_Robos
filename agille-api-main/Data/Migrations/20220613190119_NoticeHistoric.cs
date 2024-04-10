using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeHistoric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("229a444c-ff4b-475e-a398-a9b9dc18e792"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("36a9a977-1495-435c-97f1-661458aea733"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("48660ec5-d0fc-4ff4-9cdb-e8ad995399c0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("648c61dd-f62d-454f-93d9-04f6f6af4e6f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b356fbb-7ba8-428a-8b86-6175fe6df4f8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bb668874-f69d-41d8-8e60-1a43da424d09"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c13df26b-7565-4ddd-a612-b8af050433fa"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cc5f4960-722d-498b-9e0f-a06582dcd554"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f2f0f4bc-a67b-4c7c-bccb-1a5755f58959"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Notices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NoticeHistoric",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NoticeHistoric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeHistoric_Notices_NoticeId",
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
                    { new Guid("5550e928-693d-43e9-a43d-779151dbdde0"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1205), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6b6f317f-2c18-42c3-b3f5-d47664d2e20e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1225), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("844113c6-421a-45fe-a42f-1aef8acd6f79"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1232), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("87bbe3e1-d99d-432f-82fd-d1d4ead92526"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1229), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8d0877fa-0d6b-44f8-a86e-5a8b8848cde0"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1218), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9e359c90-b426-449c-bf5d-1444145fcfdf"), "[[description]]", null, null, new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1228), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ce8f5214-762c-4937-889a-e67ed976fb48"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1216), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ea5e6366-b23e-457f-b3ff-654117daca0c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1231), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f2004e11-36f4-4d7b-80f9-dc70812902d6"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 13, 16, 1, 17, 682, DateTimeKind.Local).AddTicks(1226), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeHistoric_NoticeId",
                table: "NoticeHistoric",
                column: "NoticeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeHistoric");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5550e928-693d-43e9-a43d-779151dbdde0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b6f317f-2c18-42c3-b3f5-d47664d2e20e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("844113c6-421a-45fe-a42f-1aef8acd6f79"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87bbe3e1-d99d-432f-82fd-d1d4ead92526"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8d0877fa-0d6b-44f8-a86e-5a8b8848cde0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9e359c90-b426-449c-bf5d-1444145fcfdf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ce8f5214-762c-4937-889a-e67ed976fb48"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ea5e6366-b23e-457f-b3ff-654117daca0c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f2004e11-36f4-4d7b-80f9-dc70812902d6"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notices");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("229a444c-ff4b-475e-a398-a9b9dc18e792"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8743), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("36a9a977-1495-435c-97f1-661458aea733"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8740), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("48660ec5-d0fc-4ff4-9cdb-e8ad995399c0"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8749), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("648c61dd-f62d-454f-93d9-04f6f6af4e6f"), "[[description]]", null, null, new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8746), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6b356fbb-7ba8-428a-8b86-6175fe6df4f8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8753), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("bb668874-f69d-41d8-8e60-1a43da424d09"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8726), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c13df26b-7565-4ddd-a612-b8af050433fa"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8742), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cc5f4960-722d-498b-9e0f-a06582dcd554"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8748), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f2f0f4bc-a67b-4c7c-bccb-1a5755f58959"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8745), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

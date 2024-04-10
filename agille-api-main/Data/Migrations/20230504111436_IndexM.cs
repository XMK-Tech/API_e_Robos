using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class IndexM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("245eea86-3c0b-4f53-bf9e-cb9106214a47"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c63c34f-0ebc-46cd-b12b-64f8dfdb2f09"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("53fbf41d-c868-4bff-9417-0bb413c17d80"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56e9bc2f-5828-4e4f-b08b-ba9e51666c5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("60343580-ad01-41e3-bbfc-06e7887f82d7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("826b5173-d589-4d3d-abf9-b5d832b74917"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b4768979-0ab1-45ac-bdce-9af9bcf27127"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("efa2499d-b7d7-4769-af67-93750c6e1d85"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f609b3e8-6afc-4ad6-b90a-3d2061c95510"));

            migrationBuilder.CreateTable(
                name: "Indices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("081053f0-7dd8-4b0e-9ae6-fdb03700243f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9403), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("10dc22cc-75af-4a32-a032-03219d418549"), "[[description]]", null, null, new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9436), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("5a9d9d75-6315-41b7-ac4e-c1377dda3948"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9448), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("5bb2ffb6-dd38-44e0-b428-3fc370be65f3"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9434), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("62eb25e1-ad7e-4a12-9077-54618445a86a"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9451), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e31c5ed1-a184-4d90-bd14-fb528f806739"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9430), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ec788a02-cb4c-4209-be17-e4041acc3170"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9427), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ee4237b1-0fa7-497b-962b-9aea3d05743b"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9432), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("efa080ff-5507-4372-a137-50b8a23d8b32"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 4, 8, 14, 31, 789, DateTimeKind.Local).AddTicks(9452), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indices");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("081053f0-7dd8-4b0e-9ae6-fdb03700243f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("10dc22cc-75af-4a32-a032-03219d418549"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5a9d9d75-6315-41b7-ac4e-c1377dda3948"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5bb2ffb6-dd38-44e0-b428-3fc370be65f3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("62eb25e1-ad7e-4a12-9077-54618445a86a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e31c5ed1-a184-4d90-bd14-fb528f806739"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec788a02-cb4c-4209-be17-e4041acc3170"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ee4237b1-0fa7-497b-962b-9aea3d05743b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("efa080ff-5507-4372-a137-50b8a23d8b32"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("245eea86-3c0b-4f53-bf9e-cb9106214a47"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8886), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c63c34f-0ebc-46cd-b12b-64f8dfdb2f09"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8861), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("53fbf41d-c868-4bff-9417-0bb413c17d80"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8894), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("56e9bc2f-5828-4e4f-b08b-ba9e51666c5f"), "[[description]]", null, null, new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8888), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("60343580-ad01-41e3-bbfc-06e7887f82d7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8878), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("826b5173-d589-4d3d-abf9-b5d832b74917"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8889), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b4768979-0ab1-45ac-bdce-9af9bcf27127"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8883), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("efa2499d-b7d7-4769-af67-93750c6e1d85"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8885), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f609b3e8-6afc-4ad6-b90a-3d2061c95510"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8891), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

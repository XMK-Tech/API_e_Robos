using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NotificationSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0df539ef-51f2-415f-98fb-17d188046f3e"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1962), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("0ecb9436-691d-4e9e-b999-9129f354e05b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1915), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("241cc93e-83cb-44d1-9bf8-43224389f8c3"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1942), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("25e9e641-b6f1-420d-8315-0deefc9d6de5"), "[[description]]", null, null, new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1949), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("2bb67751-59e5-44e0-a292-d4a4e107708e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1930), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("30763c82-ce74-4325-96db-615a7ea72670"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1947), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("56d85825-43d5-4730-ad29-0c53c99b99f3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1944), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("abbcbb63-34ed-41d7-99fc-ae2999fc86e1"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1960), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b6803ad6-35a2-452f-bb8d-bbe0bda075dd"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 14, 19, 17, 37, 721, DateTimeKind.Local).AddTicks(1957), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0df539ef-51f2-415f-98fb-17d188046f3e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0ecb9436-691d-4e9e-b999-9129f354e05b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("241cc93e-83cb-44d1-9bf8-43224389f8c3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25e9e641-b6f1-420d-8315-0deefc9d6de5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2bb67751-59e5-44e0-a292-d4a4e107708e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30763c82-ce74-4325-96db-615a7ea72670"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56d85825-43d5-4730-ad29-0c53c99b99f3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("abbcbb63-34ed-41d7-99fc-ae2999fc86e1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6803ad6-35a2-452f-bb8d-bbe0bda075dd"));

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
        }
    }
}

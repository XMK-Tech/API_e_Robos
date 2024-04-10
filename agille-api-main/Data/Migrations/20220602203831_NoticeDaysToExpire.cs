using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeDaysToExpire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1239397d-4ef2-47ab-87cd-77df305d1236"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1de83833-ffb3-4981-840f-7830fa2e242b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2170eee8-9276-4b20-8062-aea4510fe60c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("68320e13-a203-4f60-90ee-53d5e4fe869a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("68881c20-0682-42ef-8aa1-301a80261ad6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6cac0b1c-88aa-4f80-8b4f-cb6acd6d834c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7f51865f-84c8-4d85-99d1-2d7fc5826f5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8a31ca68-5354-4ef5-abe6-6f89b555ac66"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b069110e-d2f8-4771-94ab-c24d95f14088"));

            migrationBuilder.DropColumn(
                name: "ExpiresIn",
                table: "NoticeTemplates");

            migrationBuilder.AddColumn<int>(
                name: "DaysToExpire",
                table: "NoticeTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("44fcf8aa-13e2-4ad1-8332-ef6dd0773b6b"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2505), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("59e3dea9-0f90-4c34-9ff3-7114fb5fb215"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2484), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("710a0787-6759-49b7-8533-366d354baabb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2473), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("832755a8-e3a7-48ba-96eb-406fb89d22f2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2503), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("97f13a75-1307-4772-aca0-475f3e181265"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2480), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3a5d235-d4af-4eed-abbd-a1aeb54d042e"), "[[description]]", null, null, new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2483), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("cc68769e-6492-4a45-8574-89e8337f58b4"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2479), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ed7fcc55-6ff7-4d48-b0d3-f62d94a894f5"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2453), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("faf606a7-3d8c-4cc6-811b-1de41a594f0c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2475), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("44fcf8aa-13e2-4ad1-8332-ef6dd0773b6b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("59e3dea9-0f90-4c34-9ff3-7114fb5fb215"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("710a0787-6759-49b7-8533-366d354baabb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("832755a8-e3a7-48ba-96eb-406fb89d22f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97f13a75-1307-4772-aca0-475f3e181265"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3a5d235-d4af-4eed-abbd-a1aeb54d042e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cc68769e-6492-4a45-8574-89e8337f58b4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed7fcc55-6ff7-4d48-b0d3-f62d94a894f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("faf606a7-3d8c-4cc6-811b-1de41a594f0c"));

            migrationBuilder.DropColumn(
                name: "DaysToExpire",
                table: "NoticeTemplates");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresIn",
                table: "NoticeTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1239397d-4ef2-47ab-87cd-77df305d1236"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7597), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("1de83833-ffb3-4981-840f-7830fa2e242b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7580), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2170eee8-9276-4b20-8062-aea4510fe60c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7582), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("68320e13-a203-4f60-90ee-53d5e4fe869a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7595), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("68881c20-0682-42ef-8aa1-301a80261ad6"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7578), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6cac0b1c-88aa-4f80-8b4f-cb6acd6d834c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7558), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("7f51865f-84c8-4d85-99d1-2d7fc5826f5d"), "[[description]]", null, null, new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7591), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("8a31ca68-5354-4ef5-abe6-6f89b555ac66"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7593), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b069110e-d2f8-4771-94ab-c24d95f14088"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 2, 15, 28, 46, 784, DateTimeKind.Local).AddTicks(7583), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

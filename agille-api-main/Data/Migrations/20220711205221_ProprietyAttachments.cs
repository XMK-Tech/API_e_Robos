using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ProprietyAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0f60407a-e6f6-4991-b19a-fc1e883bb248"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("35af78fa-b296-491f-9d64-0076f9770b85"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e097112-4c7c-4347-affc-e23252324241"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("88c5b74b-12bd-46b8-a7df-bb064800d180"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89db1ecc-5aca-4044-8280-73b3ad96c32e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90ade9ea-27f9-4dc0-8154-b8eeb24fa728"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9b2819f3-f7ef-4476-8eb7-43d99b29da89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9f2dc1fd-fc4e-4e49-a2be-87a56b61e084"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a8bffa3b-7697-47a3-ba07-d11db626798d"));

            migrationBuilder.AddColumn<Guid>(
                name: "FromAttachmentId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("086f7798-bfd3-40e8-903d-87095a4bdce3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6774), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3cd155a9-2d69-4364-9c7b-daf7fb6da659"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6772), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("42e8461f-99f4-4ac0-b7ce-cf3e0017ee96"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6741), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("59a81721-c402-4dc0-abb7-2e915d8cb53e"), "[[description]]", null, null, new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6799), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("73ff7ab8-5078-4f25-9e16-703db56cbaa3"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6777), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7defdad7-fca1-488c-b85d-0535ac6369d4"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6804), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a2d06fe7-3345-415f-bd21-e2fafb145011"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6769), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b005041b-9e82-44a2-bad1-eb8381a5e046"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6802), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cdcd9a6d-9189-4fd9-9b7b-5a203a260b3b"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6806), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propriety_FromAttachmentId",
                table: "Propriety",
                column: "FromAttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propriety_Attachment_FromAttachmentId",
                table: "Propriety",
                column: "FromAttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propriety_Attachment_FromAttachmentId",
                table: "Propriety");

            migrationBuilder.DropIndex(
                name: "IX_Propriety_FromAttachmentId",
                table: "Propriety");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("086f7798-bfd3-40e8-903d-87095a4bdce3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3cd155a9-2d69-4364-9c7b-daf7fb6da659"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42e8461f-99f4-4ac0-b7ce-cf3e0017ee96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("59a81721-c402-4dc0-abb7-2e915d8cb53e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("73ff7ab8-5078-4f25-9e16-703db56cbaa3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7defdad7-fca1-488c-b85d-0535ac6369d4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a2d06fe7-3345-415f-bd21-e2fafb145011"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b005041b-9e82-44a2-bad1-eb8381a5e046"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cdcd9a6d-9189-4fd9-9b7b-5a203a260b3b"));

            migrationBuilder.DropColumn(
                name: "FromAttachmentId",
                table: "Propriety");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0f60407a-e6f6-4991-b19a-fc1e883bb248"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5055), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("35af78fa-b296-491f-9d64-0076f9770b85"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5052), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3e097112-4c7c-4347-affc-e23252324241"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5034), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("88c5b74b-12bd-46b8-a7df-bb064800d180"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5038), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("89db1ecc-5aca-4044-8280-73b3ad96c32e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5036), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("90ade9ea-27f9-4dc0-8154-b8eeb24fa728"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5053), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9b2819f3-f7ef-4476-8eb7-43d99b29da89"), "[[description]]", null, null, new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5039), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("9f2dc1fd-fc4e-4e49-a2be-87a56b61e084"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5021), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a8bffa3b-7697-47a3-ba07-d11db626798d"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 5, 15, 57, 59, 323, DateTimeKind.Local).AddTicks(5033), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

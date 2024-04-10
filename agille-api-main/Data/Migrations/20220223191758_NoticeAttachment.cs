using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09154846-a0b3-4662-9119-f560f11f2048"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("09e7faf0-b7ff-49c0-a5e9-2d8b1438b2cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("34a7c493-8092-4b6a-b32e-6b76e7842042"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a5b4fcee-2119-49aa-9c65-d618dc2a244b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b69eddf2-648d-4fcf-aa65-f37d1e7c8fc1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("be6f6f0f-fa04-4fb9-8a3b-c50f4c4f74b4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c027379a-306a-447b-be4f-8a572ff7f461"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d01ca534-7ee1-40a8-90d4-867c23e9dd65"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fafe5663-5669-47c4-93cd-3b143881129a"));

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Notices");

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId",
                table: "Notices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("6c7b634c-8ddc-4b71-9690-55618d4b9ff1"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 154, DateTimeKind.Local).AddTicks(9360), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8a78b7b8-c749-4b59-9d9f-aa682b9788ee"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1851), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("110b0d33-dd50-492c-8d95-2f3283b83194"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1954), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("961c504b-f461-4fc0-ba01-09bbfe9f5ba0"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1959), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("379e4fb8-25bd-4438-a884-2cf483f1f01a"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1962), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c168808f-b4a7-44ad-b271-e5a5351eeff2"), "[[description]]", null, null, new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1965), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ccc70706-1e4f-41cf-ad1c-712edd127640"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1968), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3718e9d1-eec5-44c0-bd12-ee3f6771ffd6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1970), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("011fe994-2b1d-464f-a8a9-b7cb9a381df6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 23, 16, 17, 58, 156, DateTimeKind.Local).AddTicks(1981), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_AttachmentId",
                table: "Notices",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Attachment_AttachmentId",
                table: "Notices",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Attachment_AttachmentId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_AttachmentId",
                table: "Notices");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("011fe994-2b1d-464f-a8a9-b7cb9a381df6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("110b0d33-dd50-492c-8d95-2f3283b83194"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3718e9d1-eec5-44c0-bd12-ee3f6771ffd6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("379e4fb8-25bd-4438-a884-2cf483f1f01a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6c7b634c-8ddc-4b71-9690-55618d4b9ff1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8a78b7b8-c749-4b59-9d9f-aa682b9788ee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("961c504b-f461-4fc0-ba01-09bbfe9f5ba0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c168808f-b4a7-44ad-b271-e5a5351eeff2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ccc70706-1e4f-41cf-ad1c-712edd127640"));

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Notices");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Notices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("c027379a-306a-447b-be4f-8a572ff7f461"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 662, DateTimeKind.Local).AddTicks(43), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("09154846-a0b3-4662-9119-f560f11f2048"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(702), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("be6f6f0f-fa04-4fb9-8a3b-c50f4c4f74b4"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(790), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fafe5663-5669-47c4-93cd-3b143881129a"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(794), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b69eddf2-648d-4fcf-aa65-f37d1e7c8fc1"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(797), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a5b4fcee-2119-49aa-9c65-d618dc2a244b"), "[[description]]", null, null, new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(799), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d01ca534-7ee1-40a8-90d4-867c23e9dd65"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(812), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("34a7c493-8092-4b6a-b32e-6b76e7842042"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(815), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("09e7faf0-b7ff-49c0-a5e9-2d8b1438b2cf"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 23, 9, 52, 24, 663, DateTimeKind.Local).AddTicks(817), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

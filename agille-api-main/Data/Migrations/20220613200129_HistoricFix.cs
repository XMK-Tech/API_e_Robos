using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class HistoricFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeHistoric_Notices_NoticeId",
                table: "NoticeHistoric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoticeHistoric",
                table: "NoticeHistoric");

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

            migrationBuilder.RenameTable(
                name: "NoticeHistoric",
                newName: "NoticeHistorics");

            migrationBuilder.RenameIndex(
                name: "IX_NoticeHistoric_NoticeId",
                table: "NoticeHistorics",
                newName: "IX_NoticeHistorics_NoticeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NoticeHistorics",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoticeHistorics",
                table: "NoticeHistorics",
                column: "Id");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("25a06c7a-1b34-40b2-a07b-104c3c9f1ca4"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7332), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("30bbc5ad-ba3e-4e92-84d8-b8669be8d12e"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7334), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3608fef0-3e5e-4491-8c80-4b098ef4c575"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7318), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("501ab48d-77a2-49d9-bb95-ffbb74b11e58"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7336), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5ed8570c-8ac0-4fa0-89de-c55d8b9a7b4a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7351), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9fdd8631-8cf6-4a9f-b4ac-fdb54b674437"), "[[description]]", null, null, new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7350), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c5a7268d-8a07-43bc-8230-73bcb8770b4c"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7355), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("e5d261e1-f5a0-49ee-8866-fe0d5c42e6e7"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7348), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ffd5eee9-ab13-4374-a3c8-0b413615ca76"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 13, 17, 1, 27, 281, DateTimeKind.Local).AddTicks(7353), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeHistorics_Notices_NoticeId",
                table: "NoticeHistorics",
                column: "NoticeId",
                principalTable: "Notices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeHistorics_Notices_NoticeId",
                table: "NoticeHistorics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoticeHistorics",
                table: "NoticeHistorics");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("25a06c7a-1b34-40b2-a07b-104c3c9f1ca4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30bbc5ad-ba3e-4e92-84d8-b8669be8d12e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3608fef0-3e5e-4491-8c80-4b098ef4c575"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("501ab48d-77a2-49d9-bb95-ffbb74b11e58"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ed8570c-8ac0-4fa0-89de-c55d8b9a7b4a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fdd8631-8cf6-4a9f-b4ac-fdb54b674437"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c5a7268d-8a07-43bc-8230-73bcb8770b4c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e5d261e1-f5a0-49ee-8866-fe0d5c42e6e7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffd5eee9-ab13-4374-a3c8-0b413615ca76"));

            migrationBuilder.RenameTable(
                name: "NoticeHistorics",
                newName: "NoticeHistoric");

            migrationBuilder.RenameIndex(
                name: "IX_NoticeHistorics_NoticeId",
                table: "NoticeHistoric",
                newName: "IX_NoticeHistoric_NoticeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NoticeHistoric",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoticeHistoric",
                table: "NoticeHistoric",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeHistoric_Notices_NoticeId",
                table: "NoticeHistoric",
                column: "NoticeId",
                principalTable: "Notices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

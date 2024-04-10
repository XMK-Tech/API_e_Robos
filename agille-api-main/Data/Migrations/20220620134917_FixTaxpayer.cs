using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixTaxpayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxpayers_User_UserId",
                table: "Taxpayers");

            migrationBuilder.DropIndex(
                name: "IX_Taxpayers_UserId",
                table: "Taxpayers");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("314401a9-5b4c-428a-a775-3a400838320a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c91338e-b302-43e2-ae6e-95f0bb7547e2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56b049fa-895e-4064-83f8-50ac296e8e48"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("84278a61-2838-4356-91e0-3ac1da206329"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9bac6ea6-0792-47e3-ab09-4b8ba99f1923"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d525879c-f676-43d1-8762-f738141258f7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d9451a19-9c9a-4cc8-bb0c-f4c17fe71b8d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f28f9362-0796-4cf1-99a5-937d808436d8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f9780f39-1b2c-4de3-933c-b74ef8202fe8"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("15bd800b-a1d5-45e9-a627-5eb75edeb1a3"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4797), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("289347a2-01a2-40e2-89e7-3550510933d5"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4795), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4c448959-68cc-478a-b5b4-77a11ed7f8ba"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4769), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("661e8cf7-52f8-4c9d-bb5b-4833aa5f7d30"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4800), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("66c5719c-cf94-4620-97a2-b8b2715911a8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4801), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8e83e375-9d84-4322-bcb6-5fcf13e3a32a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4794), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bd6c96d6-2e0b-463f-8321-0c3cdd6efa18"), "[[description]]", null, null, new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4798), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ea2f4ced-4e31-4d27-8052-52d047c225b0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4802), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f5aa6432-2208-4f6e-8341-6de38eb6994a"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4783), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("15bd800b-a1d5-45e9-a627-5eb75edeb1a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("289347a2-01a2-40e2-89e7-3550510933d5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c448959-68cc-478a-b5b4-77a11ed7f8ba"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("661e8cf7-52f8-4c9d-bb5b-4833aa5f7d30"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("66c5719c-cf94-4620-97a2-b8b2715911a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e83e375-9d84-4322-bcb6-5fcf13e3a32a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bd6c96d6-2e0b-463f-8321-0c3cdd6efa18"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ea2f4ced-4e31-4d27-8052-52d047c225b0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f5aa6432-2208-4f6e-8341-6de38eb6994a"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("314401a9-5b4c-428a-a775-3a400838320a"), "[[description]]", null, null, new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4840), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3c91338e-b302-43e2-ae6e-95f0bb7547e2"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4807), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("56b049fa-895e-4064-83f8-50ac296e8e48"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4823), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("84278a61-2838-4356-91e0-3ac1da206329"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4820), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9bac6ea6-0792-47e3-ab09-4b8ba99f1923"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4841), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d525879c-f676-43d1-8762-f738141258f7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4843), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d9451a19-9c9a-4cc8-bb0c-f4c17fe71b8d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4822), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f28f9362-0796-4cf1-99a5-937d808436d8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4844), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f9780f39-1b2c-4de3-933c-b74ef8202fe8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 15, 16, 36, 7, 278, DateTimeKind.Local).AddTicks(4825), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxpayers_UserId",
                table: "Taxpayers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxpayers_User_UserId",
                table: "Taxpayers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

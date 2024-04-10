using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RemoveForeignKeyNotice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeDivergencyEntries_DivergencyEntry_DivergencyEntryId",
                table: "NoticeDivergencyEntries");

            migrationBuilder.DropIndex(
                name: "IX_NoticeDivergencyEntries_DivergencyEntryId",
                table: "NoticeDivergencyEntries");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("08074abf-ffb7-4015-9afb-aef9d5437301"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("33f986f8-f285-4a5c-ab47-5ad6274f425e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6e969bb2-9ad0-4c0e-9adf-7143defeb78a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7dd755e6-c5c3-4b4c-882d-7eaebdfa4019"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b41386f2-9212-484a-ae3d-cb9127257d5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b4b6da24-aeed-4887-8528-de4e19cd2344"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c6e06d11-66e0-44de-badf-058a849f65cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d6c2f8f6-9047-4ed7-9011-a8bd3d12a743"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dc6d2aa9-c348-4768-ae5f-ba746ca39e67"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c823c4b-338b-4c62-9eb2-3ce3f0bf46c2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7358), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("1edbc52b-1069-4c2f-a971-4787fdfae71d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7356), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("40ea5a39-8712-420e-87bc-4814f5752a1e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7353), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("70fb1efd-a098-4394-8ba5-f7ffb4c79306"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7354), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("969d31a7-012b-4df8-925c-1dfc6a8b5fe0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7361), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("b7d36eea-1825-46bc-bae6-421346d26023"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7337), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cfa57ff1-addb-4228-8e4a-1dccac6aa65a"), "[[description]]", null, null, new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7355), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d794f007-9515-41c8-9192-3441f1359897"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7351), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fd815838-dbba-4642-9ce8-76b0cc9ffd42"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 1, 11, 22, 12, 397, DateTimeKind.Local).AddTicks(7350), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c823c4b-338b-4c62-9eb2-3ce3f0bf46c2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1edbc52b-1069-4c2f-a971-4787fdfae71d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("40ea5a39-8712-420e-87bc-4814f5752a1e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("70fb1efd-a098-4394-8ba5-f7ffb4c79306"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("969d31a7-012b-4df8-925c-1dfc6a8b5fe0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b7d36eea-1825-46bc-bae6-421346d26023"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cfa57ff1-addb-4228-8e4a-1dccac6aa65a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d794f007-9515-41c8-9192-3441f1359897"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fd815838-dbba-4642-9ce8-76b0cc9ffd42"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("08074abf-ffb7-4015-9afb-aef9d5437301"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8629), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("33f986f8-f285-4a5c-ab47-5ad6274f425e"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8658), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6e969bb2-9ad0-4c0e-9adf-7143defeb78a"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8646), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7dd755e6-c5c3-4b4c-882d-7eaebdfa4019"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8643), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b41386f2-9212-484a-ae3d-cb9127257d5d"), "[[description]]", null, null, new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8649), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b4b6da24-aeed-4887-8528-de4e19cd2344"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8645), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c6e06d11-66e0-44de-badf-058a849f65cf"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8661), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("d6c2f8f6-9047-4ed7-9011-a8bd3d12a743"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8647), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("dc6d2aa9-c348-4768-ae5f-ba746ca39e67"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 1, 8, 48, 5, 784, DateTimeKind.Local).AddTicks(8660), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeDivergencyEntries_DivergencyEntryId",
                table: "NoticeDivergencyEntries",
                column: "DivergencyEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeDivergencyEntries_DivergencyEntry_DivergencyEntryId",
                table: "NoticeDivergencyEntries",
                column: "DivergencyEntryId",
                principalTable: "DivergencyEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

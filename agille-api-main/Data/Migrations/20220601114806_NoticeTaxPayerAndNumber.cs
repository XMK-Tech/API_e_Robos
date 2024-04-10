using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeTaxPayerAndNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("19929eb6-aa4f-41fe-86a4-989ed908e036"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b7d1-d1d3-4eb2-bd44-a5b20aa52ec8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("30653aa8-2281-4fea-85a2-1d06ddce7ea3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("33cd84c3-7008-4ea0-a783-b4159a82ef70"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("66d2a1f3-d3e7-409f-a3e5-97531541b6a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6aa434d3-a2fe-4273-9eeb-be5109c4a8e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a48c511c-9c51-4e0f-aed5-fa22b3b3fe2c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bb2ea101-80d9-4d58-a183-4b49dd86d57c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("eeb1d47a-18d5-4fe8-9377-4f30b9b6480f"));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Notices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "TaxPayerId",
                table: "Notices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_Notices_TaxPayerId",
                table: "Notices",
                column: "TaxPayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_JuridicalPerson_TaxPayerId",
                table: "Notices",
                column: "TaxPayerId",
                principalTable: "JuridicalPerson",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_JuridicalPerson_TaxPayerId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_TaxPayerId",
                table: "Notices");

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

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "TaxPayerId",
                table: "Notices");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("19929eb6-aa4f-41fe-86a4-989ed908e036"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8055), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("2aa8b7d1-d1d3-4eb2-bd44-a5b20aa52ec8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8053), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("30653aa8-2281-4fea-85a2-1d06ddce7ea3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8049), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("33cd84c3-7008-4ea0-a783-b4159a82ef70"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8050), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("66d2a1f3-d3e7-409f-a3e5-97531541b6a3"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8058), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("6aa434d3-a2fe-4273-9eeb-be5109c4a8e6"), "[[description]]", null, null, new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8052), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a48c511c-9c51-4e0f-aed5-fa22b3b3fe2c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8048), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bb2ea101-80d9-4d58-a183-4b49dd86d57c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8035), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("eeb1d47a-18d5-4fe8-9377-4f30b9b6480f"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 31, 14, 37, 12, 559, DateTimeKind.Local).AddTicks(8046), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

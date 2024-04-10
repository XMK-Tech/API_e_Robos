using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class OverridePreviousImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("526cfbb6-5df8-4277-862b-f43dc4651938"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("53157dbf-0485-47d6-aee4-62c2d2b0fec9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e43e47-5f78-47f8-859b-b8f9188e6e95"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ab0919a-ad0d-4aa9-b82e-20971214a4a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7ab69543-6a9a-4df9-84c1-2728581d8cfd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("819fadd5-992d-4f40-a6d2-2bd449ca1835"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("94fa3c43-5b7a-4b8d-a419-64935353f29b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9c46ea2c-b513-4769-8814-e26a22a0d110"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1d2dd1e-51c0-4e64-8de5-baeba4175c12"));

            migrationBuilder.AddColumn<Guid>(
                name: "CrawlerFileId",
                table: "Revenues",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CrawlerFileId",
                table: "FPMLaunches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CrawlerFileId",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasReverted",
                table: "CrawlerFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CrawlerFileId",
                table: "Collections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("43620abe-3c95-44c4-9903-1ddb94262c2f"), "[[person-document]]", "Document", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4702), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6a4324f4-f210-4fde-81cc-186c524645a4"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4719), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6b58bf93-6d5c-4860-ae93-3e557707be0a"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4699), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6d1bc5f5-8a80-4350-a333-8c4d16cc47a6"), "[[description]]", null, null, new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4705), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("7a6c246f-ba58-4a1d-b703-818e10b5d444"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4685), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a95607c2-1601-4bed-a557-599431885f8a"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4717), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d1476f07-bb13-4d87-9617-b0b934352777"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4720), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f71bcbc1-9e37-4723-8691-b10f8e9457d2"), "[[person-name]]", "Name", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4701), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("fed4b041-d6ad-4e25-8aa5-5e6cf5e37a46"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 9, 20, 9, 55, 34, 465, DateTimeKind.Local).AddTicks(4703), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_CrawlerFileId",
                table: "Revenues",
                column: "CrawlerFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FPMLaunches_CrawlerFileId",
                table: "FPMLaunches",
                column: "CrawlerFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CrawlerFileId",
                table: "Expenses",
                column: "CrawlerFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CrawlerFileId",
                table: "Collections",
                column: "CrawlerFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CrawlerFile_CrawlerFileId",
                table: "Collections",
                column: "CrawlerFileId",
                principalTable: "CrawlerFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CrawlerFile_CrawlerFileId",
                table: "Expenses",
                column: "CrawlerFileId",
                principalTable: "CrawlerFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FPMLaunches_CrawlerFile_CrawlerFileId",
                table: "FPMLaunches",
                column: "CrawlerFileId",
                principalTable: "CrawlerFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_CrawlerFile_CrawlerFileId",
                table: "Revenues",
                column: "CrawlerFileId",
                principalTable: "CrawlerFile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CrawlerFile_CrawlerFileId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CrawlerFile_CrawlerFileId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_FPMLaunches_CrawlerFile_CrawlerFileId",
                table: "FPMLaunches");

            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_CrawlerFile_CrawlerFileId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_CrawlerFileId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_FPMLaunches_CrawlerFileId",
                table: "FPMLaunches");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CrawlerFileId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CrawlerFileId",
                table: "Collections");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("43620abe-3c95-44c4-9903-1ddb94262c2f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a4324f4-f210-4fde-81cc-186c524645a4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b58bf93-6d5c-4860-ae93-3e557707be0a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6d1bc5f5-8a80-4350-a333-8c4d16cc47a6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7a6c246f-ba58-4a1d-b703-818e10b5d444"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a95607c2-1601-4bed-a557-599431885f8a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1476f07-bb13-4d87-9617-b0b934352777"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f71bcbc1-9e37-4723-8691-b10f8e9457d2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fed4b041-d6ad-4e25-8aa5-5e6cf5e37a46"));

            migrationBuilder.DropColumn(
                name: "CrawlerFileId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "CrawlerFileId",
                table: "FPMLaunches");

            migrationBuilder.DropColumn(
                name: "CrawlerFileId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "WasReverted",
                table: "CrawlerFile");

            migrationBuilder.DropColumn(
                name: "CrawlerFileId",
                table: "Collections");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("526cfbb6-5df8-4277-862b-f43dc4651938"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(795), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("53157dbf-0485-47d6-aee4-62c2d2b0fec9"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(786), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("70e43e47-5f78-47f8-859b-b8f9188e6e95"), "[[person-name]]", "Name", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(778), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7ab0919a-ad0d-4aa9-b82e-20971214a4a8"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(775), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("7ab69543-6a9a-4df9-84c1-2728581d8cfd"), "[[description]]", null, null, new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(784), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("819fadd5-992d-4f40-a6d2-2bd449ca1835"), "[[person-document]]", "Document", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(780), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("94fa3c43-5b7a-4b8d-a419-64935353f29b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(748), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9c46ea2c-b513-4769-8814-e26a22a0d110"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(788), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d1d2dd1e-51c0-4e64-8de5-baeba4175c12"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 8, 3, 8, 2, 26, 905, DateTimeKind.Local).AddTicks(781), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

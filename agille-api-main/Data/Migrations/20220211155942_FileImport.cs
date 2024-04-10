using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class FileImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2a530fcf-7ea7-4663-9875-2078478465ea"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55ecb081-7733-4827-94d9-953884e98b87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("587ce86b-da3e-4af2-b353-ea01f1e51d2b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5c5c1392-c85a-4947-958b-e9b2e16f0ce3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("75982482-6f6d-4bb9-b3f9-94c883970659"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("983bd49c-2d8d-4c16-a432-4c0021b79976"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3f04abd-4aef-4224-82a1-8a198bc18501"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cf95bc2b-2519-4090-9fcb-23ff988b198e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d52e0c7d-a6e0-4675-9c76-0fd6a5dbacaf"));

            migrationBuilder.CreateTable(
                name: "ImportFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportFile", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("73143919-221d-40e4-b527-1ce124cbacdb"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 658, DateTimeKind.Local).AddTicks(8015), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e1503c94-e890-4e62-9338-2ada98c932bb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8149), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1ab2c2e1-c36a-48a9-b230-cd59beef4499"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8245), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5decad9d-46c9-4e94-8868-535d19ba2d48"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8249), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a70b95f1-d980-4fe3-bfe9-e066aec30658"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8251), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f9aaa349-cf39-449a-9835-cbfba24edd43"), "[[description]]", null, null, new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8255), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("2466ff73-3a20-4c4b-8ddf-9c34056e36d9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8257), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("56ef9b24-7014-48b0-a968-52a30edf7cbe"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8278), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("674bd4e6-2749-4228-b35a-cf00b94f1e5d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 11, 12, 59, 41, 659, DateTimeKind.Local).AddTicks(8280), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportFile");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1ab2c2e1-c36a-48a9-b230-cd59beef4499"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2466ff73-3a20-4c4b-8ddf-9c34056e36d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56ef9b24-7014-48b0-a968-52a30edf7cbe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5decad9d-46c9-4e94-8868-535d19ba2d48"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("674bd4e6-2749-4228-b35a-cf00b94f1e5d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("73143919-221d-40e4-b527-1ce124cbacdb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a70b95f1-d980-4fe3-bfe9-e066aec30658"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e1503c94-e890-4e62-9338-2ada98c932bb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f9aaa349-cf39-449a-9835-cbfba24edd43"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("5c5c1392-c85a-4947-958b-e9b2e16f0ce3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 587, DateTimeKind.Local).AddTicks(3243), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("983bd49c-2d8d-4c16-a432-4c0021b79976"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2780), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cf95bc2b-2519-4090-9fcb-23ff988b198e"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2861), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2a530fcf-7ea7-4663-9875-2078478465ea"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2865), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("75982482-6f6d-4bb9-b3f9-94c883970659"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2867), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("55ecb081-7733-4827-94d9-953884e98b87"), "[[description]]", null, null, new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2869), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a3f04abd-4aef-4224-82a1-8a198bc18501"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2871), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d52e0c7d-a6e0-4675-9c76-0fd6a5dbacaf"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2873), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("587ce86b-da3e-4af2-b353-ea01f1e51d2b"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 11, 12, 43, 48, 588, DateTimeKind.Local).AddTicks(2882), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

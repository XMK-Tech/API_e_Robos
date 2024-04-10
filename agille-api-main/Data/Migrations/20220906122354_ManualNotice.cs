using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ManualNotice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0dab71f0-4bf8-456c-9b2f-cbf51226f975"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5c83d743-9f5b-4264-be41-508bbfe218d8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("79deb3db-60fd-497f-996b-2b3200f9ec37"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aa9a163d-dd3e-4779-aa3c-db9758b26b20"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ac349223-75df-4dc5-86e9-c19d2e94de36"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b2cdb016-90da-41f3-aca9-ba9bf5017a7d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc309e39-aca5-47aa-af29-860fcd036848"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cf4f8a62-70b5-4596-bea2-92d6d1ea31e3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ebcacb20-dd0f-4fe2-bb47-b995c141ef42"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxPayerId",
                table: "Notices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0cf10300-9613-44cf-bada-32ae281d83c4"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1410), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("13288bb3-6337-45e1-ac79-cfbca5c36318"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1444), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("6e33435e-143e-4a48-bd47-1cf516d9f52d"), "[[description]]", null, null, new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1438), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("87a06128-084c-40ad-bc04-48d5ea745ee0"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1440), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9e43e106-6d88-4352-bf30-b3414a10148b"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1430), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a18f9177-fac5-4601-ac58-670433db4a2a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1439), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b8058415-55d2-4a94-abe2-bae08d7af6e1"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1433), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d518917a-5457-49bd-b68e-60b5ae2e2a7d"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1436), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e8e99ee6-18df-451e-9531-a3881c1973b6"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 6, 9, 23, 50, 940, DateTimeKind.Local).AddTicks(1432), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0cf10300-9613-44cf-bada-32ae281d83c4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13288bb3-6337-45e1-ac79-cfbca5c36318"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6e33435e-143e-4a48-bd47-1cf516d9f52d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87a06128-084c-40ad-bc04-48d5ea745ee0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9e43e106-6d88-4352-bf30-b3414a10148b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a18f9177-fac5-4601-ac58-670433db4a2a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b8058415-55d2-4a94-abe2-bae08d7af6e1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d518917a-5457-49bd-b68e-60b5ae2e2a7d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e8e99ee6-18df-451e-9531-a3881c1973b6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxPayerId",
                table: "Notices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0dab71f0-4bf8-456c-9b2f-cbf51226f975"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1919), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5c83d743-9f5b-4264-be41-508bbfe218d8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1937), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("79deb3db-60fd-497f-996b-2b3200f9ec37"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1932), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("aa9a163d-dd3e-4779-aa3c-db9758b26b20"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1928), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ac349223-75df-4dc5-86e9-c19d2e94de36"), "[[description]]", null, null, new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1923), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b2cdb016-90da-41f3-aca9-ba9bf5017a7d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1909), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bc309e39-aca5-47aa-af29-860fcd036848"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1914), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cf4f8a62-70b5-4596-bea2-92d6d1ea31e3"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1889), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ebcacb20-dd0f-4fe2-bb47-b995c141ef42"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 29, 8, 41, 0, 709, DateTimeKind.Local).AddTicks(1870), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

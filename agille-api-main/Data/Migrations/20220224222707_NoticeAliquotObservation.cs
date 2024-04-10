using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeAliquotObservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<double>(
                name: "Aliquot",
                table: "Notices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Notices",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("897a050f-818a-4c19-b41a-74de0738b269"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 259, DateTimeKind.Local).AddTicks(3963), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("78ba2284-40f6-4002-9cfd-74bc542ae819"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3572), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("13dfd941-a1bd-4d9d-92ae-7ebbb892236b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3647), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("dbee62f3-e520-4694-85b5-4504a58c4b2f"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3651), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ad6593bc-51c9-459b-94d1-a6f1dfbfb1d5"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3653), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("88a8ba16-c137-4212-8113-06fe33723ada"), "[[description]]", null, null, new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3655), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ebda47ea-2db7-429e-841d-a263e89e0db4"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3658), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cfd776af-06c0-48f9-9334-f87dd1a3394b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3672), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("61c45116-1839-4d55-9c43-9d7cdac9d309"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 24, 19, 27, 7, 260, DateTimeKind.Local).AddTicks(3675), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13dfd941-a1bd-4d9d-92ae-7ebbb892236b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("61c45116-1839-4d55-9c43-9d7cdac9d309"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("78ba2284-40f6-4002-9cfd-74bc542ae819"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("88a8ba16-c137-4212-8113-06fe33723ada"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("897a050f-818a-4c19-b41a-74de0738b269"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ad6593bc-51c9-459b-94d1-a6f1dfbfb1d5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cfd776af-06c0-48f9-9334-f87dd1a3394b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dbee62f3-e520-4694-85b5-4504a58c4b2f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ebda47ea-2db7-429e-841d-a263e89e0db4"));

            migrationBuilder.DropColumn(
                name: "Aliquot",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Notices");

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
        }
    }
}

using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class DataCrossingProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(
                File.ReadAllText(
                "../Data/Migrations/Procedures/UpdateDataCrossing.sql"));
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("00933f2c-58eb-47da-9ab2-97817c0cd1ad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("23e622ba-78cf-470e-a526-a5497a719bad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3687abf4-7fc6-4294-ae1f-21562bdd261b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3915e470-ed6b-492c-b181-9d2edefe18cd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3a86faea-d13d-44af-88ce-7dae865e7573"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87987e48-54aa-4c6d-9603-91d5f905ec5b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c4e67111-c856-476c-9106-1052f709fc44"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c7e44c94-97d3-4a6f-9563-7d1de9237eb7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c902e021-49e4-4dee-bf15-9da299a62a60"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("20a9a9f0-c885-48e9-abf3-ec1a3fedc089"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 528, DateTimeKind.Local).AddTicks(9725), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1957446f-af11-48ef-88a7-f5fe278c744a"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9543), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("89e36504-a3c5-4cd4-9291-aa57dc5243c5"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9704), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6124d06a-b7f7-4609-b8e9-d670c64774f5"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9712), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("67699684-88d5-47d9-873a-cbc1112a874a"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9716), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("90ef1f97-9a26-4cb3-afd9-9123c8afc0fb"), "[[description]]", null, null, new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9722), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d3274747-4aff-4d1c-8294-e56c22ea0172"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9726), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("1d0f0c12-ca88-4951-b6f9-f405e9499338"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9730), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("56aefcd1-f550-4192-a5ab-798ee082c1c0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9749), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE UpdateDynamicFieldOptions");
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1957446f-af11-48ef-88a7-f5fe278c744a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1d0f0c12-ca88-4951-b6f9-f405e9499338"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("20a9a9f0-c885-48e9-abf3-ec1a3fedc089"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56aefcd1-f550-4192-a5ab-798ee082c1c0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6124d06a-b7f7-4609-b8e9-d670c64774f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("67699684-88d5-47d9-873a-cbc1112a874a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89e36504-a3c5-4cd4-9291-aa57dc5243c5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90ef1f97-9a26-4cb3-afd9-9123c8afc0fb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d3274747-4aff-4d1c-8294-e56c22ea0172"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3a86faea-d13d-44af-88ce-7dae865e7573"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 522, DateTimeKind.Local).AddTicks(2394), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("00933f2c-58eb-47da-9ab2-97817c0cd1ad"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4294), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("87987e48-54aa-4c6d-9603-91d5f905ec5b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4406), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c4e67111-c856-476c-9106-1052f709fc44"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4410), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3687abf4-7fc6-4294-ae1f-21562bdd261b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4413), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("c902e021-49e4-4dee-bf15-9da299a62a60"), "[[description]]", null, null, new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4416), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("23e622ba-78cf-470e-a526-a5497a719bad"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4419), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c7e44c94-97d3-4a6f-9563-7d1de9237eb7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4434), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3915e470-ed6b-492c-b181-9d2edefe18cd"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 17, 18, 17, 42, 523, DateTimeKind.Local).AddTicks(4437), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

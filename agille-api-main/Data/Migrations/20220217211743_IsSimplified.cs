using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class IsSimplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1237dc6e-18e2-488f-8a86-740fc7bc8e87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2909cdfb-77ff-464b-acfb-9a0b6d75a11d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("32d6fc98-fd56-40dd-a727-c2aeaae0e7f7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4a616d71-5899-4d27-a4d6-39d6a1ba9479"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("50ee6dde-310b-433d-8d44-10c407318973"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a7c9c8d-746b-4cad-8e08-8fb2a06e5cac"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b206313-ff7a-4598-971b-e159cdfb5897"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9ffacfaa-2022-41c5-aff8-64ff050ac66c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a406961f-23a9-46f7-b580-e515d888bc4f"));

            migrationBuilder.AddColumn<bool>(
                name: "IsSimplified",
                table: "ImportFile",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "IsSimplified",
                table: "ImportFile");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("9ffacfaa-2022-41c5-aff8-64ff050ac66c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 364, DateTimeKind.Local).AddTicks(4744), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6a7c9c8d-746b-4cad-8e08-8fb2a06e5cac"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5665), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1237dc6e-18e2-488f-8a86-740fc7bc8e87"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5755), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2909cdfb-77ff-464b-acfb-9a0b6d75a11d"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5759), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a406961f-23a9-46f7-b580-e515d888bc4f"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5762), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("50ee6dde-310b-433d-8d44-10c407318973"), "[[description]]", null, null, new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5764), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("32d6fc98-fd56-40dd-a727-c2aeaae0e7f7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5766), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4a616d71-5899-4d27-a4d6-39d6a1ba9479"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5779), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6b206313-ff7a-4598-971b-e159cdfb5897"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5782), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

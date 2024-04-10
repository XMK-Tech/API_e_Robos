using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class Colaborador_CRUD_v1 : Migration
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

            migrationBuilder.DropColumn(
                name: "EstablishmentFormat",
                table: "JuridicalPerson");

            migrationBuilder.DropColumn(
                name: "StateRegistration",
                table: "JuridicalPerson");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipalRegistration",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Address",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("7f370c8b-9efe-4906-a039-ace9377909c8"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 596, DateTimeKind.Local).AddTicks(5028), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("aa671baa-af5a-420b-ab83-d0fae8faf44e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2193), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("70c66fac-f32d-47d3-8b5e-75307939f325"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2438), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4a0e0ffc-6998-4149-8ed0-f632625b3dad"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2452), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f0b7fc26-d567-4a14-88cd-8e43502ab831"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2523), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("419a66cc-f33b-41ed-8af9-eab6bc4fae40"), "[[description]]", null, null, new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2532), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("fc2b5714-98d4-48bd-9669-8d0da67ff6e9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2541), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("db7e3640-9862-49d6-9194-f6eb643dafa7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2546), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("762647bf-a654-4966-a9a4-361108d4f6ee"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 18, 16, 39, 59, 602, DateTimeKind.Local).AddTicks(2551), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("419a66cc-f33b-41ed-8af9-eab6bc4fae40"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4a0e0ffc-6998-4149-8ed0-f632625b3dad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("70c66fac-f32d-47d3-8b5e-75307939f325"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("762647bf-a654-4966-a9a4-361108d4f6ee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7f370c8b-9efe-4906-a039-ace9377909c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aa671baa-af5a-420b-ab83-d0fae8faf44e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db7e3640-9862-49d6-9194-f6eb643dafa7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f0b7fc26-d567-4a14-88cd-8e43502ab831"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fc2b5714-98d4-48bd-9669-8d0da67ff6e9"));

            migrationBuilder.DropColumn(
                name: "County",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MunicipalRegistration",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentFormat",
                table: "JuridicalPerson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateRegistration",
                table: "JuridicalPerson",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

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

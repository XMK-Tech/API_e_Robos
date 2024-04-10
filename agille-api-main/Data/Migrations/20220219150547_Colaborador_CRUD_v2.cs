using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class Colaborador_CRUD_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "MunicipalRegistration",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "MunicipalRegistration",
                table: "JuridicalPerson",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("d25e6537-2f0f-47c8-994d-5a70918ba70f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 676, DateTimeKind.Local).AddTicks(6647), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1349928a-a072-42cd-a7ea-369fa7da9321"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(5643), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f4a5b5ac-5ada-4d2b-86c2-c7ed696aee54"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(5983), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f1456285-df25-4a68-9770-662b02ea108c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(6053), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9d0f1cab-af1d-4f4d-bc2c-690bfd9a5d34"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(6063), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("de65c7ba-5348-48cc-9e00-c2e7652e0acc"), "[[description]]", null, null, new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(6069), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("dd182ab0-a883-4b35-964a-ecb2331d9536"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(6075), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a9f0e648-8767-440f-926b-a33e13db16b2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(6080), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c84480b6-8af5-4496-a4da-b794a2a38ca5"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 19, 12, 5, 45, 686, DateTimeKind.Local).AddTicks(6085), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1349928a-a072-42cd-a7ea-369fa7da9321"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9d0f1cab-af1d-4f4d-bc2c-690bfd9a5d34"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a9f0e648-8767-440f-926b-a33e13db16b2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c84480b6-8af5-4496-a4da-b794a2a38ca5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d25e6537-2f0f-47c8-994d-5a70918ba70f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dd182ab0-a883-4b35-964a-ecb2331d9536"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("de65c7ba-5348-48cc-9e00-c2e7652e0acc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f1456285-df25-4a68-9770-662b02ea108c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f4a5b5ac-5ada-4d2b-86c2-c7ed696aee54"));

            migrationBuilder.DropColumn(
                name: "MunicipalRegistration",
                table: "JuridicalPerson");

            migrationBuilder.DropColumn(
                name: "IsSimplified",
                table: "ImportFile");

            migrationBuilder.AddColumn<string>(
                name: "MunicipalRegistration",
                table: "Address",
                type: "nvarchar(max)",
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
    }
}

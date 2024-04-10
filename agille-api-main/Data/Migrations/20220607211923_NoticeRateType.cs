using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NoticeRateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("44fcf8aa-13e2-4ad1-8332-ef6dd0773b6b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("59e3dea9-0f90-4c34-9ff3-7114fb5fb215"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("710a0787-6759-49b7-8533-366d354baabb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("832755a8-e3a7-48ba-96eb-406fb89d22f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97f13a75-1307-4772-aca0-475f3e181265"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3a5d235-d4af-4eed-abbd-a1aeb54d042e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cc68769e-6492-4a45-8574-89e8337f58b4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed7fcc55-6ff7-4d48-b0d3-f62d94a894f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("faf606a7-3d8c-4cc6-811b-1de41a594f0c"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Aliquot",
                table: "Notices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "RateType",
                table: "Notices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("05d17917-172b-4155-ad27-a57a38d2f76a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1948), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("31498287-218d-4c93-b038-63123e3007d6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1972), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("3cb63277-131f-410e-aa03-03e42ae00dfe"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1934), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("64c57a08-46e8-483a-a8d7-7157dd5d6792"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1946), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9c817d01-e6c1-491b-a2ff-a29c77b0df84"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1969), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a2e6f962-9610-451a-b29e-25df9290bfb4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1966), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("adf854c6-3e6f-487b-b730-e2dfa565ce10"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1949), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b6994bf8-4b19-4425-ab66-8e8e7c3b7483"), "[[description]]", null, null, new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1968), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c108e28f-52db-462f-bca3-c78ad572e510"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1970), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("05d17917-172b-4155-ad27-a57a38d2f76a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("31498287-218d-4c93-b038-63123e3007d6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3cb63277-131f-410e-aa03-03e42ae00dfe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("64c57a08-46e8-483a-a8d7-7157dd5d6792"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9c817d01-e6c1-491b-a2ff-a29c77b0df84"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a2e6f962-9610-451a-b29e-25df9290bfb4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("adf854c6-3e6f-487b-b730-e2dfa565ce10"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6994bf8-4b19-4425-ab66-8e8e7c3b7483"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c108e28f-52db-462f-bca3-c78ad572e510"));

            migrationBuilder.DropColumn(
                name: "RateType",
                table: "Notices");

            migrationBuilder.AlterColumn<double>(
                name: "Aliquot",
                table: "Notices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("44fcf8aa-13e2-4ad1-8332-ef6dd0773b6b"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2505), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("59e3dea9-0f90-4c34-9ff3-7114fb5fb215"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2484), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("710a0787-6759-49b7-8533-366d354baabb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2473), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("832755a8-e3a7-48ba-96eb-406fb89d22f2"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2503), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("97f13a75-1307-4772-aca0-475f3e181265"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2480), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a3a5d235-d4af-4eed-abbd-a1aeb54d042e"), "[[description]]", null, null, new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2483), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("cc68769e-6492-4a45-8574-89e8337f58b4"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2479), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ed7fcc55-6ff7-4d48-b0d3-f62d94a894f5"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2453), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("faf606a7-3d8c-4cc6-811b-1de41a594f0c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 2, 17, 38, 30, 343, DateTimeKind.Local).AddTicks(2475), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

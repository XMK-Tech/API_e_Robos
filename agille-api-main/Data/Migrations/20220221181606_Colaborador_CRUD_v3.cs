using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class Colaborador_CRUD_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivergencyEntry_DataCrossing_DataCrossingId",
                table: "DivergencyEntry");

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
                name: "County",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataCrossingId",
                table: "DivergencyEntry",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("f478a2d9-2eea-44b5-91f9-4b01f4459daa"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 336, DateTimeKind.Local).AddTicks(7362), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("effa1221-3806-496b-9140-398725db6ce3"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(754), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("daabf202-7dfc-42cb-9b70-29ee85eb4327"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(954), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6e2adaeb-ff5c-4cd3-ac33-a528cdf57149"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(964), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ed3acb88-702b-4b76-926c-e7ff388b7e02"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(970), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("91355e0c-c83a-4671-8c65-96715ab73b91"), "[[description]]", null, null, new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(976), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("1f3ba616-0b8c-479f-b6c7-5f649c829320"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(1033), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("05b94bc6-ebb8-44b6-96ce-3d80aa398572"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(1038), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c10e9ae5-30fc-4b32-b366-1c8b66565b0c"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 21, 15, 16, 4, 340, DateTimeKind.Local).AddTicks(1045), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DivergencyEntry_DataCrossing_DataCrossingId",
                table: "DivergencyEntry",
                column: "DataCrossingId",
                principalTable: "DataCrossing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivergencyEntry_DataCrossing_DataCrossingId",
                table: "DivergencyEntry");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("05b94bc6-ebb8-44b6-96ce-3d80aa398572"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1f3ba616-0b8c-479f-b6c7-5f649c829320"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6e2adaeb-ff5c-4cd3-ac33-a528cdf57149"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("91355e0c-c83a-4671-8c65-96715ab73b91"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c10e9ae5-30fc-4b32-b366-1c8b66565b0c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("daabf202-7dfc-42cb-9b70-29ee85eb4327"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ed3acb88-702b-4b76-926c-e7ff388b7e02"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("effa1221-3806-496b-9140-398725db6ce3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f478a2d9-2eea-44b5-91f9-4b01f4459daa"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DataCrossingId",
                table: "DivergencyEntry",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Address",
                type: "nvarchar(max)",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DivergencyEntry_DataCrossing_DataCrossingId",
                table: "DivergencyEntry",
                column: "DataCrossingId",
                principalTable: "DataCrossing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

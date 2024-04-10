using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CreateTaxStageSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3855b49b-09d6-4168-94a6-a644c1385420"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5f3e9178-19a3-4f94-91ed-8634a03ee217"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6ea2b399-acca-4a82-9ff1-26622ba6d148"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("73265ced-1862-42b7-b0c4-585982233fe5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("771d8c6f-7607-40b6-8595-0e2bba26500a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8961e327-7581-4039-a033-3e31e624e3f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b1237e2b-7c70-4065-8b09-a33574fb2409"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d9ccecf9-4367-4696-bda7-b7fe3c4c3893"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ef818404-bb84-4cac-abfb-4a3da50eec66"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "TaxStages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2044244f-958e-4a37-8b56-7db0aee934b3"), "[[description]]", null, null, new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(662), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("53f3871a-e7be-43df-8cad-c474c727b35f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(626), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5ac50e9b-6fab-4ae8-ac92-8eb9d4fa300d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(666), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("75e3a09d-f23c-4a56-aa44-24813421d930"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(660), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("83872bd3-5908-488a-acd7-29e1793bcadc"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(664), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9ada0520-ee98-41fc-b860-50310ac24647"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(643), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("beb5927f-b674-40a4-b8eb-16fc3290b4e7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(641), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cb379cd2-f37e-4703-a6e1-de2f467a9578"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(663), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f6481f98-d7af-414f-98b8-4f49e327e504"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 14, 19, 48, 32, 52, DateTimeKind.Local).AddTicks(645), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxStages_SubjectId",
                table: "TaxStages",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxStages_Person_SubjectId",
                table: "TaxStages",
                column: "SubjectId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxStages_Person_SubjectId",
                table: "TaxStages");

            migrationBuilder.DropIndex(
                name: "IX_TaxStages_SubjectId",
                table: "TaxStages");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2044244f-958e-4a37-8b56-7db0aee934b3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("53f3871a-e7be-43df-8cad-c474c727b35f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ac50e9b-6fab-4ae8-ac92-8eb9d4fa300d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("75e3a09d-f23c-4a56-aa44-24813421d930"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("83872bd3-5908-488a-acd7-29e1793bcadc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9ada0520-ee98-41fc-b860-50310ac24647"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("beb5927f-b674-40a4-b8eb-16fc3290b4e7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cb379cd2-f37e-4703-a6e1-de2f467a9578"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f6481f98-d7af-414f-98b8-4f49e327e504"));

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "TaxStages");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3855b49b-09d6-4168-94a6-a644c1385420"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2354), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("5f3e9178-19a3-4f94-91ed-8634a03ee217"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2342), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6ea2b399-acca-4a82-9ff1-26622ba6d148"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2357), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("73265ced-1862-42b7-b0c4-585982233fe5"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2341), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("771d8c6f-7607-40b6-8595-0e2bba26500a"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2323), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8961e327-7581-4039-a033-3e31e624e3f2"), "[[description]]", null, null, new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2353), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b1237e2b-7c70-4065-8b09-a33574fb2409"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2351), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d9ccecf9-4367-4696-bda7-b7fe3c4c3893"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2355), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ef818404-bb84-4cac-abfb-4a3da50eec66"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 14, 17, 31, 18, 152, DateTimeKind.Local).AddTicks(2349), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class DeclarationPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayerDeclarations_Propriety_ProprietyId",
                table: "TaxPayerDeclarations");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("099d6db2-d6da-4dab-948e-b2224d805671"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2f3b58c2-1f74-4027-98fe-9db9dd3aa0ca"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("342225f3-cf42-43c0-8239-18400cfc9132"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("441b73cb-ac51-4aa8-9c6a-aa71966b8380"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5e3ffb47-3d53-4bb3-ac2f-c77b6bf10b9e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("726bb1d2-4990-47e8-b7c2-ab075dc1f993"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97a7a016-a5ca-4a9a-bb81-d2119dd9f9dd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c1c3f4ae-9634-4c51-9d18-17c33ae97d25"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("feaea179-37e4-40fe-9789-c78b80591537"));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "TaxPayerDeclarations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "TaxPayerDeclarations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("509e493e-d416-4972-8280-e723c1454056"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5124), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("51f429b6-1ab7-4ad7-b9ef-65783bef2c87"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5158), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("565772fa-3ad4-44fa-b8ba-6ae27e596f1f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5155), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("5d7df43a-94cb-48dc-af4c-896bf29ee6ea"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5138), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6dd283fd-a506-452d-b6b0-a5895cd801a8"), "[[description]]", null, null, new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5144), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("8e80056a-8c6e-46ad-aee2-76f94903e629"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5141), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("94a75b4c-4a77-43e5-b54b-6fcd95a4214a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5140), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a13f99e7-48aa-441d-bfd2-2d39f05c7694"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5157), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f7b49139-6e35-45bb-b764-d8e8fc0c3074"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 23, 9, 3, 39, 675, DateTimeKind.Local).AddTicks(5143), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayerDeclarations_PersonId",
                table: "TaxPayerDeclarations",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayerDeclarations_Person_PersonId",
                table: "TaxPayerDeclarations",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayerDeclarations_Propriety_ProprietyId",
                table: "TaxPayerDeclarations",
                column: "ProprietyId",
                principalTable: "Propriety",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayerDeclarations_Person_PersonId",
                table: "TaxPayerDeclarations");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayerDeclarations_Propriety_ProprietyId",
                table: "TaxPayerDeclarations");

            migrationBuilder.DropIndex(
                name: "IX_TaxPayerDeclarations_PersonId",
                table: "TaxPayerDeclarations");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("509e493e-d416-4972-8280-e723c1454056"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("51f429b6-1ab7-4ad7-b9ef-65783bef2c87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("565772fa-3ad4-44fa-b8ba-6ae27e596f1f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5d7df43a-94cb-48dc-af4c-896bf29ee6ea"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6dd283fd-a506-452d-b6b0-a5895cd801a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e80056a-8c6e-46ad-aee2-76f94903e629"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("94a75b4c-4a77-43e5-b54b-6fcd95a4214a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a13f99e7-48aa-441d-bfd2-2d39f05c7694"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f7b49139-6e35-45bb-b764-d8e8fc0c3074"));

            migrationBuilder.DropColumn(
                name: "Number",
                table: "TaxPayerDeclarations");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "TaxPayerDeclarations");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("099d6db2-d6da-4dab-948e-b2224d805671"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1690), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2f3b58c2-1f74-4027-98fe-9db9dd3aa0ca"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1769), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("342225f3-cf42-43c0-8239-18400cfc9132"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1762), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("441b73cb-ac51-4aa8-9c6a-aa71966b8380"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1715), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5e3ffb47-3d53-4bb3-ac2f-c77b6bf10b9e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1713), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("726bb1d2-4990-47e8-b7c2-ab075dc1f993"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1764), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("97a7a016-a5ca-4a9a-bb81-d2119dd9f9dd"), "[[description]]", null, null, new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1765), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c1c3f4ae-9634-4c51-9d18-17c33ae97d25"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1768), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("feaea179-37e4-40fe-9789-c78b80591537"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1767), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayerDeclarations_Propriety_ProprietyId",
                table: "TaxPayerDeclarations",
                column: "ProprietyId",
                principalTable: "Propriety",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

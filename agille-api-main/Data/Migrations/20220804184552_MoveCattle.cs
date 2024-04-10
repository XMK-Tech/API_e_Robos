using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class MoveCattle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProprietyCattles_Propriety_ProprietyId",
                table: "ProprietyCattles");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1105c695-98a7-477c-af8f-e12e53ed1b60"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("13925444-23b6-4e8f-99a3-e5b50fd85d43"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c884b14-e24c-493a-b03f-adb35c410b9b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49824613-1efd-41eb-a269-82947516d470"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5ccaf6cf-8490-48bc-b55e-1d6890c95021"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aef11209-8a5f-4fad-be22-7dfd98e24da9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c767c0c8-6f1d-4c88-a7dc-7df35b7c4b5b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d725e001-0841-4220-bcec-e5b0448ba131"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f301dc09-0ca1-4d29-8fba-f52a8b4c656b"));

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "ProprietyCattles");

            migrationBuilder.RenameColumn(
                name: "ProprietyId",
                table: "ProprietyCattles",
                newName: "ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProprietyCattles_ProprietyId",
                table: "ProprietyCattles",
                newName: "IX_ProprietyCattles_ProcedureId");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "ProprietyCattles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("14131fb6-8354-4452-bd56-5a2ac3353e5f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1615), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("3ee8d2b3-d1e1-44d8-9c52-1878aca850ef"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1579), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("55206045-c835-497a-af2f-5e07f35425d2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1601), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("57de6c63-79e5-458f-be88-6c8a15877a7a"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1617), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5c059f80-0053-43a6-a927-201e499d2e4c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1598), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("77d58104-d412-4d84-bffa-3d9e394130c7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1616), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("84c2e815-77fe-4d27-b81f-42cf02f61611"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1596), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("951bb711-a409-4aab-a68b-1a92d4fb4e40"), "[[description]]", null, null, new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1603), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("df007222-0454-49ff-b51c-f342abd80d24"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 4, 15, 45, 51, 117, DateTimeKind.Local).AddTicks(1600), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14131fb6-8354-4452-bd56-5a2ac3353e5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3ee8d2b3-d1e1-44d8-9c52-1878aca850ef"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55206045-c835-497a-af2f-5e07f35425d2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("57de6c63-79e5-458f-be88-6c8a15877a7a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5c059f80-0053-43a6-a927-201e499d2e4c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("77d58104-d412-4d84-bffa-3d9e394130c7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("84c2e815-77fe-4d27-b81f-42cf02f61611"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("951bb711-a409-4aab-a68b-1a92d4fb4e40"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("df007222-0454-49ff-b51c-f342abd80d24"));

            migrationBuilder.DropColumn(
                name: "Month",
                table: "ProprietyCattles");

            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "ProprietyCattles",
                newName: "ProprietyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProprietyCattles_ProcedureId",
                table: "ProprietyCattles",
                newName: "IX_ProprietyCattles_ProprietyId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Reference",
                table: "ProprietyCattles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1105c695-98a7-477c-af8f-e12e53ed1b60"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5588), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("13925444-23b6-4e8f-99a3-e5b50fd85d43"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5574), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c884b14-e24c-493a-b03f-adb35c410b9b"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5571), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("49824613-1efd-41eb-a269-82947516d470"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5576), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5ccaf6cf-8490-48bc-b55e-1d6890c95021"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5552), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("aef11209-8a5f-4fad-be22-7dfd98e24da9"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5590), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c767c0c8-6f1d-4c88-a7dc-7df35b7c4b5b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5587), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d725e001-0841-4220-bcec-e5b0448ba131"), "[[description]]", null, null, new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5586), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f301dc09-0ca1-4d29-8fba-f52a8b4c656b"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 29, 20, 21, 7, 357, DateTimeKind.Local).AddTicks(5573), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProprietyCattles_Propriety_ProprietyId",
                table: "ProprietyCattles",
                column: "ProprietyId",
                principalTable: "Propriety",
                principalColumn: "Id");
        }
    }
}

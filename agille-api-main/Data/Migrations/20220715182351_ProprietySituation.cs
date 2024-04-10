using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ProprietySituation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Situation",
                table: "Propriety",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3e00f16a-1149-4988-90e2-ec7da8e81121"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(395), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("49812518-3060-48c4-a8fa-bda30e852998"), "[[description]]", null, null, new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(394), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("4dbc6fa9-1ba9-422c-90b4-c9ddfee9ab96"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(405), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("801a9170-36af-4d39-8595-a74d3a805685"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(407), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("9fc427e2-0eeb-439b-8349-d78398f1f89c"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(391), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d07e281f-0826-4218-a002-83984f0386ff"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(374), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("db0c01b1-0d26-422b-97af-9e7427cb85f4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(393), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("dddc2e04-91ee-4427-a59c-c2d8cbfc3388"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(389), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e845af8f-2a7b-4834-b7a5-e4a3ead9c882"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 15, 15, 23, 49, 760, DateTimeKind.Local).AddTicks(387), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e00f16a-1149-4988-90e2-ec7da8e81121"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("49812518-3060-48c4-a8fa-bda30e852998"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4dbc6fa9-1ba9-422c-90b4-c9ddfee9ab96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("801a9170-36af-4d39-8595-a74d3a805685"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fc427e2-0eeb-439b-8349-d78398f1f89c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d07e281f-0826-4218-a002-83984f0386ff"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("db0c01b1-0d26-422b-97af-9e7427cb85f4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddc2e04-91ee-4427-a59c-c2d8cbfc3388"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e845af8f-2a7b-4834-b7a5-e4a3ead9c882"));

            migrationBuilder.DropColumn(
                name: "Situation",
                table: "Propriety");

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
        }
    }
}

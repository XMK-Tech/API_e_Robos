using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixCardCrossing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardCrossing_User_RequestingUserId",
                table: "CardCrossing");

            migrationBuilder.DropIndex(
                name: "IX_CardCrossing_RequestingUserId",
                table: "CardCrossing");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0e0f4a65-f961-498b-a17f-a37c42bc5749"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("118792e3-45c4-41fe-8cc8-439e97b9dee1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("22c6a9cd-2f52-4b95-89d2-86d4f5ea87e8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("36236022-f7a2-42d7-9a05-bf7c47103618"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("393a7a2b-9773-4144-8024-91917709cd96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5da9fee9-8096-4991-8e9e-dc51fdaa0245"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7dd5aa26-1f26-48c7-8a7a-04d537cbd8a0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e1b8857e-2eef-4189-9ef0-72ad8c724086"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f53f1464-006c-4074-b49f-59183791e32e"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("07c2df0f-f696-4a75-92e6-83f9cbdcef02"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3103), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("14dd8627-52ec-417b-9090-4ac472144f42"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3075), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2ccd4dc3-6f59-408c-ad69-593b2ace1aa2"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3070), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5b315ee8-583e-40e4-9530-e5f67c6f3056"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3037), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("64a064cb-65fb-4a40-b1f9-d7e146e10940"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3094), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7cfb420d-0f43-407d-96b6-24215f2e3816"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3082), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("83fbe9e4-f501-47af-97db-712423e5bd13"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3090), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("91c38c07-26a6-45ae-94a0-2307e582b3d1"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3079), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a496e8df-20a6-46a3-9c2f-9f7600678f94"), "[[description]]", null, null, new DateTime(2022, 4, 29, 18, 52, 2, 87, DateTimeKind.Local).AddTicks(3086), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("07c2df0f-f696-4a75-92e6-83f9cbdcef02"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14dd8627-52ec-417b-9090-4ac472144f42"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2ccd4dc3-6f59-408c-ad69-593b2ace1aa2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5b315ee8-583e-40e4-9530-e5f67c6f3056"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("64a064cb-65fb-4a40-b1f9-d7e146e10940"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7cfb420d-0f43-407d-96b6-24215f2e3816"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("83fbe9e4-f501-47af-97db-712423e5bd13"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("91c38c07-26a6-45ae-94a0-2307e582b3d1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a496e8df-20a6-46a3-9c2f-9f7600678f94"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0e0f4a65-f961-498b-a17f-a37c42bc5749"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1773), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("118792e3-45c4-41fe-8cc8-439e97b9dee1"), "[[description]]", null, null, new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1786), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("22c6a9cd-2f52-4b95-89d2-86d4f5ea87e8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1787), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("36236022-f7a2-42d7-9a05-bf7c47103618"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1758), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("393a7a2b-9773-4144-8024-91917709cd96"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1790), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5da9fee9-8096-4991-8e9e-dc51fdaa0245"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1789), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("7dd5aa26-1f26-48c7-8a7a-04d537cbd8a0"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1770), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e1b8857e-2eef-4189-9ef0-72ad8c724086"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1775), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f53f1464-006c-4074-b49f-59183791e32e"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 29, 18, 40, 44, 289, DateTimeKind.Local).AddTicks(1772), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCrossing_RequestingUserId",
                table: "CardCrossing",
                column: "RequestingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardCrossing_User_RequestingUserId",
                table: "CardCrossing",
                column: "RequestingUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

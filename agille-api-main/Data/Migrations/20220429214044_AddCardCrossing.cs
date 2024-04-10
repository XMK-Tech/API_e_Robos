using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddCardCrossing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0a5f285d-e410-45cf-b34e-164a525bf540"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("10ffc789-5929-4a88-abe3-81b8f4c47045"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1d1c0865-d7b1-46a4-a731-9886c79dcd66"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("231996a5-c211-4a6c-868a-5d59b01f6855"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("40e86e3f-d654-46b0-a45d-b62df96af48f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("67743fb0-7304-421c-83d4-7ed34969f8c7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b2b64c16-904b-4e43-99ef-5c39a065d0e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c3b2aa3d-b7ad-4533-9bf8-48ea67e0022c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f6d5a51e-25a3-49fa-ad59-a271eba047ca"));

            migrationBuilder.CreateTable(
                name: "CardCrossing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionsCount = table.Column<int>(type: "int", nullable: false),
                    StartingReference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingReference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestingUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCrossing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardCrossing_JuridicalPerson_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardCrossing_User_RequestingUserId",
                        column: x => x.RequestingUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_CardCrossing_OperatorId",
                table: "CardCrossing",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CardCrossing_RequestingUserId",
                table: "CardCrossing",
                column: "RequestingUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCrossing");

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
                    { new Guid("0a5f285d-e410-45cf-b34e-164a525bf540"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3352), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("10ffc789-5929-4a88-abe3-81b8f4c47045"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3358), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("1d1c0865-d7b1-46a4-a731-9886c79dcd66"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3354), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("231996a5-c211-4a6c-868a-5d59b01f6855"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3374), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("40e86e3f-d654-46b0-a45d-b62df96af48f"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3356), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("67743fb0-7304-421c-83d4-7ed34969f8c7"), "[[description]]", null, null, new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3360), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b2b64c16-904b-4e43-99ef-5c39a065d0e6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3378), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c3b2aa3d-b7ad-4533-9bf8-48ea67e0022c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3376), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f6d5a51e-25a3-49fa-ad59-a271eba047ca"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 28, 15, 57, 47, 303, DateTimeKind.Local).AddTicks(3339), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

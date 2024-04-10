using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RubricM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("245eea86-3c0b-4f53-bf9e-cb9106214a47"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c63c34f-0ebc-46cd-b12b-64f8dfdb2f09"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("53fbf41d-c868-4bff-9417-0bb413c17d80"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56e9bc2f-5828-4e4f-b08b-ba9e51666c5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("60343580-ad01-41e3-bbfc-06e7887f82d7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("826b5173-d589-4d3d-abf9-b5d832b74917"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b4768979-0ab1-45ac-bdce-9af9bcf27127"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("efa2499d-b7d7-4769-af67-93750c6e1d85"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f609b3e8-6afc-4ad6-b90a-3d2061c95510"));

            migrationBuilder.CreateTable(
                name: "Rubrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rubrics_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RubricAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OriginOfBalance = table.Column<int>(type: "int", nullable: false),
                    Classifications = table.Column<bool>(type: "bit", nullable: false),
                    RubricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubricAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RubricAccounts_Rubrics_RubricId",
                        column: x => x.RubricId,
                        principalTable: "Rubrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0ed28e6a-bbd9-4165-b80e-5ca0917c7faa"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4861), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("369e164a-6cae-42e8-837e-2ce85b0ae29c"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4871), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4c734644-bfef-4f6d-be7c-3a0462e44e2c"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4873), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5131de7a-f662-4754-b814-acf9c3255e39"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4876), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a64a227d-bab0-4a8b-8314-87d2579f611e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4859), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b0e77212-2e7d-48db-a2c4-20e18d45eae6"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4878), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("bc522b97-583a-4034-8603-18b4fb0c7e1c"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4877), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d7715a21-b87a-4a78-b3ef-2ebddb07e772"), "[[description]]", null, null, new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4874), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("e3482a70-e46f-4508-b136-1ca8be44fefa"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 4, 9, 33, 33, 560, DateTimeKind.Local).AddTicks(4842), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RubricAccounts_RubricId",
                table: "RubricAccounts",
                column: "RubricId");

            migrationBuilder.CreateIndex(
                name: "IX_Rubrics_StateId",
                table: "Rubrics",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RubricAccounts");

            migrationBuilder.DropTable(
                name: "Rubrics");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0ed28e6a-bbd9-4165-b80e-5ca0917c7faa"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("369e164a-6cae-42e8-837e-2ce85b0ae29c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c734644-bfef-4f6d-be7c-3a0462e44e2c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5131de7a-f662-4754-b814-acf9c3255e39"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a64a227d-bab0-4a8b-8314-87d2579f611e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b0e77212-2e7d-48db-a2c4-20e18d45eae6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bc522b97-583a-4034-8603-18b4fb0c7e1c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d7715a21-b87a-4a78-b3ef-2ebddb07e772"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e3482a70-e46f-4508-b136-1ca8be44fefa"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("245eea86-3c0b-4f53-bf9e-cb9106214a47"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8886), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c63c34f-0ebc-46cd-b12b-64f8dfdb2f09"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8861), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("53fbf41d-c868-4bff-9417-0bb413c17d80"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8894), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("56e9bc2f-5828-4e4f-b08b-ba9e51666c5f"), "[[description]]", null, null, new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8888), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("60343580-ad01-41e3-bbfc-06e7887f82d7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8878), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("826b5173-d589-4d3d-abf9-b5d832b74917"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8889), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b4768979-0ab1-45ac-bdce-9af9bcf27127"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8883), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("efa2499d-b7d7-4769-af67-93750c6e1d85"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8885), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f609b3e8-6afc-4ad6-b90a-3d2061c95510"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 3, 9, 5, 48, 775, DateTimeKind.Local).AddTicks(8891), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}

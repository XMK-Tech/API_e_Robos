using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddCompanyCardRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("109ac90f-884b-42b5-b967-2a7aefbaa765"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("40b37410-e7f6-4dff-948f-6e1b747fc01a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45a23180-b7d7-4252-89ee-5e7b49b96a01"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("69f6d73c-4b90-4004-8808-e24271b15d05"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("82135c9f-4856-4359-9579-30db552833e0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87da6d0d-54b2-42e4-b30b-9f07b8fb976a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9028599b-df2f-48c7-9be7-6f26ccc859cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c978a021-f1a7-4c82-9a62-903fdf494e2e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e770c720-e7ac-4334-b415-e42faf8c1b5d"));

            migrationBuilder.AddColumn<string>(
                name: "CardOperatorDocument",
                table: "TransactionEntry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CardRate",
                table: "JuridicalPerson",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCardOperator",
                table: "JuridicalPerson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CompanyCardRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardOperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCardRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCardRate_JuridicalPerson_CardOperatorId",
                        column: x => x.CardOperatorId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCardRate_JuridicalPerson_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCardRate_CardOperatorId",
                table: "CompanyCardRate",
                column: "CardOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCardRate_CompanyId",
                table: "CompanyCardRate",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyCardRate");

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

            migrationBuilder.DropColumn(
                name: "CardOperatorDocument",
                table: "TransactionEntry");

            migrationBuilder.DropColumn(
                name: "CardRate",
                table: "JuridicalPerson");

            migrationBuilder.DropColumn(
                name: "IsCardOperator",
                table: "JuridicalPerson");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("109ac90f-884b-42b5-b967-2a7aefbaa765"), "[[person-document]]", "Document", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4720), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("40b37410-e7f6-4dff-948f-6e1b747fc01a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4739), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("45a23180-b7d7-4252-89ee-5e7b49b96a01"), "[[person-name]]", "Name", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4717), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("69f6d73c-4b90-4004-8808-e24271b15d05"), "[[description]]", null, null, new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4725), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("82135c9f-4856-4359-9579-30db552833e0"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4647), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("87da6d0d-54b2-42e4-b30b-9f07b8fb976a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4735), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9028599b-df2f-48c7-9be7-6f26ccc859cc"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 103, DateTimeKind.Local).AddTicks(6202), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c978a021-f1a7-4c82-9a62-903fdf494e2e"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4723), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e770c720-e7ac-4334-b415-e42faf8c1b5d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 4, 18, 14, 58, 39, 104, DateTimeKind.Local).AddTicks(4741), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}

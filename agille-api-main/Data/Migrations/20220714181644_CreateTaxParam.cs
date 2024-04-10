using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CreateTaxParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("02ed19f0-7b45-4185-94eb-2c92849695e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21c8fe5b-c67f-4058-ab6f-546f5fd01433"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3cddb23c-56bb-4ba3-a3e7-d8f6020c5e50"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42a2f4f7-c23e-40c7-a52f-3f30b8b68ff9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6fe21599-ab79-43f7-bfb1-c37c8b6761fd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("778a2a78-ec7d-42d5-a778-882ac63d1940"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ab740a0f-c98f-4d48-9190-932bdb674231"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d82a352a-7b75-47ac-a1d2-8b596df22906"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec8e58c7-0c9c-45ec-a48d-46a210e9895b"));

            migrationBuilder.DropColumn(
                name: "ParamType",
                table: "TaxProcedure");

            migrationBuilder.CreateTable(
                name: "TaxParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParamType = table.Column<int>(type: "int", nullable: false),
                    TaxProcedureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxParams_TaxProcedure_TaxProcedureId",
                        column: x => x.TaxProcedureId,
                        principalTable: "TaxProcedure",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1309abe4-59f0-4901-a161-b6c63ee77fa6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5566), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("15492e72-20d6-401d-af82-2117a4045aec"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5547), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("32351e42-cf59-4ae5-aa58-85e50361b14e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5544), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3d641269-6cd1-499b-a505-04bd79058fba"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5540), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6da2b120-2bbc-4efa-9801-3e73bc68654b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5563), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8f6c73c1-c95e-44e6-8b89-10f96a701cf4"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5570), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("9b6549f3-c589-4d06-a979-512a77c0eea7"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5542), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a77f8096-5e1c-4a1d-af46-65a3277e59d1"), "[[description]]", null, null, new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5549), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("aacdbc08-6a79-440a-9ec4-3a24b2351a47"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 14, 15, 16, 43, 591, DateTimeKind.Local).AddTicks(5521), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxParams_TaxProcedureId",
                table: "TaxParams",
                column: "TaxProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxParams");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1309abe4-59f0-4901-a161-b6c63ee77fa6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("15492e72-20d6-401d-af82-2117a4045aec"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("32351e42-cf59-4ae5-aa58-85e50361b14e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3d641269-6cd1-499b-a505-04bd79058fba"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6da2b120-2bbc-4efa-9801-3e73bc68654b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8f6c73c1-c95e-44e6-8b89-10f96a701cf4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9b6549f3-c589-4d06-a979-512a77c0eea7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a77f8096-5e1c-4a1d-af46-65a3277e59d1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aacdbc08-6a79-440a-9ec4-3a24b2351a47"));

            migrationBuilder.AddColumn<int>(
                name: "ParamType",
                table: "TaxProcedure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("02ed19f0-7b45-4185-94eb-2c92849695e6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5533), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("21c8fe5b-c67f-4058-ab6f-546f5fd01433"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5524), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3cddb23c-56bb-4ba3-a3e7-d8f6020c5e50"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5477), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("42a2f4f7-c23e-40c7-a52f-3f30b8b68ff9"), "[[description]]", null, null, new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5530), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6fe21599-ab79-43f7-bfb1-c37c8b6761fd"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5534), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("778a2a78-ec7d-42d5-a778-882ac63d1940"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5526), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ab740a0f-c98f-4d48-9190-932bdb674231"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5521), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d82a352a-7b75-47ac-a1d2-8b596df22906"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5531), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ec8e58c7-0c9c-45ec-a48d-46a210e9895b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5528), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }
    }
}

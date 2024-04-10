using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CreateCoordenate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("00bf261b-8ec6-4cd9-9633-a32d7f9341cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0b8bd282-c9ac-4163-a4f4-e996c6bae9f7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21331873-7ed3-406d-8920-a887bbed03df"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8458ac22-b218-488c-9a24-43247b0d9e8d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3386b44-a848-4064-8f8f-a5fd6c1099b1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6335b8b-3446-4d07-8d87-9159cc42833a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf174a1a-c389-48ae-ad95-6d3bc3ff53a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f9689929-f683-4df8-9245-261fa82f5844"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("faada050-983b-40b5-91f7-118ad23469dd"));

            migrationBuilder.CreateTable(
                name: "Coordenates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lng = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProprietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordenates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordenates_Propriety_ProprietyId",
                        column: x => x.ProprietyId,
                        principalTable: "Propriety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1404606a-6e05-4c7c-af73-0f7f1fc56eb9"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9925), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("29da66ac-fee8-4ded-829a-92f32c5a91bc"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9929), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("61201acf-0fcc-41d1-a805-985826d27610"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9931), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("669433ba-162b-469f-ab59-991588653684"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9910), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7e9cfb8e-ef65-4555-ba8f-98948cd76da1"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9926), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("905942ff-a8be-4371-b1a5-9899f85d06ac"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9908), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b456c52f-ab5a-4ec2-a58b-b0fb4da8fb73"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9891), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b6c5524c-bef0-48ab-ae2b-38c3d35d0df4"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9932), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("edde2d60-5a3f-46bb-ad20-1bbbfe622dfb"), "[[description]]", null, null, new DateTime(2022, 7, 1, 14, 56, 57, 769, DateTimeKind.Local).AddTicks(9928), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordenates_ProprietyId",
                table: "Coordenates",
                column: "ProprietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordenates");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1404606a-6e05-4c7c-af73-0f7f1fc56eb9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("29da66ac-fee8-4ded-829a-92f32c5a91bc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("61201acf-0fcc-41d1-a805-985826d27610"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("669433ba-162b-469f-ab59-991588653684"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7e9cfb8e-ef65-4555-ba8f-98948cd76da1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("905942ff-a8be-4371-b1a5-9899f85d06ac"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b456c52f-ab5a-4ec2-a58b-b0fb4da8fb73"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6c5524c-bef0-48ab-ae2b-38c3d35d0df4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("edde2d60-5a3f-46bb-ad20-1bbbfe622dfb"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("00bf261b-8ec6-4cd9-9633-a32d7f9341cf"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7478), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("0b8bd282-c9ac-4163-a4f4-e996c6bae9f7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7476), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("21331873-7ed3-406d-8920-a887bbed03df"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7464), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8458ac22-b218-488c-9a24-43247b0d9e8d"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7461), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b3386b44-a848-4064-8f8f-a5fd6c1099b1"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7460), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b6335b8b-3446-4d07-8d87-9159cc42833a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7474), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("bf174a1a-c389-48ae-ad95-6d3bc3ff53a3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7463), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("f9689929-f683-4df8-9245-261fa82f5844"), "[[description]]", null, null, new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7465), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("faada050-983b-40b5-91f7-118ad23469dd"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 29, 18, 53, 20, 81, DateTimeKind.Local).AddTicks(7444), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

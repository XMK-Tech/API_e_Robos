using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class OperatorServer_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("19a08d3c-e47d-4839-ac46-d38a642cfbab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("339ab83f-0b12-4cf6-bb18-210daf6e48b2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3638ff69-1bc3-45b4-9e0b-f3d31aa53c04"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("648fd6e1-b7c7-4096-9702-bded7322ddc8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("749fafef-9959-4338-8483-f3bb447898f6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("967d541f-5983-4b35-805f-e29ecf0b5520"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a582bd07-18d5-48ba-b79b-f5e58c02aeff"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d336f657-b572-4c44-acaf-0445b744c991"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fd7fd5c9-261e-4c16-a185-c1c4a77922cc"));

            migrationBuilder.AddColumn<string>(
                name: "AgiPrevCode",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgiPrevPersonType",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operator_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Server",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CTPSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTPSSeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIS_PASEPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerCategory = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Server_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0e4c01e4-737f-4683-a834-2924be5ca02f"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5721), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3c92f158-b376-4fd4-884a-728f90893117"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5722), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("96a198f4-ef57-4047-9870-f8328ae98d34"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5724), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9820f6de-5027-410b-b23b-6dba6461cb96"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5742), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9fb00898-baca-41a8-9cf4-552883a789b3"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5743), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("b0963e49-6f75-4c6c-95e1-443247ea7acc"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5719), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f627f2e4-f99c-439f-8bc9-57f032bffada"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5437), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fc23e503-8395-4221-9802-f2149265e3fe"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5740), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ffeced63-3fab-4eaf-b449-1c81f0673f83"), "[[description]]", null, null, new DateTime(2023, 5, 31, 19, 37, 0, 37, DateTimeKind.Local).AddTicks(5725), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operator_PersonId",
                table: "Operator",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Server_PersonId",
                table: "Server",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "Server");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0e4c01e4-737f-4683-a834-2924be5ca02f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3c92f158-b376-4fd4-884a-728f90893117"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("96a198f4-ef57-4047-9870-f8328ae98d34"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9820f6de-5027-410b-b23b-6dba6461cb96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9fb00898-baca-41a8-9cf4-552883a789b3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b0963e49-6f75-4c6c-95e1-443247ea7acc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f627f2e4-f99c-439f-8bc9-57f032bffada"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fc23e503-8395-4221-9802-f2149265e3fe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffeced63-3fab-4eaf-b449-1c81f0673f83"));

            migrationBuilder.DropColumn(
                name: "AgiPrevCode",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AgiPrevPersonType",
                table: "Person");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("19a08d3c-e47d-4839-ac46-d38a642cfbab"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3676), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("339ab83f-0b12-4cf6-bb18-210daf6e48b2"), "[[person-document]]", "Document", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3655), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3638ff69-1bc3-45b4-9e0b-f3d31aa53c04"), "[[person-name]]", "Name", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3653), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("648fd6e1-b7c7-4096-9702-bded7322ddc8"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3658), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("749fafef-9959-4338-8483-f3bb447898f6"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3518), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("967d541f-5983-4b35-805f-e29ecf0b5520"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3672), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a582bd07-18d5-48ba-b79b-f5e58c02aeff"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3682), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("d336f657-b572-4c44-acaf-0445b744c991"), "[[description]]", null, null, new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3670), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("fd7fd5c9-261e-4c16-a185-c1c4a77922cc"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 5, 29, 20, 18, 40, 464, DateTimeKind.Local).AddTicks(3651), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}

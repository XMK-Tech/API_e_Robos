using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class Cultures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CultureTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CultureDeclarations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaleCount = table.Column<int>(type: "int", nullable: false),
                    FemaleCount = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxProcedureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultureDeclarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CultureDeclarations_CultureTypes_CultureId",
                        column: x => x.CultureId,
                        principalTable: "CultureTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CultureDeclarations_TaxProcedure_TaxProcedureId",
                        column: x => x.TaxProcedureId,
                        principalTable: "TaxProcedure",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CultureDeclarations_CultureId",
                table: "CultureDeclarations",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_CultureDeclarations_TaxProcedureId",
                table: "CultureDeclarations",
                column: "TaxProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CultureDeclarations");

            migrationBuilder.DropTable(
                name: "CultureTypes");
        }
    }
}

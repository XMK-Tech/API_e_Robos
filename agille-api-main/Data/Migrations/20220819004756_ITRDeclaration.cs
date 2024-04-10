using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ITRDeclaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BareLandValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GoodAptitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegularAptitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RestrictedFitness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlantedPastures = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ForestryOrNaturalPasture = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreservationOfFaunaOrFlora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BareLandValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayerDeclarations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProprietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnvironmentalPreservation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalReserveArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaOccupiedWithWorks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsableArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaWithReforestation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaUsedInRuralActivity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayerDeclarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPayerDeclarations_Propriety_ProprietyId",
                        column: x => x.ProprietyId,
                        principalTable: "Propriety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayerDeclarations_ProprietyId",
                table: "TaxPayerDeclarations",
                column: "ProprietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BareLandValues");

            migrationBuilder.DropTable(
                name: "TaxPayerDeclarations");
        }
    }
}

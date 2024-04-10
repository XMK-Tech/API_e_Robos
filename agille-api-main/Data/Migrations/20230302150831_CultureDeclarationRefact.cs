using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CultureDeclarationRefact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultureDeclarations_TaxProcedure_TaxProcedureId",
                table: "CultureDeclarations");        

            migrationBuilder.RenameColumn(
                name: "TaxProcedureId",
                table: "CultureDeclarations",
                newName: "ProprietyId");

            migrationBuilder.RenameIndex(
                name: "IX_CultureDeclarations_TaxProcedureId",
                table: "CultureDeclarations",
                newName: "IX_CultureDeclarations_ProprietyId");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "CultureDeclarations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CultureDeclarations_Propriety_ProprietyId",
                table: "CultureDeclarations",
                column: "ProprietyId",
                principalTable: "Propriety",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultureDeclarations_Propriety_ProprietyId",
                table: "CultureDeclarations");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "CultureDeclarations");

            migrationBuilder.RenameColumn(
                name: "ProprietyId",
                table: "CultureDeclarations",
                newName: "TaxProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_CultureDeclarations_ProprietyId",
                table: "CultureDeclarations",
                newName: "IX_CultureDeclarations_TaxProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_CultureDeclarations_TaxProcedure_TaxProcedureId",
                table: "CultureDeclarations",
                column: "TaxProcedureId",
                principalTable: "TaxProcedure",
                principalColumn: "Id");
        }
    }
}

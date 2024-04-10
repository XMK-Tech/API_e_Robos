using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class DivergenciesInvalidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInvalid",
                table: "DivergencyEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvalid",
                table: "CardDivergencyEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvalid",
                table: "DivergencyEntry");

            migrationBuilder.DropColumn(
                name: "IsInvalid",
                table: "CardDivergencyEntry");
        }
    }
}

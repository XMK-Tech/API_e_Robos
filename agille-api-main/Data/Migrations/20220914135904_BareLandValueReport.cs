using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class BareLandValueReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Report",
                table: "BareLandValues",
                type: "nvarchar(max)",
                nullable: true);          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {       
            migrationBuilder.DropColumn(
                name: "Report",
                table: "BareLandValues");
        }
    }
}

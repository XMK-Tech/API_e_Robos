using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CultureFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CultureTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "CultureTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CultureTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "CultureTypes");
        }
    }
}

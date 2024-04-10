using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class PersonNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Person");
        }
    }
}

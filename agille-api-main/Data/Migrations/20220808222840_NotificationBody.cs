using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class NotificationBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Notifications");
        }
    }
}

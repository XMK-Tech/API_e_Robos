using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ChangeCardDivergencyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "CardDivergencyEntry");

            migrationBuilder.AddColumn<bool>(
                name: "OperatorIsRegistered",
                table: "CardDivergencyEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorIsRegistered",
                table: "CardDivergencyEntry");

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorId",
                table: "CardDivergencyEntry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

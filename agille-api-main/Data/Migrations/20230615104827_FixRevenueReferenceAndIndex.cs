using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixRevenueReferenceAndIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Reference",
                table: "Revenues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // move starting reference to reference
            migrationBuilder.Sql(@"UPDATE [dbo].[Revenues] SET [Reference] = [StartingReference]");

            migrationBuilder.DropColumn(
                name: "EndingReference",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "StartingReference",
                table: "Revenues");

            migrationBuilder.AlterColumn<int>(
                name: "Index",
                table: "Revenues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Revenues",
                newName: "StartingReference");

            migrationBuilder.AlterColumn<int>(
                name: "Index",
                table: "Revenues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingReference",
                table: "Revenues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

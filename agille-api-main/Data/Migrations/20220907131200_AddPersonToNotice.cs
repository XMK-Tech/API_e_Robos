using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddPersonToNotice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Notices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notices_PersonId",
                table: "Notices",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Person_PersonId",
                table: "Notices",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Person_PersonId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_PersonId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Notices");
        }
    }
}

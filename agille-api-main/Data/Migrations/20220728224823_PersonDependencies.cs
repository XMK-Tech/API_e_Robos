using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class PersonDependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryPerson",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "InventoryPersonDocument",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LegalRepresentative",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LegalRepresentativeDocument",
                table: "Person");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryPersonId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LegalRepresentativeId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_InventoryPersonId",
                table: "Person",
                column: "InventoryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_LegalRepresentativeId",
                table: "Person",
                column: "LegalRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_InventoryPersonId",
                table: "Person",
                column: "InventoryPersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_LegalRepresentativeId",
                table: "Person",
                column: "LegalRepresentativeId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_InventoryPersonId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_LegalRepresentativeId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_InventoryPersonId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_LegalRepresentativeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "InventoryPersonId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LegalRepresentativeId",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "InventoryPerson",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryPersonDocument",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalRepresentative",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalRepresentativeDocument",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}

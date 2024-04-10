using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ReplyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxStages_ReplyToId",
                table: "TaxStages");

            migrationBuilder.CreateIndex(
                name: "IX_TaxStages_ReplyToId",
                table: "TaxStages",
                column: "ReplyToId",
                unique: true,
                filter: "[ReplyToId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxStages_ReplyToId",
                table: "TaxStages");

            migrationBuilder.CreateIndex(
                name: "IX_TaxStages_ReplyToId",
                table: "TaxStages",
                column: "ReplyToId");
        }
    }
}

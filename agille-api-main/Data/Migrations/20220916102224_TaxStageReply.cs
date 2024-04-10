using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class TaxStageReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "TaxStages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CutOffDate",
                table: "TaxStages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "AnsweredById",
                table: "TaxStages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReplyToId",
                table: "TaxStages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxStages_ReplyToId",
                table: "TaxStages",
                column: "ReplyToId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxStages_TaxStages_ReplyToId",
                table: "TaxStages",
                column: "ReplyToId",
                principalTable: "TaxStages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxStages_TaxStages_ReplyToId",
                table: "TaxStages");

            migrationBuilder.DropIndex(
                name: "IX_TaxStages_ReplyToId",
                table: "TaxStages");

            migrationBuilder.DropColumn(
                name: "AnsweredById",
                table: "TaxStages");

            migrationBuilder.DropColumn(
                name: "ReplyToId",
                table: "TaxStages");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "TaxStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CutOffDate",
                table: "TaxStages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}

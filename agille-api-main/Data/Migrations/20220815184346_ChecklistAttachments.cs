using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ChecklistAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChecklistAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChecklistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChecklistId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistAttachments_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistAttachments_Checklists_ChecklistId1",
                        column: x => x.ChecklistId1,
                        principalTable: "Checklists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAttachments_AttachmentId",
                table: "ChecklistAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAttachments_ChecklistId",
                table: "ChecklistAttachments",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAttachments_ChecklistId1",
                table: "ChecklistAttachments",
                column: "ChecklistId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistAttachments");
        }
    }
}

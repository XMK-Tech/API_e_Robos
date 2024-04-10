using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class MoveStageAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[TaxStageAttachments]
                                               ([Id]
                                               ,[AttachmentId]
                                               ,[TaxStageId]
                                               ,[CreatedAt]
                                               ,[LastUpdateAt])
                                    SELECT NEWID()
                                           ,stage.AttachmentId
                                           ,stage.Id
                                           ,GETDATE()
                                           ,'0001-01-01'
                                    FROM [dbo].[TaxStages] stage
                                    WHERE stage.AttachmentId IS NOT NULL
                                      AND NOT EXISTS (
                                        SELECT 1
                                        FROM [dbo].[TaxStageAttachments] tsa
                                        WHERE tsa.AttachmentId = stage.AttachmentId
                                          AND tsa.TaxStageId = stage.Id
                                    )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}

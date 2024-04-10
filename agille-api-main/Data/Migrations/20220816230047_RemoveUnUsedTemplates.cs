using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RemoveUnUsedTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var ids = new List<Guid>() { Guid.Parse("088D8474-55FC-4EB9-A7D4-F4B9A15D1ACC"), Guid.Parse("A6D9D897-0E0E-481E-AD0B-FD46D5596E9A"), Guid.Parse("5cb4e053-1115-4580-aec4-c1a243f64d1e") };

            ids.ForEach(id =>
            {
                migrationBuilder.Sql(@$"DELETE FROM [dbo].[NoticeTemplates]
                                            WHERE[Id] = '{id}'");
            });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class DefaultCultures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entities = new List<CultureType>()
            {
                new CultureType("Arroz", null, CultureTypeOptions.Agriculture, true, true),
                new CultureType("Soja", null, CultureTypeOptions.Agriculture, true, true),
                new CultureType("Milho", null, CultureTypeOptions.Agriculture, true, true),
                new CultureType("Café", null, CultureTypeOptions.Agriculture, true, true),
                new CultureType("Cana de açúcar", null, CultureTypeOptions.Agriculture, true, true),

                new CultureType("Bovinos", null, CultureTypeOptions.Livestock, true, true),
                new CultureType("Bufalinos", null, CultureTypeOptions.Livestock, true, true),
                new CultureType("Equinos", null, CultureTypeOptions.Livestock, true, true),
                new CultureType("Ovinos", null, CultureTypeOptions.Livestock, true, true),
                new CultureType("Caprinos", null, CultureTypeOptions.Livestock, true, true),
            };

            entities.ForEach(e =>
            {
                migrationBuilder.Sql(@$"IF NOT EXISTS (SELECT * FROM [dbo].[CultureTypes] WHERE [Name] = '{e.Name}') 
                                        BEGIN 
                                                INSERT INTO [dbo].[CultureTypes]
                                                       ([Id]
                                                       ,[Name]
                                                       ,[Type]
                                                       ,[CreatedAt]
                                                       ,[LastUpdateAt])
                                                 VALUES
                                                       ('{e.Id}'
                                                       ,'{e.Name}'
                                                       ,'{(int)e.Type}'
                                                       ,GETDATE()
                                                       ,GETDATE())
                                        END");
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

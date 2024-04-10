using AgilleApi.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class checklistData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var checklists = new List<AgilleApi.Domain.Entities.Checklist>()
            {
                new("Cópia de lei vigente instituidora de cargo com atribuição de lançamento de créditos tributários;", Domain.Enums.ChecklistStatus.Pending),
                new("Termo de Indicação de Servidores, preenchido e assinado eletronicamente;", Domain.Enums.ChecklistStatus.Pending),
                new("Cópia dos editais de abertura e de homologação do concurso público em que tenham sido aprovados os servidores indicados;", Domain.Enums.ChecklistStatus.Pending),
                new("Atos de nomeação dos servidores para o cargo previsto;", Domain.Enums.ChecklistStatus.Pending),
            };

            checklists.ForEach(e =>
            {
                migrationBuilder.Sql(@$"IF NOT EXISTS (SELECT * FROM [dbo].[Checklists] WHERE [Text] = '{e.Text}') 
                                        BEGIN 
                                                INSERT INTO [dbo].[Checklists]
                                                   ([Id]
                                                   ,[CreatedAt]
                                                   ,[LastUpdateAt]
                                                   ,[Text]
                                                   ,[Status])
                                             VALUES
                                                   ('{e.Id}'
                                                   , getdate()
                                                   , getdate()
                                                   ,'{e.Text}'
                                                   ,'{(int)e.Status}')
                                        END");
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
 
        }
    }
}

using BaseSystem.Data.ContextDb;
using BaseSystem.Data.Repository.InsertDatas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSystem.Data.Migrations
{
    public partial class v1 : Migration
    {
        private readonly Context _con;

        public v1(Context con)
        {
            _con = con;
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            new Datas(_con).InsertDatas();
        }

        protected override void Seed(Context con)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}




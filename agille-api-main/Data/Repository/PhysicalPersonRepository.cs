using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Data.Repository
{
    public class PhysicalPersonRepository : GenericRepository<PhysicalPersonBase>, IPhysicalPersonRepository
    {
        private readonly Context _con;

        public PhysicalPersonRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
}

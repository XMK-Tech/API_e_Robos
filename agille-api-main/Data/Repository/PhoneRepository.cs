using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Data.Repository
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        private readonly Context _con;

        public PhoneRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
}

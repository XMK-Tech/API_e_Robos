using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilleApi.Data.ContextDb;

namespace AgilleApi.Data.Repository
{
    public class VerificationRepository : GenericRepository<Verification>, IVerificationRepository
    {

        public VerificationRepository(Context _context) : base(_context)
        {

        }
    }
}

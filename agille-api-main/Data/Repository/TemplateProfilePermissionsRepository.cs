using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Data.Repository
{
    public class TemplateProfilePermissionsRepository : GenericRepository<TemplateProfilePermissions>, ITemplateProfilePermissionsRepository
    {
        public TemplateProfilePermissionsRepository(Context _context) : base(_context)
        {
        }
    }
}

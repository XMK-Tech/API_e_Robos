using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace AgilleApi.Data.Repository;

public class CultureDeclarationRepository : GenericRepository<CultureDeclaration>, ICultureDeclarationRepository
{ 
    public CultureDeclarationRepository(Context _context) : base(_context)
    {
    }
}
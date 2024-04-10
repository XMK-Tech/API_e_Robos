﻿using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class BareLandValueRepository : GenericRepository<BareLandValue>, IBareLandValueRepository
{
    public BareLandValueRepository(Context _context) : base(_context)
    {
    }
}
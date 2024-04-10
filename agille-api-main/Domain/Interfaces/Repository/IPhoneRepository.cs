using AgilleApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Interfaces.Repository
{
    public interface IPhoneRepository : IGenericRepository<Phone>
    {
        //List<Phone> GetByPessoa(Guid PessoaId, Expression<Func<Phone, bool>> filter = null, Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy = null, string includeProperties = "");
    }
}

using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Interfaces.Repository
{
  public interface IGenericRepository<T> where T : class
  {
    List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    T GetById(Guid id);
    bool Exists(Guid id);
    T Insert(T entity);
    List<T> InsertMany(List<T> entitys);
    void Delete(Guid id);
    void DeleteMany(List<T> entitys);
    void Delete(T entityToDelete);
    void Attach(T entityToUpdate);
    void Update(T entityToUpdate);
    void UpdateMany(List<T> entityToUpdate);
    void ExecuteSqlRaw(string query);
    void Reload(T entityToUpdate);
    List<T> ExecuteQuery(IQueryable<T> query, Metadata metadata, Expression<Func<T, object>> orderBy = null);
    IQueryable<T> Query();
    DatabaseFacade Transaction();
     List<U> ExecuteGenericQuery<U>(IQueryable<T> query, Metadata metadata, Expression<Func<T, U>> selector, Expression<Func<T, object>> orderBy = null) where U : class;
    }
}

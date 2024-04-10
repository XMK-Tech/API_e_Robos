using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        internal Context context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(Context _context)
        {
            context = _context;
            dbSet = context.Set<TEntity>();
        }
        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (string includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);


            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }
        public virtual TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }
        public bool Exists(Guid id)
        {
            TEntity entity = dbSet.Find(id);
            if (entity == null)
                return false;

            context.Entry(entity).State = EntityState.Detached;
            return true;
        }
        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public virtual List<TEntity> InsertMany(List<TEntity> entitys)
        {
            if (!entitys.Any())
                return entitys;
                
            dbSet.AddRange(entitys);
            context.SaveChanges();
            return entitys;
        }
        public virtual void Delete(Guid id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void DeleteMany(List<TEntity> entitys)
        {
            if (!entitys.Any())
                return;

            dbSet.RemoveRange(entitys);
            context.SaveChanges();
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }
        public virtual void Attach(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                Update(entityToUpdate);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("failed because another entity of the same type already has the same primary key value"))
                {
                    context.Entry(entityToUpdate).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Erro ao atualizar, verifique a mensagem.", ex);
                }
            }
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }
        public virtual void Reload(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).Reload();
        }
        public virtual void UpdateMany(List<TEntity> entityToUpdates)
        {
            if (!entityToUpdates.Any())
                return;

            context.UpdateRange(entityToUpdates);
            context.SaveChanges();
        }
        public void ExecuteSqlRaw(string query)
        {
            context.Database.ExecuteSqlRaw(query);
        }
        public virtual List<TEntity> ExecuteQuery(IQueryable<TEntity> query, Metadata metadata, Expression<Func<TEntity, object>> orderBy = null)
        {
            return Pagination<TEntity>.Execute(metadata, query, orderBy, i => i);
        }
        public virtual List<U> ExecuteGenericQuery<U>(IQueryable<TEntity> query, Metadata metadata, Expression<Func<TEntity, U>> selector, Expression<Func<TEntity, object>> orderBy = null) where U : class
        {
            return Pagination<TEntity>.Execute(metadata, query, orderBy, selector);
        }
        public IQueryable<TEntity> Query()
        {
            return dbSet.AsNoTracking().AsQueryable();
        }
        public virtual DatabaseFacade Transaction()
        {
            return context.Database;
        }
    }
}

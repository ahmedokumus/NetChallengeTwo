﻿using DataAccess.Abstract;
using Entities.Abstract;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using (TContext context = new TContext())
        {
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public void Add(TEntity entity)
    {
        //IDisposable pattern implementation of c#
        using (TContext context = new TContext())// TContext ile işim bittiğinde bellekten hemen at(performans için)
        {
            var addedEntity = context.Entry(entity);// Referansı yakalamak
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
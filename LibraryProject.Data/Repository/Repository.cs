﻿using Microsoft.EntityFrameworkCore;
using LibraryProject.Data.Entity;

namespace LibraryProject.Data.Repository;

public class Repository<TEntity> : SimpleRepository<TEntity>
    where TEntity : BaseEntity
{
    public Repository(LibraryContext context) : base(context)
    {
    }

    public virtual TEntity? GetById(long id)
    {
        return DbSet.Find(id);
    }

    public virtual void Delete(long id)
    {
        var entity = GetById(id);
        if (entity == null)
        {
            throw new NotImplementedException($"Entity with id {id} not found");
        }
        DbSet.Remove(entity);
    }
}
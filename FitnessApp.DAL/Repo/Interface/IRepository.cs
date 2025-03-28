﻿using System.Linq.Expressions;
using FitnessApp.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.DAL.Repo.Interface;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    DbSet<TEntity> Table { get; }
    Task<TEntity> AddAsync(TEntity entity);
    void Update(TEntity entity);
    void SoftDelete(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id);
    IQueryable<TEntity> GetAll(params string[] includes);
    Task<int> SaveChangesAsync();
    Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression);
}
using System.Linq.Expressions;
using FitnessApp.Core.Base;
using FitnessApp.DAL.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.DAL.Repo.Abstraction;

public class Repository<TEntity>:IRepository<TEntity> where TEntity:BaseEntity,new ()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<TEntity> Table => _context.Set<TEntity>();
    public async Task<TEntity> AddAsync(TEntity entity)
    {
       await Table.AddAsync(entity);  
       return entity;
    }

    public void Update(TEntity entity)
    {
        entity.UpdateAt=DateTime.UtcNow;
         Table.Update(entity);
    }

    public void SoftDelete(TEntity entity)
    {
        entity.IsDeleted = true;
        Table.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Table.Remove(entity);
    }


    public async Task<TEntity?> GetByIdAsync(int id)
    {
       return await Table.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id && !x.IsDeleted);
    }

    public IQueryable<TEntity> GetAll(params string[] includes)
    {
        var query= Table.Where(x => !x.IsDeleted);
        if(includes is not null)
        {
            foreach(var include in includes)
            {
                query= query.Include(include);
            }
        }

        return query;
    }
    public async Task<int> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Table.AsNoTracking().AnyAsync(expression);
    }
}
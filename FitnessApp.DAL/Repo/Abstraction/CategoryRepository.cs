using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class CategoryRepository:Repository<Category>,ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class TagRepository:Repository<Tag>,ITagRepository
{
    public TagRepository(AppDbContext context) : base(context)
    {
    }
}
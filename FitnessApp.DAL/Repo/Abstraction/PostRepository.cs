using FitnessApp.Core;
using FitnessApp.Core.Blog;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class PostRepository:Repository<BlogPost>,IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
}
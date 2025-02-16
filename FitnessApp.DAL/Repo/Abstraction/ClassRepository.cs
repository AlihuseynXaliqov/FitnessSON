using FitnessApp.Core;
using FitnessApp.Core.Class;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class ClassRepository:Repository<Classes>,IClassRepository
{
    public ClassRepository(AppDbContext context) : base(context)
    {
    }
}
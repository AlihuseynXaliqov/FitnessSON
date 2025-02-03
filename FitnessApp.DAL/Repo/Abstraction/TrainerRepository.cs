using FitnessApp.Core;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class TrainerRepository:Repository<Trainer>, ITrainerRepository
{
    public TrainerRepository(AppDbContext context) : base(context)
    {
    }
}
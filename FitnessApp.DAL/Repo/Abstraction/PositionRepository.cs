using FitnessApp.Core;
using FitnessApp.Core.Trainer;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class PositionRepository:Repository<TrainerPosition>, IPositionRepository
{
    public PositionRepository(AppDbContext context) : base(context)
    {
    }
}
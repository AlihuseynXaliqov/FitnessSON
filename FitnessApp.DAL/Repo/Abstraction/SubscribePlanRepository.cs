using FitnessApp.Core.Plan;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class SubscribePlanRepository:Repository<UserPlan>,ISubscribePlanRepository
{
    public SubscribePlanRepository(AppDbContext context) : base(context)
    {
    }
}
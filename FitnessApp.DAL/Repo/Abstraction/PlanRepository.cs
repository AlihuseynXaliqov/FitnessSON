using FitnessApp.Core;
using FitnessApp.Core.Plan;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class PlanRepository:Repository<PricingPlan>,IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context)
    {
    }
}
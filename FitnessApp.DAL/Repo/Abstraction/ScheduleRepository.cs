using FitnessApp.Core;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class ScheduleRepository:Repository<Schedule>,IScheduleRepository
{
    public ScheduleRepository(AppDbContext context) : base(context)
    {
    }
}
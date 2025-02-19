using FitnessApp.Service.DTOs.Plan;

namespace FitnessApp.Service.Service.Interface;

public interface ISubscribePlanService
{
    Task<string> SubscribePlan(SubscribePlanDto dto);
}
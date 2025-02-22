using FitnessApp.Service.DTOs.Plan;

namespace FitnessApp.Service.Service.Interface.Clients;

public interface ISubscribePlanService
{
    Task<string> SubscribePlan(SubscribePlanDto dto);
}
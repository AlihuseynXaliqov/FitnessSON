using FitnessApp.Service.DTOs.Plan;

namespace FitnessApp.Service.Service.Interface.Plan;

public interface ISubscribePlanService
{
    Task<string> SubscribePlanAfterPayment(string userId, int planId);
}
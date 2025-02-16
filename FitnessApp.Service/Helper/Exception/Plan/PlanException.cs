using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Plan;

public class PlanException:BaseException
{
    public PlanException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
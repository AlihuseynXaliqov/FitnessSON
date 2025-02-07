using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Trainer;

public class TrainerException:BaseException
{
    public TrainerException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
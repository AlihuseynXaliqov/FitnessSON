using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Schedule;

public class ScheduleException:BaseException
{
    public ScheduleException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
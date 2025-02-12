using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Position;

public class PositionException:BaseException
{
    public PositionException(string message, int statusCode):base(message,statusCode)
    {
        
    }
}
namespace FitnessApp.Service.Helper.Exception.Base;

public class NegativeIdException:BaseException
{
    public NegativeIdException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
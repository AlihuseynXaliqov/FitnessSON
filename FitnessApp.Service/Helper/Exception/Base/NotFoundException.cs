namespace FitnessApp.Service.Helper.Exception.Base;

public class NotFoundException:BaseException
{
    public NotFoundException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
namespace FitnessApp.Service.Helper.Exception.Base;

public class BaseException:System.Exception
{
    public string ErrorMessage { get; set; }
    public int StatusCode { get; set; }
    public BaseException(string errorMessage, int statusCode):base(errorMessage)
    {
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }
}
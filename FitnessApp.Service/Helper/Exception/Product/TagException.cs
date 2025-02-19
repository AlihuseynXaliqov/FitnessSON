using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Product;

public class TagException:BaseException
{
    public TagException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Product;

public class ProductException:BaseException
{
    public ProductException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Product;

public class CategoryException:BaseException
{
    public CategoryException(string errorMessage, int statusCode) : base(errorMessage, statusCode)
    {
    }
}
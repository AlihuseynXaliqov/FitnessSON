using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Auth;

public class NotFoundException:BaseException
{
    public NotFoundException(string errorMessage="Istifadeci Tapilmadi",int statuscode=404):base(errorMessage,statuscode)
    {
        
    }
}
using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Auth;

public class RegisterException:BaseException
{
    public RegisterException(string errorMessage,int statuscode):base(errorMessage,statuscode)
    {
        
    }
}
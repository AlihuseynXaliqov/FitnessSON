using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Auth;

public class ResetPasswordException:BaseException
{
    public ResetPasswordException(string errorMessage,int statuscode):base(errorMessage,statuscode)
    {
        
    }

    
}
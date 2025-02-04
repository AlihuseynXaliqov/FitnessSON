using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Auth;

public class LoginException : BaseException
{
    public LoginException(string errorMessage, int statuscode) : base(errorMessage, statuscode)
    {

    }
}
using FitnessApp.Core.Base;
using FitnessApp.Service.Helper.Exception.Base;

namespace FitnessApp.Service.Helper.Exception.Classes;

public class ClassException:BaseException
{
    public ClassException(string message,int statuscode):base(message,statuscode)
    {
        
    }
}
using FitnessApp.Service.Helper.Email;

namespace FitnessApp.Service.Service.Interface.Users;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}
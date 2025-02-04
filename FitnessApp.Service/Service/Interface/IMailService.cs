using FitnessApp.Service.Helper.Email;

namespace FitnessApp.Service.Service.Interface;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}
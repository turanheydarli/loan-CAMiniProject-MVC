using System.Net.Mail;

namespace Loan.Application.Mailing;

public interface IMailService
{
    Task SendEmailAsync(string toEmail, string subject, string message);
    Task SendEmailHtmlAsync(string toEmail, string subject, string htmlMessage);
}
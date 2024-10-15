using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Loan.Application.Mailing;

public class MailService : IMailService
{
    private EmailSettings _emailSettings;
    private readonly SmtpClient _smtpClient;

    public MailService(IOptions<EmailSettings> configuration)
    {
        _emailSettings = configuration.Value;

        _smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_emailSettings.FromMail, _emailSettings.Password),
            
        };
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromMail, _emailSettings.FromName),
            Subject = subject,
            Body = message,
            IsBodyHtml = false
        };
        mailMessage.To.Add(toEmail);

        await _smtpClient.SendMailAsync(mailMessage);
    }

    public async Task SendEmailHtmlAsync(string toEmail, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromMail, _emailSettings.FromName),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };
        mailMessage.To.Add(toEmail);

        await _smtpClient.SendMailAsync(mailMessage);
    }
}
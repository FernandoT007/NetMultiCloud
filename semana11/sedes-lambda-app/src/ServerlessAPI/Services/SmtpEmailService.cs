
using System.Net.Mail;

namespace ServerlessAPI.Services;

public class SmtpEmailService : IEmailService
{
    private readonly string _smtpHost;
    private readonly int _smtpPort;

    public SmtpEmailService(IConfiguration configuration)
    {
        var emailSettings = configuration.GetSection("MailSettings");
        _smtpHost = emailSettings["Host"] ?? throw new ArgumentNullException("Host Smtp null");
        _smtpPort = int.Parse(emailSettings["Port"] ?? throw new ArgumentNullException("Port Smtp null")) ;;
    }

    public Task SendEmailAsync(string from, string to, string subject, string body)
    {
       var smtlClient = new SmtpClient(_smtpHost, _smtpPort)
       {
            DeliveryMethod = SmtpDeliveryMethod.Network,
       };

       var mailMessage = new MailMessage(from, to, subject, body)
       {
            IsBodyHtml = true
       };

        return smtlClient.SendMailAsync(mailMessage);
    }
}

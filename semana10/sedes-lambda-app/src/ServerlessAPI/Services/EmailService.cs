
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace ServerlessAPI.Services;

public class EmailService : IEmailService
{
    private readonly IAmazonSimpleEmailService _sesClient; // Cliente de AWS SES

    public EmailService(IAmazonSimpleEmailService sesClient)
    {
        _sesClient = sesClient;
    }

    public async Task SendEmailAsync(string from, string to, string subject, string body)
    {
        var emailRequest = new SendEmailRequest
        {
            Source = from,
            Destination = new Destination
            {
                ToAddresses = new List<string> { to }
            },
            Message = new Message
            {
                Subject = new Content(subject),
                Body = new Body
                {
                    Html = new Content(body)
                }
            }
        };

        await _sesClient.SendEmailAsync(emailRequest);
    }
}
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace View.Models;

public class SendGridEmailSender : IEmailSender {
    private readonly IConfiguration _config;
    private readonly ILogger _logger;

    public SendGridEmailSender(ILogger<SendGridEmailSender> logger, IConfiguration configuration) {
        _config = configuration;
        _logger = logger;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
        var apiKey = _config["SendGridApiKey"];
        var client = new SendGridClient(apiKey);
        var message = new SendGridMessage() {
            From = new EmailAddress("oleglovchuk@ukr.net", "Ukraine"), Subject = subject, PlainTextContent = htmlMessage
          , HtmlContent = htmlMessage
        };
        message.AddTo(email);
        var response = await client.SendEmailAsync(message);
        if (response.IsSuccessStatusCode) { _logger.LogInformation("Success send email"); }
        else { _logger.LogInformation("Error send email"); }
    }
}
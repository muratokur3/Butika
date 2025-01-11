using Application.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ConcreteServices;
public class MailService : IMailService
{

    private readonly SmtpClient _smtpClient;
    public MailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }
    public async Task SendmailAsync(string supplierMail, string userMail, string subject, string body, byte[] attachment, string attachmentName)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress("okur3326@gmail.com"),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };
        var emailAddresses = supplierMail.Split(';');
        foreach (var email in emailAddresses)
        {
            mailMessage.To.Add(email.Trim());
        }
        mailMessage.CC.Add(userMail);
        if (attachment != null && attachment.Length > 0)
        {
            var attachmentStream = new MemoryStream(attachment);
            mailMessage.Attachments.Add(new Attachment(attachmentStream, attachmentName));
        }
        await _smtpClient.SendMailAsync(mailMessage);

    }

    public Task SendmailAsync(string to, string subject, string body)
    {
        throw new NotImplementedException();
    }
}
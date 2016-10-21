using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Reflection;
using RazorEngine.Templating;

namespace Luckyfive.Service
{
    public class EmailService : IIdentityMessageService
    {
        public EmailService() { }

        public async Task SendAsync(IdentityMessage message)
        {
            string apiKey = "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";
            dynamic sg = new SendGridAPIClient(apiKey);

            Content content = new Content("text/html", message.Body);
            Email from = new Email("luckyfivenoreply@gmail.com");
            Email to = new Email(message.Destination);
            Mail mail = new Mail(from, message.Subject, to, content);
            
            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}

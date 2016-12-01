using Microsoft.AspNet.Identity;
using RazorEngine.Templating;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using Luckyfive.Service.Abstraction;

namespace Luckyfive.Service
{
    public class MyEmailService : IMyEmailService
    {
        private IIdentityMessageService EmailService { get; set; }

        public MyEmailService(IIdentityMessageService emailService)
        {
            this.EmailService = emailService;
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public async Task SendConfirmationEmail(string postbackUrl, string userEmail)
        {
            var templatePath = AssemblyDirectory + "\\EmailTemplates\\ActivateAccountEmailTemplate.cshtml";
            var template = File.ReadAllText(templatePath);

            var parsed = Engine.Razor.RunCompile(template, "ConfirmTemplate", null,
                new {url = postbackUrl});
                
            var message = new IdentityMessage();
            message.Destination = userEmail;
            message.Subject = "Confirm your Luckufive account";
            message.Body = parsed;
            await this.EmailService.SendAsync(message);
        }
    }
}

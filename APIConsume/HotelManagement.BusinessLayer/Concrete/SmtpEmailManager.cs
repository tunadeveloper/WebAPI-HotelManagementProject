using HotelManagement.BusinessLayer.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer.Concrete
{
    public class SmtpEmailManager : IEmailService
    {
        private readonly IConfiguration _config;

        public SmtpEmailManager(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var host = _config["EmailSettings:Host"];
            var port = int.Parse(_config["EmailSettings:Port"]);
            var email = _config["EmailSettings:Email"];
            var password = _config["EmailSettings:Password"];
            var enableSSL = bool.Parse(_config["EmailSettings:EnableSSL"]);

            using (var client = new SmtpClient(host,port))
            {
                client.EnableSsl = enableSSL;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(email, password);

                var mailMessage = new MailMessage(
                        new MailAddress(email, "Otel Yönetim Sistemi"),
                        new MailAddress(to));

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
        }
    }
}

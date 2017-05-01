using IcyWindWebsite.Helpers;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IcyWindWebsite.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713

    //Don't even bother, I will handle this before pushing to server
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        string[] numberRemove = new[] { "-", " ", "(", ")" };
        public Task SendEmailAsync(string email, string subject, string message)
        {
            message += Environment.NewLine;
            message += "Do not reply to this email. It will be declined by the server.";

            message += Environment.NewLine;
            message += "Thank you for using IcyWind ~Potato";

            var messageS = new MimeMessage();
            messageS.From.Add(new MailboxAddress("noreply", "noreply@icywindclient.com"));
            messageS.To.Add(new MailboxAddress(email.Split('@')[0], email));
            messageS.Subject = subject;
            messageS.Body = new TextPart()
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("email-smtp.us-west-2.amazonaws.com", 587, true);
                client.Authenticate(StaticVars.emailUserPass);
                client.Send(messageS);
                client.Disconnect(true);
            }
            
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            foreach (var remove in numberRemove)
            {
                number = number.Replace(remove, "");
            }
            // Your Account SID from twilio.com/console
            var accountSid = "ACe282dd0c7d62c40bb6a9db3a5358f6e4";
            // Your Auth Token from twilio.com/console
            var authToken = "auth_token";

            TwilioClient.Init(accountSid, authToken);

            var messagedata = MessageResource.Create(
                   to: new PhoneNumber($"+{number}"),
                   from: new PhoneNumber("+6046708394"),
                   body: message);

            return Task.FromResult(messagedata.ErrorCode ?? 0);
        }
    }
}

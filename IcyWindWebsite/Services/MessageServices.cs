using IcyWindWebsite.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;
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

    //Don't even bother, You don't have the full static vars class
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        string[] numberRemove = new[] { "-", " ", "(", ")" };
        public async Task<int> SendEmailAsync(string email, string subject, string message)
        {
            //Screw SES
            var client = new SendGridClient(StaticVars.sendGrid);
            var from = new EmailAddress("noreply@icywindclient.com", "IcyWind");
            var to = new EmailAddress(email, email.Split('@').FirstOrDefault());
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);

            return (int)response.StatusCode;
        }

        public Task SendSmsAsync(string number, string message)
        {
            foreach (var remove in numberRemove)
            {
                number = number.Replace(remove, "");
            }

            TwilioClient.Init(StaticVars.AccountSid, StaticVars.AuthToken);

            var messagedata = MessageResource.Create(
                   to: new PhoneNumber($"+{number}"),
                   from: new PhoneNumber("6046708394"),
                   body: message);

            return Task.FromResult(messagedata.ErrorCode ?? 0);
        }
    }
}

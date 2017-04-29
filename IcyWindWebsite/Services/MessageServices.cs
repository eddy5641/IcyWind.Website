using IcyWindWebsite.Helpers;
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

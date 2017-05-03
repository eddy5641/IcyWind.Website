using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcyWindWebsite.Services
{
    public interface IEmailSender
    {
        Task<int> SendEmailAsync(string email, string subject, string message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IcyWindWebsite.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }

        public bool IsDonator { get; set; }

        public int DonateAmount { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcyWindWebsite.API.Controllers
{
    public static class StaticVars
    {
        /// <summary>
        /// The connection string of the server
        /// </summary>
        //Default server=localhost;userid=user12;password=34klq*;database=mydb
        public static string connString = @"server=localhost;userid=user12;password=34klq*;database=mydb";

        /// <summary>
        /// This key must be changed if you are running this on your own server for security reasons
        /// </summary>
        //Default M46IrenJ86WOI94j8968HE94ngji9
        public const string AdminKey = @"M46IrenJ86WOI94j8968HE94ngji9";
    }
}

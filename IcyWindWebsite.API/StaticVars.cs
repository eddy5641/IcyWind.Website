using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcyWindWebsite.API
{
    public static class StaticVars
    {
        /// <summary>
        /// The connection string of the server
        /// </summary>
        //Default server=localhost;userid=user12;password=34klq*;database=mydb
        public static string connString = @"server=35.184.49.175;userid=user;password=jZNYcm7ZPfU3zbDh28y3kfgjd2gUR5;" +
            "database=icywinddb;SslMode=Required;";
        //qlsFO0dCmm4P1u0a

        /// <summary>
        /// This key must be changed if you are running this on your own server for security reasons
        /// </summary>
        //Default jZNYcm7ZPfU3zbDh28y3kfgjd2gUR5
        public const string AdminKey = @"jZNYcm7ZPfU3zbDh28y3kfgjd2gUR5";
    }
}

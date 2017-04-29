using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IcyWindWebsite.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        /// <summary>
        /// Invalid API call. In future list api functions
        /// </summary>
        /// <returns>Error</returns>
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return @"API IS IN BETA. TRY AGAIN LATER";
        }

        /// <summary>
        /// Returns a json string that contains info about a users information
        /// if the username and password is correct
        /// </summary>
        /// <param name="username">The username to login with</param>
        /// <param name="password">The sha1 hash of the password</param>
        /// <returns>A json string or an error</returns>
        // GET api/values/getaccounts/{username}/{password}
        [HttpGet]
        [Route("getaccounts/{username}/{password}")]
        public string Login(string username, string password)
        {
            //If an account is not found or password is wrong, return an error
            //This method is used to have users information protected stronger
            return $"{username} : {password}";
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="username">The username to login with</param>
        /// <param name="password">The sha1 hash of the password</param>
        /// <returns>Success or failure</returns>
        // GET api/values/create/{username}/{password}
        [HttpGet]
        [Route("create/{username}/{password}")]
        public string CreateUser(string username, string password)
        {
            return "Success";
        }

        /// <summary>
        /// Adds data to the account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hashinfo"></param>
        /// <returns></returns>
        // GET api/values/adddatatoaccount/{username}/{password}/{hashinfo}
        [HttpGet]
        [Route("adddatatoaccount/{username}/{password}/{hashinfo}")]
        public string AddDataToAccount(string username, string password, string hashinfo)
        {
            return "Success";
        }


        // GET api/values/rmdatafromaccount/{username}/{password}/{hashinfo}
        [HttpGet]
        [Route("rmdatafromaccount/{username}/{password}")]
        public string RemoveDataFromAccount(string username, string password, string hashinfo)
        {
            return "Success";
        }

        // GET api/values/rmdatafromaccount/{username}/{password}/{stringlocation}
        [HttpGet]
        [Route("rmdatafromaccount/{username}/{password}")]
        public string RemoveDataToAccount(string username, string password, int stringlocation)
        {
            return "Success";
        }

        // GET api/values/resetaccount/{username}/{adminkey}
        [HttpGet]
        [Route("resetaccount/{username}/{adminkey}")]
        public string ResetAccount(string username, string adminkey)
        {
            if (StaticVars.AdminKey != adminkey)
            {
                return "Invalid Admin Key.";
            }
            return "Success";
        }
    }
}

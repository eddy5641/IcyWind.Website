using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcyWindWebsite.API
{
    public static class UserDatabaseHelper
    {
        /// <summary>
        /// The MySQL server location
        /// </summary>
        public static MySqlConnection conn;

        public static bool SendCommand()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = "INSERT INTO Authors(Name) VALUES(@Name)"
                };
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Name", "Trygve Gulbranssen");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

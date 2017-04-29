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

        public static bool SendNonQueryCommand(string commandText, params KeyValuePair<string, string>[] paramsValues)
        {
            try
            {
                //Create the command
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = commandText
                    //CommandText = "INSERT INTO icywinddb(Username,UID,PasswordHash,StoredData) VALUES(@Username)"
                };
                cmd.Prepare();
                foreach (var para in paramsValues)
                {
                    cmd.Parameters.AddWithValue(para.Key, para.Value);
                }
                //cmd.Parameters.AddWithValue("@Username", "Trygve Gulbranssen");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static int SendQueryCommand(string commandText, params KeyValuePair<string, string>[] paramsValues)
        {
            try
            {
                //Create the command
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = commandText
                    //CommandText = "INSERT INTO icywinddb(Username,UID,PasswordHash,StoredData) VALUES(@Username)"
                };
                cmd.Prepare();
                foreach (var para in paramsValues)
                {
                    cmd.Parameters.AddWithValue(para.Key, para.Value);
                }
                //cmd.Parameters.AddWithValue("@Username", "Trygve Gulbranssen");
                
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
        }
    }
}

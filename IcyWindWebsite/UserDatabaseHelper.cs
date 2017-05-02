using Google.Cloud.Datastore.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IcyWindWebsite
{
    public static class UserDatabaseHelper
    {
        public static DatastoreDb db;
        public static Aes aes;
        public static Random random;

        public static byte[] MakeSalt()
        {
            if (random == null)
            {
                random = new Random();
            }

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.NextBytes(salt);

            // Return the string encoded salt
            return salt;
        }

        public static void CreateUser(string username, string uid, string passhash, byte[] salt)
        {
            KeyFactory keyFactory = db.CreateKeyFactory("IcyWind");
            Key key = keyFactory.CreateKey(username);

            var task = new Entity
            {
                Key = key,
                ["data"] = string.Empty,
                ["salt"] = ByteArrayToString(salt),
                ["passhash"] = passhash,
                ["uid"] = uid,
                ["IsAdmin"] = false,
                ["IsDonator"] = false,
                ["Banned"] = false,
                ["DonateAmount"] = 0
            };

            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                // Saves the task
                transaction.Upsert(task);
                transaction.Commit();
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static void UpdateUserData(string uid, string lolUser, string lolPass, string pass, string salt = "")
        {
            if (aes == null)
            {
                aes = Aes.Create();
            }
            
        }

        public static Entity GetUserData(string userid)
        {
            var query = new Query("IcyWind")
            {
                Filter = Filter.Equal("uid", userid)
            };
            var data = db.RunQuery(query);
            return data.Entities.First();
        }

        public static async Task<IReadOnlyList<Entity>> GetAllUsersAsync()
        {
            var query = new Query("IcyWind");
            var data = await db.RunQueryAsync(query);
            return data.Entities;
        }


        public static IReadOnlyList<Entity> GetAllUsers()
        {
            var query = new Query("IcyWind");
            var data = db.RunQuery(query);
            return data.Entities;
        }
    }
}

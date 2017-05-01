using Google.Cloud.Datastore.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcyWindWebsite
{
    public static class UserDatabaseHelper
    {
        public static DatastoreDb db;

        public static void CreateUser(string username, string uid, string passhash)
        {
            KeyFactory keyFactory = db.CreateKeyFactory("IcyWind");
            Key key = keyFactory.CreateKey(username);

            var task = new Entity
            {
                Key = key,
                ["data"] = string.Empty,
                ["passhash"] = passhash,
                ["uid"] = uid,
                ["IsAdmin"] = false,
                ["IsDonator"] = false,
                ["DonateAmount"] = 0
            };

            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                // Saves the task
                transaction.Upsert(task);
                transaction.Commit();
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
    }
}

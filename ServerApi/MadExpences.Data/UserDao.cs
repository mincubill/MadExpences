using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace MadExpences.Data
{
    public class UserDao
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public static void CreateUser()
        {
            

        }

        public void GetUser()
        {
            var client = Dao.DbConnection();
            var db = client.GetDatabase("madexpences");
            var col = db.GetCollection<BsonDocument>("usuarios");
            var docs = col.FindSync<BsonDocument>("data.userData.Name: 'kurisu tina'");
            //var sad = "";
        }
    }
}

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

        public void CreateUser()
        {


        }

        public void GetUser()
        {
            var client = new MongoClient("mongodb://192.168.1.13:27017");
            var db = client.GetDatabase("madexpences");
            var col = db.GetCollection<BsonDocument>("transactions");
            var docs = col.FindSync<BsonDocument>("data.userData.Name: 'asdf'");
            var sad = "";
        }
    }
}

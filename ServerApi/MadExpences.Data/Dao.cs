using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MadExpences.Data
{
    public static class Dao
    {
        public static IMongoDatabase DbConnection()
        {
            // Change IP address acording to the server 
            var connectionString = "mongodb://weasdf.ddns.net:27017";
            MongoClient dbClient = new MongoClient(connectionString);
            IMongoDatabase db = dbClient.GetDatabase("madexpences");
            
            return db;
        }
    }
}

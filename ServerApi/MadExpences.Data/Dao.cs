using System;
using MongoDB.Driver;

namespace MadExpences.Data
{
    public static class Dao
    {
        public static MongoClient DbConnection()
        {
            // Cambiar IP según servidor de mongo conectado
            var connectionString = "mongodb://192.168.1.113:27017";
            MongoClient dbClient = new MongoClient(connectionString);

            return dbClient;
        }

    }
}

using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson.Serialization;

namespace MadExpences.Data
{
    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public class UserDao
    {
        public string UserID { get; set; }
        public int Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }


        public void CreateUser(string pId, string pFirstName, string pLastName, string pMail)
        {
            var user = new UserDao
            {
                UserID = pId,
                Status = (int)UserStatus.Active,
                FirstName = pFirstName,
                LastName = pLastName,
                Mail = pMail
            };
            var bObj = user.ToBsonDocument();
            var db = Dao.DbConnection();
            var dbCollection = db.GetCollection<BsonDocument>("users");

            //Generate the document (row) to insert in the Collection
            
            /*var document = new BsonDocument
            {
                {"status", "2"},
                {"firstname", pFirstName},
                {"lastname", pLastName },
                {"mail", pMail}
            };*/
            
            //Send the insert to the database
            //dbCollection.InsertOne(document);
            dbCollection.InsertOne(bObj);
        }

        public UserDao ReadUser(string pUserId)
        {
            var db = Dao.DbConnection();
            var dbCollection = db.GetCollection<BsonDocument>("users");
            var filter = Builders<BsonDocument>.Filter.Eq("UserID", pUserId);            
            var doc = dbCollection.Find(filter).FirstOrDefault();
            var user = BsonSerializer.Deserialize<UserDao>(doc);
            return user;
        }

        public void UpdateUser(string pUserID, string pFirstName, string pLastName, string pMail)
        {
            var db = Dao.DbConnection();
            var dbCollection = db.GetCollection<BsonDocument>("users");
            var actualUser = ReadUser(pUserID);
            actualUser.FirstName = pFirstName;
            actualUser.LastName = pLastName;
            actualUser.Mail = pMail;

            //Create filter to identify the document (row) and set the update (Status: 2-Active, 1-Blocked, 0-Deleted)
            var filter = Builders<BsonDocument>.Filter.Eq("UserID", pUserID);
            //var update = Builders<BsonDocument>.Update.Set("firstname", pFirstName).Set("lastname", pLastName).Set("mail", pMail);
            var updatedUser = actualUser.ToBsonDocument();
            //Send the changes to the database
            
            dbCollection.ReplaceOne(filter, updatedUser);
        }

        public void BlockUser(string pUserID)
        {
            var db = Dao.DbConnection();
            var dbCollection = db.GetCollection<BsonDocument>("users");

            //Create filter to identify the document (row) and set the update (Status: 2-Active, 1-Blocked, 0-Deleted)
            var filter = Builders<BsonDocument>.Filter.Eq("UserID", pUserID);
            var update = Builders<BsonDocument>.Update.Set("Status", (int)UserStatus.Blocked);

            //Send the changes to the database
            dbCollection.UpdateOne(filter, update);
        }

        public void DeleteUser(string pUserID)
        {
            var db = Dao.DbConnection();
            var dbCollection = db.GetCollection<BsonDocument>("users");

            //Create filter to identify the document (row) and set the update (Status: 2-Active, 1-Blocked, 0-Deleted)
            var filter = Builders<BsonDocument>.Filter.Eq("UserID", pUserID);
            var update = Builders<BsonDocument>.Update.Set("Status", (int)UserStatus.Deleted);
            
            //Send the changes to the database
            dbCollection.UpdateOne(filter, update);
        }

        public ObjectId ConvertToObjId(string pId)
        {
            //Input string to ObjectID
            var objId = new ObjectId(pId);
            return objId;
        }
    }

    public enum UserStatus
    {
        Deleted = 0,
        Active = 1,
        Blocked = 2,
    }
}

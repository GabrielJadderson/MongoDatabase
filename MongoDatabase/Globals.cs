using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDatabase
{
    public static class Globals
    {
        public static string ConnectionString = "mongodb://localhost:27017";
        public static MongoClient Client;

        public static IMongoCollection<BsonDocument> UserCollection;
        public static IMongoCollection<BsonDocument> CombinationCollection;
        public static IMongoCollection<BsonDocument> RatingCollection;

        public static string Username = null; //store username
    }
}
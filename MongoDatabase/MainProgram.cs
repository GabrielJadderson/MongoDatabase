using System;
using MongoDatabase;
using MongoDatabase.DBElements;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDBProject.ConsoleInterface;

namespace MongoDBProject
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            ConfigureAndEstablishDBConnection();

            new ConsoleMenu();
        }


        public static void ConfigureAndEstablishDBConnection()
        {
            Globals.Client = new MongoClient(Globals.ConnectionString);

            IMongoDatabase database = Globals.Client.GetDatabase("Bartender");

            Globals.UserCollection = database.GetCollection<User>("Users");
            Globals.CombinationCollection = database.GetCollection<Combination>("Combinations");
            Globals.RatingCollection = database.GetCollection<Rating>("Ratings");
        }


        public void registerClasses()
        {
            BsonClassMap.RegisterClassMap<User>();
            BsonClassMap.RegisterClassMap<Combination>();
            BsonClassMap.RegisterClassMap<Rating>();
        }
    }
}
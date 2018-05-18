using System;
using MongoDatabase.DBElements;
using MongoDB.Driver;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase
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

    }
}
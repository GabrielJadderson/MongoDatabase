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
            InsertCombinations();
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

        public static void InsertCombinations() //for testing
        {
            Globals.Username = "Gabriel";
            string[] comments = new[] {
                "this is a good drink.","worst shit ever.","very good for getting wasted.","something wrong with this.",
                "not the best in the world, but the best around town.","this  is heaven",
                "one good combinatgion","can't be beaten","so good.", "Moly Holy the best gin in the world."};
            for (int i = 0; i < 10; i++)
            {
                Operations.CreateCombination("gin" + i, "tonic" + i, "garnish" + i, comments[i], new Random().Next(1, 5));
            }
            Globals.Username = null;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("foo");


            var collection = database.GetCollection<BsonDocument>("bar");


            var document = new BsonDocument
            {
                {"firstname", BsonValue.Create("Peter")},
                {"lastname", new BsonString("Mbanugo")},
                { "subjects", new BsonArray(new[] {"English", "Mathematics", "Physics"}) },
                { "class", "JSS 3" },
                { "age", int.MaxValue }
            };



            await collection.InsertOneAsync(document);
            //var documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));
            //collection.InsertMany(documents);

            var count = collection.Count(new BsonDocument());
            
            new Menu();
        }
    }
}
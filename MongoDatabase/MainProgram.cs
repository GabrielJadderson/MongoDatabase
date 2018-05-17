﻿using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBProject.ConsoleInterface;

namespace MongoDBProject
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            start();

            Console.ReadLine();
        }

        static void start()
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

            collection.InsertOne(document);
            //var documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));
            //collection.InsertMany(documents);

            var count = collection.Count(new BsonDocument());

            new ConsoleMenu();
        }
    }
}
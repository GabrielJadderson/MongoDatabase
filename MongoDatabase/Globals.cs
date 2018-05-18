﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDatabase.DBElements;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDatabase
{
    public static class Globals
    {
        public static string ConnectionString = "mongodb://localhost:27017";
        public static MongoClient Client;

        public static IMongoCollection<User> UserCollection;
        public static IMongoCollection<Combination> CombinationCollection;
        public static IMongoCollection<Rating> RatingCollection;

        public static string Username = null; //store username
    }
}
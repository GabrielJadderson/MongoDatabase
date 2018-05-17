﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    public class User
    {
        [BsonId] public ObjectId Name { get; set; } //name will be our id, also "BsonId" makes the id Indexed!
        [BsonElement("ratings")] public List<Rating> Ratings { get; set; }
    }
}
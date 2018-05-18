using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    public class Combination
    {
        [BsonId] public ObjectId CombinationID { get; set; }
        [BsonElement("gin")] public string Gin { get; set; }
        [BsonElement("tonic")] public string Tonic { get; set; }
        [BsonElement("garnish")] public string Garnish { get; set; }

        [BsonElement("ratings")] public List<ObjectId> ratings { get; set; } //points to rating id
        [BsonElement("accumulative_rating")] public int accumulativeRating { get; set; }

    }
}
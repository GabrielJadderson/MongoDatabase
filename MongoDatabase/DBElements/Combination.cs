﻿using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    public class Combination
    {
        [BsonId] public string CombinationID { get; set; }
        [BsonElement("gin")] public string Gin { get; set; }
        [BsonElement("tonic")] public string Tonic { get; set; }
        [BsonElement("garnish")] public string Garnish { get; set; }

        [BsonElement("accumulative_rating")] public int accumulativeRating { get; set; }


        public override string ToString()
        {
            return "CombinationID: " + CombinationID + "\n" +
                   "Gin: " + Gin + "\n" +
                   "Tonic: " + Tonic + "\n" +
                   "Garnish: " + Garnish + "\n" +
                   "accumulativeRating: " + accumulativeRating + "\n";
        }
    }
}
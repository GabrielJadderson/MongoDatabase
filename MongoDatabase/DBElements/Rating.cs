using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    public class Rating
    {
        [BsonId] public string RatingId;

        [BsonElement("combination")] public string theRatedCoombination { get; set; }
        [BsonElement("user")] public string theUser { get; set; }

        [BsonElement("rating")] public int rating { get; set; }
        [BsonElement("comment")] public string comment { get; set; }
    }
}
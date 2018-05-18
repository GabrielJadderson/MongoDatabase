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
        [BsonId] public ObjectId RatingId;

        [BsonElement("combination")] public ObjectId theRatedCoombination { get; set; }
        [BsonElement("user")] public ObjectId theUser { get; set; }

        public int rating { get; set; }
        public string comment { get; set; }
    }
}
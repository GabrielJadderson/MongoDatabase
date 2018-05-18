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

        [BsonElement("combination")] public ObjectId theRatedCoombination;
        [BsonElement("user")] public ObjectId theUser;
        public int rating = 0;
        public string comment;
    }
}
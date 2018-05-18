using System;
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
        [BsonId] public ObjectId userID { get; set; }
        [BsonElement("name")] public string Name { get; set; }
        [BsonElement("ratings")] public List<Rating> Ratings { get; set; }
    }
}
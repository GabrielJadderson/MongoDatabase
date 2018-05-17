using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    internal class Combination
    {
        [BsonId] public string CombinationID { get; set; }
        [BsonId] public string Gin { get; set; }
        [BsonId] public string Tonic { get; set; }
        [BsonId] public string Garnish { get; set; }

        [BsonElement("helpfullmarks")] public int HelpfullMarks { get; set; } //non-negative
        [BsonElement("ratingscount")] public int RatingsCount { get; set; } //non-negative
        [BsonElement("num_users_rated")] public int NumUsersRated { get; set; } //non-negative

    }
}
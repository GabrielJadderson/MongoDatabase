using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    public class Rating
    {
        [BsonId] public ObjectId ratingId { get; set; }

        [BsonElement("combination")] public string theRatedCoombination { get; set; }
        [BsonElement("user")] public string theUser { get; set; }

        [BsonElement("rating")] public int rating { get; set; }
        [BsonElement("comment")] public string comment { get; set; }
        [BsonElement("helpful")] public int helpfulmarks { get; set; }

        public override string ToString()
        {
            return "ratingID: " + ratingId + "\n" +
                   "CombinationID: " + theRatedCoombination + "\n" +
                   "userID: " + theUser + "\n" +
                   "rating: " + rating + "\n" +
                   "comment: " + comment + "\n" +
                   "helpfulmarks: " + helpfulmarks + "\n";
        }
    }
}
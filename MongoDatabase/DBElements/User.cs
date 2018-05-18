using MongoDB.Bson.Serialization.Attributes;

namespace MongoDatabase.DBElements
{
    public class User
    {
        [BsonId] public string Name { get; set; }
    }
}
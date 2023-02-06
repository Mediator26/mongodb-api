using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;} = null!;
    [BsonElement("Login")]
    public string Login { get; set; } = null!;
    public string Password { get; set;} = null!;
}
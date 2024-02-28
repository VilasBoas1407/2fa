using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TwoFactorAuthenticator.Models.Entity
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }   

    }
}

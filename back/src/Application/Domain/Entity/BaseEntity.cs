using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TwoFactorAuthenticator.Domain.Entity
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }   

    }
}

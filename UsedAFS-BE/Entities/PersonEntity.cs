using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace UsedAFS_BE.Entities
{
    public class PersonEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AssignedId { get; set; }
        public IEnumerable<BookEntity> Books;
    }
}
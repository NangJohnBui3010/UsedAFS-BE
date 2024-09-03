using System.ComponentModel.DataAnnotations;

namespace UsedAFS_BE.Entities
{
    public class PersonEntity
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AssignedId { get; set; }
        public List<BookEntity> Books { get; } = new();
    }
}

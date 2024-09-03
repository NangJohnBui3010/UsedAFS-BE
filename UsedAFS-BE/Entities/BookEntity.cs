using System.ComponentModel.DataAnnotations;

namespace UsedAFS_BE.Entities
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}

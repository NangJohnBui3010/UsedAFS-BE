using UsedAFS_BE.Entities;

namespace UsedAFS_BE.Interfaces
{
    public interface IBookService
    {
        Task<List<BookEntity>> GetAsync();
        Task<BookEntity?> GetAsync(string id);
        Task CreateAsync(BookEntity newBook);
        Task UpdateAsync(string id, BookEntity updatedBook);
        Task RemoveAsync(string id);
    }
}

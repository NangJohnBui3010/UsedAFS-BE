using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using UsedAFS_BE.Entities;
using UsedAFS_BE.Interfaces;
using UsedAFS_BE.Middleware;

namespace UsedAFS_BE.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<BookEntity> _bookCollection;

        public BookService(
            IOptions<MyDatabaseSettings> myDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                myDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                myDatabaseSettings.Value.DatabaseName);

            string className = typeof(BookEntity).Name;

            _bookCollection = mongoDatabase.GetCollection<BookEntity>(
                myDatabaseSettings.Value.BookCollectionName);
        }

        public async Task<List<BookEntity>> GetAsync() =>
            await _bookCollection.Find(_ => true).ToListAsync();

        //public async Task<List<BookEntity>> GetAsyncNew()
        //{
        //    var books = await _bookCollection.Find(_ => true).ToListAsync();
        //}

        public async Task<BookEntity?> GetAsync(string id) =>
            await _bookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(BookEntity newBook) =>
            await _bookCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, BookEntity updatedBook) =>
            await _bookCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _bookCollection.DeleteOneAsync(x => x.Id == id);
    }
}

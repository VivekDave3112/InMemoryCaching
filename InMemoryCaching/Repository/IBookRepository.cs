using InMemoryCaching.Entities;

namespace InMemoryCaching.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<IEnumerable<Book>> GetBooksCache();
    }
}

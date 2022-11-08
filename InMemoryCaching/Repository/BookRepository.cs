using InMemoryCaching.Cache;
using InMemoryCaching.Entities;

namespace InMemoryCaching.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ICustomMemoryCache _cache;
        private ILogger<BookRepository> _logger;

        public BookRepository(ICustomMemoryCache cache, ILogger<BookRepository> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            List<Book> result = new();

            /*Here i am insertig the hard coded data, in real world we would get data from the Sql Database.*/
            result.Add(new Book() { Title = "C-Sharp Programming", AuthorName="Ken Adams"});
            result.Add(new Book() { Title = "Dotnet", AuthorName = "Bill Gates" });
            result.Add(new Book() { Title="Azure Cloud", AuthorName="Elon Musk"});

            await Task.Delay(3000);//The delay is added to depict the real world scenario where Getting the data from the Database would cause a delay of some seconds.

            return result;
        }

        public async Task<IEnumerable<Book>> GetBooksCache()
        {
            try
            {
                IEnumerable<Book> result;
                var cachedValue = _cache.GetValue<IEnumerable<Book>>("Books");

                if (cachedValue != null)
                {
                    result = cachedValue;
                }
                else
                {
                   result = await GetBooksAsync();
                   _cache.SetValue("Books", result);
                }

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return null;
            }            
        }
    }
}

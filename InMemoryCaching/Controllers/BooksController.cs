using InMemoryCaching.Entities;
using InMemoryCaching.Entities.ResponseEntities;
using InMemoryCaching.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCaching.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<BookResponse> GetBooks()
        {
            BookResponse response = new BookResponse();

            try
            {
                response.Books = await _bookRepository.GetBooksCache();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unable to Get Books");
                response.ErrorCode = 1;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }   
    }
}

namespace InMemoryCaching.Entities.ResponseEntities
{
    public class BookResponse
    {
        public BookResponse()
        {
            this.ErrorCode = 0;
            this.ErrorMessage = null;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}

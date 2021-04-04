namespace BookApi.Requests.Book
{
    public class BookCreate
    {
        public string Name { get; set; }
        public string Sinopsis { get; set; }
        public long AuthorId { get; set; }
    }
}
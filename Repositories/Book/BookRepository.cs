using Models = BookApi.Models;

namespace BookApi.Repositories.Book
{
    public class BookRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Sinopsis { get; set; }
        public long AuthorId { get; set; }
        public Models.Author Author { get; set; }
    }
}
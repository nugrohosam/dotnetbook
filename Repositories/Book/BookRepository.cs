using Models = BookApi.Models;
using System.Collections.Generic;
using BookApi.Repositories.Author;

namespace BookApi.Repositories.Book
{
    public class BookRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Sinopsis { get; set; }
        public long AuthorId { get; set; }
        public AuthorRepository Author { get; set; }

        public void MapToAuthorRepo(Models.Author author)
        {
            this.Author = new AuthorRepository()
            {
                Name = author.Name,
                Id = author.Id
            };
        }
        public List<BookRepository> MapFromModel(List<Models.Book> books)
        {
            if (books == null)
            {
                return (new List<BookRepository>());
            }

            List<BookRepository> booksRepo = new List<BookRepository>();
            foreach (Models.Book book in books)
            {
                booksRepo.Add((new BookRepository()
                {
                    Id = book.Id,
                    Sinopsis = book.Sinopsis,
                    Name = book.Name
                }));
            }

            return booksRepo;
        }
    }
}
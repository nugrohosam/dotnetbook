using BookApi.Repositories.Book;
using System.Collections.Generic;
using Models = BookApi.Models;

namespace BookApi.Repositories.Author
{
    public class AuthorRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<BookRepository> Books { get; set; }

        public void MapToListBook(ICollection<Models.Book> books) {
            if (books == null){
                return;
            }
            
            this.Books = new List<BookRepository>();
            foreach (Models.Book book in books){
                var bookRepo = new BookRepository() {
                    Id = book.Id,
                    Name = book.Name,
                    Sinopsis = book.Name
                };

                this.Books.Add(bookRepo);
            }
        }
        public List<AuthorRepository> MapFromModel(List<Models.Author> authors)
        {
            if (authors == null)
            {
                return (new List<AuthorRepository>());
            }

            List<AuthorRepository> authorsRepo = new List<AuthorRepository>();
            foreach (Models.Author author in authors)
            {
                authorsRepo.Add((new AuthorRepository()
                {
                    Id = author.Id,
                    Name = author.Name
                }));
            }

            return authorsRepo;
        }
    }
}
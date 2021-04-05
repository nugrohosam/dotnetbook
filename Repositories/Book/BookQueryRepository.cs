using System.Linq;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace BookApi.Repositories.Book
{
    public class BookQueryRepository
    {
        Models.Context context;
        private BookRepository bookRepository;

        public BookQueryRepository()
        {
            this.context = new Models.Context();
            this.bookRepository = new BookRepository();
        }

        internal Models.Book Find(long id = 0)
        {
            return this.context.Books.Include(book => book.Author).Where(book => book.Id == id).FirstOrDefault<Models.Book>();
        }

        public BookRepository FindById(long id = 0)
        {
            Models.Book book = this.Find(id);
            if (book == null)
            {
                return (new BookRepository());
            }

            this.bookRepository.Id = book.Id;
            this.bookRepository.Name = book.Name;
            this.bookRepository.Sinopsis = book.Sinopsis;
            this.bookRepository.AuthorId = book.AuthorId;
            this.bookRepository.MapToAuthorRepo(book.Author);

            return this.bookRepository;
        }

        public List<BookRepository> GetPaginate(string search, int page, int limit)
        {
            int skip = (1 - page) * limit;
            List<Models.Book> books = this.context.Books.Where(Book => Book.Name.Contains(search)).ToList(); // Skip(skip).Take(limit).ToList();
            return this.bookRepository.MapFromModel(books);
        }
    }
}
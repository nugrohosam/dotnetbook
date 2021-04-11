using System.Linq;
using System.Data.Entity;
using BookApi.Models;
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
            this.bookRepository.Authorid = book.Authorid;
            this.bookRepository.MapToAuthorRepo(book.Author);

            return this.bookRepository;
        }

        public List<BookRepository> Get(string search, int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.Book> books;
            IQueryable<Models.Book> bookQuery = this.context.Books;
            if (search != null)
            {
                bookQuery = bookQuery.Where(book => book.Name.Contains(search));
            }

            books = bookQuery.Skip(skip).Take(perPage).ToList();
            return this.bookRepository.MapFromModel(books);
        }
        public int CountAll(string search)
        {
            IQueryable<Models.Book> bookQuery = this.context.Books;
            if (search != null)
            {
                bookQuery = bookQuery.Where(book => book.Name.Contains(search));
            }

            return bookQuery.Count();
        }
    }
}
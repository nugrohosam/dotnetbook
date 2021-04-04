using Models = BookApi.Models;
using System.Linq;
using System;

namespace BookApi.Repositories.Book
{

    public class BookStoreRepository
    {
        Models.Context context;
        BookQueryRepository bookQueryRepository;

        public BookStoreRepository()
        {
            this.context = new Models.Context();
            this.bookQueryRepository = new BookQueryRepository();
        }

        public void Create(BookRepository bookRepository)
        {
            Models.Book newBook = new Models.Book();

            newBook.Name = bookRepository.Name;
            newBook.Sinopsis = bookRepository.Sinopsis;

            this.save(newBook);
        }

        public void Update(long id, BookRepository bookRepository)
        {
            Models.Book oldBook = this.bookQueryRepository.Find(id);

            oldBook.Name = bookRepository.Name;
            oldBook.Sinopsis = bookRepository.Sinopsis;

            this.save(oldBook);
        }

        private void save(Models.Book Book)
        {
            this.context.Books.Add(Book);
            this.context.SaveChanges();
        }
    }
}
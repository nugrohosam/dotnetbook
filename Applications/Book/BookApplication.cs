using BookApi.Requests.Book;
using BookApi.Repositories.Book;
using System;

namespace BookApi.Applications.Book
{
    public class BookApplication
    {   
        private BookStoreRepository bookStoreRepository;
        private BookQueryRepository bookQueryRepository;
        
        public BookApplication() {
            this.bookStoreRepository = new BookStoreRepository();
            this.bookQueryRepository = new BookQueryRepository();
        }

        public BookRepository DetailById(long id)
        {
            return this.bookQueryRepository.FindById(id);
        }

        public void CreateFromAPI(BookCreate bookCreate) {
            BookRepository bookRepository = new BookRepository();

            bookRepository.Name = bookCreate.Name;
            bookRepository.Sinopsis = bookCreate.Sinopsis;
            bookRepository.AuthorId = bookCreate.AuthorId;

            this.bookStoreRepository.Create(bookRepository);
        }
        public void UpdateFromAPI(long id, BookCreate bookCreate) {
            BookRepository bookRepository = new BookRepository();

            bookRepository.Name = bookCreate.Name;
            bookRepository.Sinopsis = bookCreate.Sinopsis;

            this.bookStoreRepository.Update(id, bookRepository);
        }
    }
}
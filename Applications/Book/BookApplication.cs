using BookApi.Requests.Book;
using BookApi.Repositories.Book;
using System.Collections.Generic;

namespace BookApi.Applications.Book
{
    public class BookApplication
    {
        private BookStoreRepository bookStoreRepository;
        private BookQueryRepository bookQueryRepository;

        public BookApplication()
        {
            this.bookStoreRepository = new BookStoreRepository();
            this.bookQueryRepository = new BookQueryRepository();
        }

        public BookRepository DetailById(long id)
        {
            return this.bookQueryRepository.FindById(id);
        }

        public List<BookRepository> GetList(string search, int perPage, int page)
        {
            return this.bookQueryRepository.Get(search, perPage, page);
        }

        public void CreateFromAPI(BookCreate bookCreate)
        {
            BookRepository bookRepository = new BookRepository();

            bookRepository.Name = bookCreate.Name;
            bookRepository.Sinopsis = bookCreate.Sinopsis;
            bookRepository.Authorid = bookCreate.Authorid;

            this.bookStoreRepository.Create(bookRepository);
        }
        public void UpdateFromAPI(long id, BookUpdate bookUpdate)
        {
            BookRepository bookRepository = new BookRepository();

            bookRepository.Name = bookUpdate.Name;
            bookRepository.Sinopsis = bookUpdate.Sinopsis;

            this.bookStoreRepository.Update(id, bookRepository);
        }
        public void DeleteFromAPI(long id)
        {
            this.bookStoreRepository.Delete(id);
        }
    }
}
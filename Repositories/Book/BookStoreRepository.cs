using System.Linq;
using System.Collections.Generic;
using BookApi.Repositories.Author;
using BookApi.Exceptions;
using System.Text.Json;

namespace BookApi.Repositories.Book
{

    public class BookStoreRepository
    {
        Models.Context context;
        BookQueryRepository bookQueryRepository;
        AuthorQueryRepository authorQueryRepository;

        public BookStoreRepository()
        {
            this.authorQueryRepository = new AuthorQueryRepository();
            this.context = new Models.Context();
            this.bookQueryRepository = new BookQueryRepository();
        }

        public void Create(BookRepository bookRepository)
        {
            this.validationData(bookRepository);
            Models.Book newBook = new Models.Book();

            newBook.Name = bookRepository.Name;
            newBook.Sinopsis = bookRepository.Sinopsis;
            newBook.AuthorId = bookRepository.AuthorId;

            this.save(newBook);
        }

        public void Update(long id, BookRepository bookRepository)
        {
            this.validationData(bookRepository);
            Models.Book oldBook = this.bookQueryRepository.Find(id);
            if (oldBook == null)
            {
                return;
            }

            oldBook.Name = bookRepository.Name;
            oldBook.Sinopsis = bookRepository.Sinopsis;
            oldBook.AuthorId = bookRepository.AuthorId;

            this.save(oldBook, true);
        }

        public void Delete(long id)
        {
            Models.Book book = this.context.Books.Where(book => book.Id == id).FirstOrDefault();
            this.context.Books.Remove(book);
            this.context.SaveChanges();
        }

        private void save(Models.Book Book, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.Books.Add(Book);
            }
            this.context.SaveChanges();
        }

        private void validationData(BookRepository bookRepository)
        {
            List<IDictionary<string, string>> validation = new List<IDictionary<string, string>>();

            AuthorRepository authorRepository = this.authorQueryRepository.FindById(bookRepository.AuthorId);
            if (authorRepository.Id < 1)
            {
                validation = Utility.CreateSingleValidation("authorid", "Not Exist");
                throw (new DataException(JsonSerializer.Serialize(validation)));
            }

        }
    }
}
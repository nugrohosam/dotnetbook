using System.Linq;
using System.Data.Entity;

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
            newBook.AuthorId = bookRepository.AuthorId;

            this.save(newBook);
        }

        public void Update(long id, BookRepository bookRepository)
        {
            Models.Book oldBook = this.bookQueryRepository.Find(id);

            oldBook.Name = bookRepository.Name;
            oldBook.Sinopsis = bookRepository.Sinopsis;

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
            if (!isUpdate){
                this.context.Books.Add(Book);
            }
            this.context.SaveChanges();
        }
    }
}
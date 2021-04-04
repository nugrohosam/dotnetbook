using Models = BookApi.Models;
using System.Linq;
using System.Data.Entity; 
using System; 

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
            return this.context.Books.Include(Book => Book.Author).Where(Book => Book.Id == id).First();
        }

        public BookRepository FindById(long id = 0)
        {
            Models.Book Book = this.Find(id);
            
            this.bookRepository.Id = Book.Id;
            this.bookRepository.Name = Book.Name;
            this.bookRepository.Sinopsis = Book.Sinopsis;
            this.bookRepository.AuthorId = Book.AuthorId;
            this.bookRepository.Author = Book.Author;

            return this.bookRepository;
        }
    }
}
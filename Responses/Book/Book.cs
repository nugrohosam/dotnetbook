using BookApi.Repositories.Book;
using BookApi.Responses.Author;
using System.Collections.Generic;

namespace BookApi.Responses.Book
{
    public class BookDetail {
        
        public long id { get; set; }
        public string name { get; set; }
        public string sinopsis { get; set; }

        public long author_id { get; set; }
        public AuthorItem author { get; set; }

        public BookDetail BindRepo(BookRepository bookRepository) {
            this.id = bookRepository.Id;
            this.name = bookRepository.Name;
            this.sinopsis = bookRepository.Sinopsis;
            this.author_id = bookRepository.AuthorId;
            this.author = (new AuthorItem()).BindRepo(bookRepository.Author);

            return this;
        }
    }
    public class BookItem {
        
        public long id { get; set; }
        public string name { get; set; }
        public string sinopsis { get; set; }
        public long author_id { get; set; }
        
        public BookItem BindRepo(BookRepository bookRepository) {
            this.id = bookRepository.Id;
            this.name = bookRepository.Name;
            this.sinopsis = bookRepository.Sinopsis;
            this.author_id = bookRepository.AuthorId;
            return this;
        }
        
        public List<BookItem> MapRepo(List<BookRepository> bookRepositories) {
            List<BookItem> books = new List<BookItem>();
            if (bookRepositories == null){
                return (new List<BookItem>());
            }

            foreach (BookRepository book in bookRepositories){
                books.Add(this.BindRepo(book));
            }

            return books;
        }

    }

    public class BookList {
        
        public List<BookItem> data { get; set; }
        public string count { get; set; }
    }
}
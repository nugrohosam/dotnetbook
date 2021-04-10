using BookApi.Repositories.Book;
using BookApi.Responses.Author;
using System.Collections.Generic;

namespace BookApi.Responses.Book
{
    public class BookDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Sinopsis { get; set; }

        public long Authorid { get; set; }
        public AuthorItem Author { get; set; }

        public BookDetail(BookRepository bookRepository)
        {
            this.Id = bookRepository.Id;
            this.Name = bookRepository.Name;
            this.Sinopsis = bookRepository.Sinopsis;
            this.Authorid = bookRepository.Authorid;
            this.Author = (new AuthorItem(bookRepository.Author));
        }
    }
    public class BookItem
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Sinopsis { get; set; }
        public long Authorid { get; set; }

        public BookItem(BookRepository bookRepository)
        {
            this.Id = bookRepository.Id;
            this.Name = bookRepository.Name;
            this.Sinopsis = bookRepository.Sinopsis;
            this.Authorid = bookRepository.Authorid;
        }

        public static List<BookItem> MapRepo(List<BookRepository> bookRepositories)
        {
            List<BookItem> books = new List<BookItem>();
            if (bookRepositories == null)
            {
                return (new List<BookItem>());
            }

            foreach (BookRepository book in bookRepositories)
            {
                books.Add((new BookItem(book)));
            }

            return books;
        }
    }

    public class BookList
    {
        public List<BookItem> Data { get; set; }

        public string Count { get; set; }

    }
}
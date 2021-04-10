using BookApi.Repositories.Author;
using BookApi.Responses.Book;
using System.Collections.Generic;

namespace BookApi.Responses.Author
{
    public class AuthorDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<BookItem> Books { get; set; }

        public AuthorDetail()
        {
        }

        public AuthorDetail(AuthorRepository authorRepository)
        {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;
            if (authorRepository.Books != null)
            {
                this.Books = BookItem.MapRepo(authorRepository.Books);
            }
        }
    }
    public class AuthorItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public AuthorItem()
        {
        }

        public AuthorItem(AuthorRepository authorRepository)
        {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;
        }
        public static List<AuthorItem> MapRepo(List<AuthorRepository> authorRepositories)
        {
            List<AuthorItem> Books = new List<AuthorItem>();
            if (authorRepositories == null)
            {
                return (new List<AuthorItem>());
            }

            foreach (AuthorRepository author in authorRepositories)
            {
                Books.Add(new AuthorItem(author));
            }

            return Books;
        }
    }
    public class AuthorList
    {

        public List<AuthorDetail> data { get; set; }
        public string count { get; set; }
    }
}
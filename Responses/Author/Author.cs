using BookApi.Repositories.Author;
using BookApi.Responses.Book;
using Models = BookApi.Models;
using System.Collections.Generic;

namespace BookApi.Responses.Author
{
    public class AuthorDetail
    {

        public long id { get; set; }
        public string name { get; set; }
        public List<BookItem> books { get; set; }

        public AuthorDetail BindRepo(AuthorRepository authorRepository)
        {
            this.id = authorRepository.Id;
            this.name = authorRepository.Name;
            if (authorRepository.Books != null){
                this.books = (new BookItem()).MapRepo(authorRepository.Books);
            }
            
            return this;
        }
    }
    public class AuthorItem
    {

        public long id { get; set; }
        public string name { get; set; }

        public AuthorItem BindRepo(AuthorRepository authorRepository)
        {
            this.id = authorRepository.Id;
            this.name = authorRepository.Name;
            return this;
        }
    }

    public class AuthorList
    {

        public List<AuthorDetail> data { get; set; }
        public string count { get; set; }
    }
}
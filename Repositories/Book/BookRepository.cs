using Models = BookApi.Models;
using System.Collections.Generic;
using BookApi.Repositories.Author;

namespace BookApi.Repositories.Book
{
    public class BookRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Sinopsis { get; set; }
        public long AuthorId { get; set; }
        public AuthorRepository Author { get; set; }

        public void MapToAuthorRepo(Models.Author author) {
            this.Author = new AuthorRepository() {
                Name = author.Name,
                Id = author.Id
            };
        }
    }
}
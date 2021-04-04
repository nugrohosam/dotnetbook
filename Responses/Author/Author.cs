using BookApi.Repositories.Author;
using Models = BookApi.Models;

namespace BookApi.Responses.Author
{
    public class AuthorDetail {
        
        public long Id { get; set; }
        public string Name { get; set; }

        public AuthorDetail BindRepo(AuthorRepository authorRepository) {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;

            return this;
        }

        public AuthorDetail BindModel(Models.Author Author) {
            this.Id = Author.Id;
            this.Name = Author.Name;

            return this;
        }
    }
}
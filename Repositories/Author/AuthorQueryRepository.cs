using Models = BookApi.Models;
using System.Linq;

namespace BookApi.Repositories.Author
{
    public class AuthorQueryRepository
    {
        Models.Context context;
        private AuthorRepository authorRepository;

        public AuthorQueryRepository()
        {
            this.context = new Models.Context(); 
            this.authorRepository = new AuthorRepository();
        }

        internal Models.Author Find(long id = 0)
        {
            return this.context.Authors.Where(Author => Author.Id == id).First();
        }

        public AuthorRepository FindById(long id = 0)
        {
            Models.Author Author = this.Find(id);
            
            this.authorRepository.Id = Author.Id;
            this.authorRepository.Name = Author.Name;

            return this.authorRepository;
        }
    }
}
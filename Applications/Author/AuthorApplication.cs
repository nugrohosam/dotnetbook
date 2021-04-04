using BookApi.Requests.Author;
using BookApi.Repositories.Author;

namespace BookApi.Applications.Author
{
    public class AuthorApplication
    {
        private AuthorStoreRepository authorStoreRepository;
        private AuthorQueryRepository authorQueryRepository;
        
        public AuthorApplication()
        {
            this.authorStoreRepository = new AuthorStoreRepository();
            this.authorQueryRepository = new AuthorQueryRepository();
        }

        public void CreateFromAPI(AuthorCreate authorCreate)
        {
            AuthorRepository authorRepository = new AuthorRepository();

            authorRepository.Name = authorCreate.Name;

            this.authorStoreRepository.Create(authorRepository);
        }

        public AuthorRepository DetailById(long id)
        {
            AuthorRepository authorRepository = this.authorQueryRepository.FindById(id);
            return authorRepository;
        }

        public void UpdateFromAPI(long id, AuthorCreate authorCreate)
        {
            AuthorRepository authorRepository = new AuthorRepository();

            authorRepository.Name = authorCreate.Name;

            this.authorStoreRepository.Update(id, authorRepository);
        }
    }
}
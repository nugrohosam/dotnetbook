using BookApi.Requests.Author;
using BookApi.Repositories.Author;
using System.Collections.Generic;

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
            return this.authorQueryRepository.FindById(id);
        }

        public List<AuthorRepository> GetList(string search, int page, int perPage)
        {
            return this.authorQueryRepository.Get(search, page, perPage);
        }

        public void UpdateFromAPI(long id, AuthorUpdate authorUpdate)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            authorRepository.Name = authorUpdate.Name;
            this.authorStoreRepository.Update(id, authorRepository);
        }

        public void DeleteFromAPI(long id)
        {
            this.authorStoreRepository.Delete(id);
        }
    }
}
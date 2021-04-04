using Models = BookApi.Models;

namespace BookApi.Repositories.Author
{
    public class AuthorStoreRepository
    {
        private AuthorQueryRepository authorQueryRepository;
        private Models.Context context;

        public AuthorStoreRepository()
        {
            this.context = new Models.Context();
            this.authorQueryRepository = new AuthorQueryRepository();
        }

        public void Create(AuthorRepository authorRepository)
        {
            Models.Author newAuthor = new Models.Author();

            newAuthor.Name = authorRepository.Name;

            this.save(newAuthor);
        }

        public void Update(long id, AuthorRepository authorRepository)
        {
            Models.Author oldAuthor = this.authorQueryRepository.Find(id);
            oldAuthor.Name = authorRepository.Name;
            this.save(oldAuthor);
        }

        private void save(Models.Author Author)
        {
            this.context.Authors.Add(Author);
            this.context.SaveChanges();
        }
    }
}
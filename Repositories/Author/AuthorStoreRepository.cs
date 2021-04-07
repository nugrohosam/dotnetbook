using Models = BookApi.Models;
using System.Linq;
using System;

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
            if (oldAuthor == null)
            {
                return;
            }

            oldAuthor.Name = authorRepository.Name;
            this.save(oldAuthor);
        }

        public void Delete(long id)
        {
            Models.Author author = this.context.Authors.Where(author => author.Id == id).FirstOrDefault();
            this.context.Authors.Remove(author);
            this.context.SaveChanges();
        }

        private void save(Models.Author Author, bool isUpdate = false)
        {
            if (isUpdate)
            {
                this.context.Authors.Add(Author);
            }
            this.context.SaveChanges();
        }
    }
}
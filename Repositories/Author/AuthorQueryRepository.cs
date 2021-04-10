using Models = BookApi.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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
            return this.context.Authors.Include(author => author.Books).Where(author => author.Id == id).FirstOrDefault();
        }

        public AuthorRepository FindById(long id = 0)
        {
            Models.Author author = this.Find(id);
            if (author == null)
            {
                return (new AuthorRepository());
            }

            this.authorRepository.Id = author.Id;
            this.authorRepository.Name = author.Name;
            this.authorRepository.MapToListBook(author.Books);

            return this.authorRepository;
        }
        public List<AuthorRepository> Get(string search, int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.Author> authors;
            IQueryable<Models.Author> authorQuery = this.context.Authors;
            if (search != null)
            {
                authorQuery = authorQuery.Where(author => author.Name.Contains(search));
            }

            authors = authorQuery.Skip(skip).Take(perPage).ToList<Models.Author>();
            return this.authorRepository.MapFromModel(authors);
        }
    }
}
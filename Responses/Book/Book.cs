using BookApi.Repositories.Book;
using BookApi.Responses.Author;

namespace BookApi.Responses.Book
{
    public class BookDetail {
        
        public long id { get; set; }
        public string name { get; set; }
        public string sinopsis { get; set; }

        public long author_id { get; set; }
        public AuthorDetail Author { get; set; }

        public BookDetail BindRepo(BookRepository authorRepository) {
            this.id = authorRepository.Id;
            this.name = authorRepository.Name;
            this.sinopsis = authorRepository.Sinopsis;
            this.author_id = authorRepository.AuthorId;

            if (authorRepository.Author != null){
                this.Author = (new AuthorDetail()).BindModel(authorRepository.Author);
            }

            return this;
        }
    }
}
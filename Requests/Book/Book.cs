using System.ComponentModel.DataAnnotations;
using BookApi.Validations.Author;

namespace BookApi.Requests.Book
{
    public class BookCreate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Sinopsis { get; set; }

        [Required]
        public long Authorid { get; set; }
    }
    public class BookUpdate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Sinopsis { get; set; }

        [Required]
        [IsExists("Author not exist")]
        public long Authorid { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using AuthorValidation = BookApi.Validations.Author;
using Microsoft.AspNetCore.Mvc;

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
        [AuthorValidation.IsExists("Author not exist")]
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
        [AuthorValidation.IsExists("Author not exist")]
        public long Authorid { get; set; }
    }
}
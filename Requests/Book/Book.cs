using System.ComponentModel.DataAnnotations;
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
        public long AuthorId { get; set; }
    }
}
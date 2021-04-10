using System.ComponentModel.DataAnnotations;
namespace BookApi.Requests.Author
{
    public class AuthorCreate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
    public class AuthorUpdate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
namespace BookApi.Requests.User
{
    public class UserCreate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
    public class UserUpdate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
}
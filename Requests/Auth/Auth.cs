using System.ComponentModel.DataAnnotations;
using UserValidation = BookApi.Validations.User;

namespace BookApi.Requests.Auth
{
    public class AuthSignIn
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class AuthRegister
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [UserValidation.Unique("email", "Email is exists")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
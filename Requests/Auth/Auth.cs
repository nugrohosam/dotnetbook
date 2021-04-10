using System.ComponentModel.DataAnnotations;
namespace BookApi.Requests.Auth
{
    public class AuthSignIn
    {
        [Required]
        public string Email { get; set; }
    }
}
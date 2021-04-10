using System.ComponentModel.DataAnnotations;
namespace BookApi.Requests.Role
{
    public class RoleCreate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
    public class RoleUpdate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
}
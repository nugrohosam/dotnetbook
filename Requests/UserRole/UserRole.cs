using System.ComponentModel.DataAnnotations;
namespace BookApi.Requests.UserRole
{
    public class UserRoleCreate
    {
        [Required]
        public long Userid { get; set; }
        [Required]
        public long Roleid { get; set; }
    }
    public class UserRoleUpdate
    {
        [Required]
        public long Userid { get; set; }
        [Required]
        public long Roleid { get; set; }
    }
}
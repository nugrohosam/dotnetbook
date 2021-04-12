using System.ComponentModel.DataAnnotations;
using ValidationUser = BookApi.Validations.User;
using ValidationRole = BookApi.Validations.Role;
namespace BookApi.Requests.UserRole
{
    public class UserRoleCreate
    {
        [Required]
        [ValidationRole.IsExists("User not found")]
        public long Userid { get; set; }
        [Required]
        [ValidationUser.IsExists("User not found")]
        public long Roleid { get; set; }
    }
    public class UserRoleUpdate
    {
        [Required]
        [ValidationRole.IsExists("User not found")]
        public long Userid { get; set; }
        [Required]
        [ValidationUser.IsExists("User not found")]
        public long Roleid { get; set; }
    }
}
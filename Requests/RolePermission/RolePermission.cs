using System.ComponentModel.DataAnnotations;
using ValidationUser = BookApi.Validations.User;
using ValidationRole = BookApi.Validations.Role;
namespace BookApi.Requests.RolePermission
{
    public class RolePermissionCreate
    {
        [Required]
        [ValidationRole.IsExists("User not found")]
        public long Permissionid { get; set; }
        [Required]
        [ValidationUser.IsExists("User not found")]
        public long Roleid { get; set; }
    }
    public class RolePermissionUpdate
    {
        [Required]
        [ValidationRole.IsExists("User not found")]
        public long Permissionid { get; set; }
        [Required]
        [ValidationUser.IsExists("User not found")]
        public long Roleid { get; set; }
    }
}
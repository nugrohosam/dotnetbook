using System.ComponentModel.DataAnnotations;
using ValidationPermission = BookApi.Validations.Permission;
using ValidationRole = BookApi.Validations.Role;
namespace BookApi.Requests.RolePermission
{
    public class RolePermissionCreate
    {
        [Required]
        [ValidationPermission.IsExists("Permission not found")]
        public long Permissionid { get; set; }
        [Required]
        [ValidationRole.IsExists("Role not found")]
        public long Roleid { get; set; }
    }
    public class RolePermissionUpdate
    {
        [Required]
        [ValidationPermission.IsExists("Permission not found")]
        public long Permissionid { get; set; }
        [Required]
        [ValidationRole.IsExists("Role not found")]
        public long Roleid { get; set; }
    }
}
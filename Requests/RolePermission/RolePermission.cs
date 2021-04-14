using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationPermission = BookApi.Validations.Permission;
using ValidationRole = BookApi.Validations.Role;
using ValidationRolePermission = BookApi.Validations.RolePermission;

namespace BookApi.Requests.RolePermission
{
    public class RolePermissionCreate : IValidatableObject
    {
        [Required]
        [ValidationPermission.IsExists("Permission not found")]
        public long Permissionid { get; set; }
        [Required]
        [ValidationRole.IsExists("Role not found")]
        public long Roleid { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationRolePermission.IsExists isRolePermissionExists = new ValidationRolePermission.IsExists(Roleid, Permissionid);
            if (isRolePermissionExists.IsValid())
            {
                yield return new ValidationResult("Role and Permission is signed", new List<string> { "Roleid and Permissionid" });
            }
        }
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
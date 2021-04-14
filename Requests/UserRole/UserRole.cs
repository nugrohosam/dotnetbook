using System.ComponentModel.DataAnnotations;
using ValidationUser = BookApi.Validations.User;
using ValidationUserRole = BookApi.Validations.UserRole;
using ValidationRole = BookApi.Validations.Role;
using System.Collections.Generic;

namespace BookApi.Requests.UserRole
{
    public class UserRoleCreate : IValidatableObject
    {
        [Required]
        [ValidationUser.IsExists("User not found")]
        public long Userid { get; set; }
        [Required]
        [ValidationRole.IsExists("Role not found")]
        public long Roleid { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationUserRole.IsExists isUserRoleExists = new ValidationUserRole.IsExists(Userid, Roleid);
            if (isUserRoleExists.IsValid())
            {
                yield return new ValidationResult("User and Role is signed", new List<string> { "Userid and Roleid" });
            }
        }
    }

    public class UserRoleUpdate
    {
        [Required]
        [ValidationUser.IsExists("User not found")]
        public long Userid { get; set; }
        [Required]
        [ValidationRole.IsExists("Role found")]
        public long Roleid { get; set; }
    }
}
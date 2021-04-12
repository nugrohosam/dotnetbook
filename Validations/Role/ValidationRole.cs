using System.ComponentModel.DataAnnotations;
using System;
using BookApi.Applications.Role;
using BookApi.Repositories.Role;

namespace BookApi.Validations.Role
{
    public class IsExists : ValidationAttribute
    {
        RoleApplication roleApplication;

        public IsExists(string errorMessage) : base(errorMessage)
        {
            this.roleApplication = new RoleApplication();
        }
        
        public override bool IsValid(object value)
        {
            long roleId = Convert.ToInt64(value.ToString());
            RoleRepository roleRepository = this.roleApplication.DetailById(roleId);
            return roleRepository.Id > 0;
        }
    }
}
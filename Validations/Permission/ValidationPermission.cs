using System.ComponentModel.DataAnnotations;
using System;
using BookApi.Applications.Permission;
using BookApi.Repositories.Permission;

namespace BookApi.Validations.Permission
{
    public class IsExists : ValidationAttribute
    {
        PermissionApplication permissionApplication;

        public IsExists(string errorMessage) : base(errorMessage)
        {
            this.permissionApplication = new PermissionApplication();
        }
        
        public override bool IsValid(object value)
        {
            long permissionId = Convert.ToInt64(value.ToString());
            PermissionRepository permissionRepository = this.permissionApplication.DetailById(permissionId);
            return permissionRepository.Id > 0;
        }
    }
}
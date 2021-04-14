using BookApi.Applications.RolePermission;
using BookApi.Repositories.RolePermission;

namespace BookApi.Validations.RolePermission
{
    public class IsExists
    {
        RolePermissionApplication rolePermissionApplication;
        private long roleid;
        private long permissionid;

        public IsExists(long roleid, long permissionid)
        {
            this.rolePermissionApplication = new RolePermissionApplication();
            this.roleid = roleid;
            this.permissionid = permissionid;
        }

        public bool IsValid()
        {
            RolePermissionRepository rolePermissionRepository = this.rolePermissionApplication.DetailByRolePermission(this.roleid, this.permissionid);
            return rolePermissionRepository.Id > 0;
        }
    }
}
using Models = BookApi.Models;
using System.Linq;

namespace BookApi.Repositories.RolePermission
{
    public class RolePermissionStoreRepository
    {
        private RolePermissionQueryRepository rolePermissionQueryRepository;
        private Models.Context context;

        public RolePermissionStoreRepository()
        {
            this.context = new Models.Context();
            this.rolePermissionQueryRepository = new RolePermissionQueryRepository();
        }

        public void Create(RolePermissionRepository rolePermissionRepository)
        {
            Models.RolePermission newRolePermission = new Models.RolePermission();
            newRolePermission.Permissionid = rolePermissionRepository.Permissionid;
            newRolePermission.Roleid = rolePermissionRepository.Roleid;
            this.save(newRolePermission);
        }

        public void Update(long id, RolePermissionRepository rolePermissionRepository)
        {
            Models.RolePermission oldRolePermission = this.rolePermissionQueryRepository.Find(id);
            if (oldRolePermission == null)
            {
                return;
            }

            oldRolePermission.Permissionid = rolePermissionRepository.Permissionid;
            oldRolePermission.Roleid = rolePermissionRepository.Roleid;
            this.save(oldRolePermission, true);
        }

        public void Delete(long id)
        {
            Models.RolePermission rolePermission = this.context.RolePermissions.Where(rolePermission => rolePermission.Id == id).FirstOrDefault();
            this.context.RolePermissions.Remove(rolePermission);
            this.context.SaveChanges();
        }

        private void save(Models.RolePermission RolePermission, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.RolePermissions.Add(RolePermission);
            }
            this.context.SaveChanges();
        }
    }
}
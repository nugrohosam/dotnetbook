using Models = BookApi.Models;
using System.Linq;
using System;

namespace BookApi.Repositories.Permission
{
    public class PermissionStoreRepository
    {
        private PermissionQueryRepository permissionQueryRepository;
        private Models.Context context;

        public PermissionStoreRepository()
        {
            this.context = new Models.Context();
            this.permissionQueryRepository = new PermissionQueryRepository();
        }

        public void Create(PermissionRepository permissionRepository)
        {
            Models.Permission newPermission = new Models.Permission();
            newPermission.Name = permissionRepository.Name;
            this.save(newPermission);
        }

        public void Update(long id, PermissionRepository permissionRepository)
        {
            Models.Permission oldPermission = this.permissionQueryRepository.Find(id);
            if (oldPermission == null)
            {
                return;
            }

            oldPermission.Name = permissionRepository.Name;
            this.save(oldPermission, true);
        }

        public void Delete(long id)
        {
            Models.Permission permission = this.context.Permissions.Where(permission => permission.Id == id).FirstOrDefault();
            this.context.Permissions.Remove(permission);
            this.context.SaveChanges();
        }

        private void save(Models.Permission Permission, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.Permissions.Add(Permission);
            }
            this.context.SaveChanges();
        }
    }
}
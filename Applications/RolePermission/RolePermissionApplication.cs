using BookApi.Requests.RolePermission;
using BookApi.Repositories.RolePermission;
using System.Collections.Generic;

namespace BookApi.Applications.RolePermission
{
    public class RolePermissionApplication
    {
        private RolePermissionStoreRepository rolePermissionStoreRepository;
        private RolePermissionQueryRepository rolePermissionQueryRepository;

        public RolePermissionApplication()
        {
            this.rolePermissionStoreRepository = new RolePermissionStoreRepository();
            this.rolePermissionQueryRepository = new RolePermissionQueryRepository();
        }

        public void CreateFromAPI(RolePermissionCreate rolePermissionCreate)
        {
            RolePermissionRepository rolePermissionRepository = new RolePermissionRepository();
            rolePermissionRepository.Roleid = rolePermissionCreate.Roleid;
            rolePermissionRepository.Permissionid = rolePermissionCreate.Permissionid;
            this.rolePermissionStoreRepository.Create(rolePermissionRepository);
        }

        public RolePermissionRepository DetailById(long id)
        {
            return this.rolePermissionQueryRepository.FindById(id);
        }

        public RolePermissionRepository DetailByRolePermission(long roleid, long permissionid)
        {
            return this.rolePermissionQueryRepository.FindByRoleAndPermission(roleid, permissionid);
        }

        public List<RolePermissionRepository> GetList(int page, int perPage)
        {
            return this.rolePermissionQueryRepository.Get(page, perPage);
        }

        public int Count()
        {
            return this.rolePermissionQueryRepository.CountAll();
        }

        public void UpdateFromAPI(long id, RolePermissionUpdate rolePermissionUpdate)
        {
            RolePermissionRepository rolePermissionRepository = new RolePermissionRepository();
            rolePermissionRepository.Roleid = rolePermissionUpdate.Roleid;
            rolePermissionRepository.Permissionid = rolePermissionUpdate.Permissionid;
            this.rolePermissionStoreRepository.Update(id, rolePermissionRepository);
        }

        public void DeleteFromAPI(long id)
        {
            this.rolePermissionStoreRepository.Delete(id);
        }
    }
}
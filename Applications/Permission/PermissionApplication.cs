using BookApi.Requests.Permission;
using BookApi.Repositories.Permission;
using System.Collections.Generic;

namespace BookApi.Applications.Permission
{
    public class PermissionApplication
    {
        private PermissionStoreRepository permissionStoreRepository;
        private PermissionQueryRepository permissionQueryRepository;
        
        public PermissionApplication()
        {
            this.permissionStoreRepository = new PermissionStoreRepository();
            this.permissionQueryRepository = new PermissionQueryRepository();
        }

        public void CreateFromAPI(PermissionCreate permissionCreate)
        {
            PermissionRepository permissionRepository = new PermissionRepository();
            permissionRepository.Name = permissionCreate.Name;
            this.permissionStoreRepository.Create(permissionRepository);
        }

        public PermissionRepository DetailById(long id)
        {
            return this.permissionQueryRepository.FindById(id);
        }

        public List<PermissionRepository> GetList(string search, int page, int perPage)
        {
            return this.permissionQueryRepository.Get(search, page, perPage);
        }

        public void UpdateFromAPI(long id, PermissionUpdate permissionUpdate)
        {
            PermissionRepository permissionRepository = new PermissionRepository();
            permissionRepository.Name = permissionUpdate.Name;
            this.permissionStoreRepository.Update(id, permissionRepository);
        }

        public void DeleteFromAPI(long id)
        {
            this.permissionStoreRepository.Delete(id);
        }
    }
}
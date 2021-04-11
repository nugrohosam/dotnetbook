using BookApi.Requests.Role;
using BookApi.Repositories.Role;
using System.Collections.Generic;

namespace BookApi.Applications.Role
{
    public class RoleApplication
    {
        private RoleStoreRepository roleStoreRepository;
        private RoleQueryRepository roleQueryRepository;

        public RoleApplication()
        {
            this.roleStoreRepository = new RoleStoreRepository();
            this.roleQueryRepository = new RoleQueryRepository();
        }

        public void CreateFromAPI(RoleCreate roleCreate)
        {
            RoleRepository roleRepository = new RoleRepository();
            roleRepository.Name = roleCreate.Name;
            this.roleStoreRepository.Create(roleRepository);
        }

        public RoleRepository DetailById(long id)
        {
            return this.roleQueryRepository.FindById(id);
        }

        public List<RoleRepository> GetList(string search, int page, int perPage)
        {
            return this.roleQueryRepository.Get(search, page, perPage);
        }
        public int Count(string search)
        {
            return this.roleQueryRepository.CountAll(search);
        }

        public void UpdateFromAPI(long id, RoleUpdate roleUpdate)
        {
            RoleRepository roleRepository = new RoleRepository();
            roleRepository.Name = roleUpdate.Name;
            this.roleStoreRepository.Update(id, roleRepository);
        }

        public void DeleteFromAPI(long id)
        {
            this.roleStoreRepository.Delete(id);
        }
    }
}
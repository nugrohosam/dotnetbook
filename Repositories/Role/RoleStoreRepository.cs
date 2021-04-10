using Models = BookApi.Models;
using System.Linq;
using System;

namespace BookApi.Repositories.Role
{
    public class RoleStoreRepository
    {
        private RoleQueryRepository roleQueryRepository;
        private Models.Context context;

        public RoleStoreRepository()
        {
            this.context = new Models.Context();
            this.roleQueryRepository = new RoleQueryRepository();
        }

        public void Create(RoleRepository roleRepository)
        {
            Models.Role newRole = new Models.Role();
            newRole.Name = roleRepository.Name;
            this.save(newRole);
        }

        public void Update(long id, RoleRepository roleRepository)
        {
            Models.Role oldRole = this.roleQueryRepository.Find(id);
            if (oldRole == null)
            {
                return;
            }

            oldRole.Name = roleRepository.Name;
            this.save(oldRole, true);
        }

        public void Delete(long id)
        {
            Models.Role role = this.context.Roles.Where(role => role.Id == id).FirstOrDefault();
            this.context.Roles.Remove(role);
            this.context.SaveChanges();
        }

        private void save(Models.Role Role, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.Roles.Add(Role);
            }
            this.context.SaveChanges();
        }
    }
}
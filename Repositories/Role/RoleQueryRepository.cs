using Models = BookApi.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookApi.Repositories.Role
{
    public class RoleQueryRepository
    {
        Models.Context context;
        private RoleRepository roleRepository;

        public RoleQueryRepository()
        {
            this.context = new Models.Context();
            this.roleRepository = new RoleRepository();
        }

        internal Models.Role Find(long id = 0)
        {
            return this.context.Roles.Where(role => role.Id == id).FirstOrDefault();
        }

        public RoleRepository FindById(long id = 0)
        {
            Models.Role role = this.Find(id);
            if (role == null)
            {
                return (new RoleRepository());
            }

            this.roleRepository.Id = role.Id;
            this.roleRepository.Name = role.Name;

            return this.roleRepository;
        }

        public RoleRepository FindByName(string name)
        {
            Models.Role role = this.context.Roles.Where(role => role.Name == name).FirstOrDefault();
            if (role == null)
            {
                return (new RoleRepository());
            }

            this.roleRepository.Id = role.Id;
            this.roleRepository.Name = role.Name;

            return this.roleRepository;
        }

        public bool IsExistsByNameAndIds(string nameRole, long[] roleIds)
        {
            return this.context.Roles.Where(role => role.Name == nameRole).Where(role => roleIds.Contains(role.Id)).Count() > 0;
        }
        
        public List<RoleRepository> Get(string search, int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.Role> roles;
            IQueryable<Models.Role> roleQuery = this.context.Roles;
            if (search != null)
            {
                roleQuery = roleQuery.Where(role => role.Name.Contains(search));
            }
            roles = roleQuery.Skip(skip).Take(perPage).ToList();
            return this.roleRepository.MapFromModel(roles);
        }
    }
}
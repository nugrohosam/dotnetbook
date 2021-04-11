using Models = BookApi.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookApi.Repositories.Permission
{
    public class PermissionQueryRepository
    {
        Models.Context context;
        private PermissionRepository permissionRepository;

        public PermissionQueryRepository()
        {
            this.context = new Models.Context();
            this.permissionRepository = new PermissionRepository();
        }

        internal Models.Permission Find(long id = 0)
        {
            return this.context.Permissions.Where(permission => permission.Id == id).FirstOrDefault();
        }

        public PermissionRepository FindById(long id = 0)
        {
            Models.Permission permission = this.Find(id);
            if (permission == null)
            {
                return (new PermissionRepository());
            }

            this.permissionRepository.Id = permission.Id;
            this.permissionRepository.Name = permission.Name;

            return this.permissionRepository;
        }
        public PermissionRepository FindByName(string name)
        {
            Models.Permission permission = this.context.Permissions.Where(permission => permission.Name == name).FirstOrDefault();
            if (permission == null)
            {
                return (new PermissionRepository());
            }

            this.permissionRepository.Id = permission.Id;
            this.permissionRepository.Name = permission.Name;

            return this.permissionRepository;
        }
        public List<PermissionRepository> Get(string search, int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.Permission> permissions;
            IQueryable<Models.Permission> permissionQuery = this.context.Permissions;
            if (search != null)
            {
                permissionQuery = permissionQuery.Where(permission => permission.Name.Contains(search));
            }
            permissions = permissionQuery.Skip(skip).Take(perPage).ToList();
            return this.permissionRepository.MapFromModel(permissions);
        }
        public int CountAll(string search)
        {
            IQueryable<Models.Permission> permissionQuery = this.context.Permissions;
            if (search != null)
            {
                permissionQuery = permissionQuery.Where(permission => permission.Name.Contains(search));
            }
            
            return permissionQuery.Count();
        }
    }
}
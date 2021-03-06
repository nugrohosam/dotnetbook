using Models = BookApi.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookApi.Repositories.RolePermission
{
    public class RolePermissionQueryRepository
    {
        Models.Context context;
        private RolePermissionRepository rolePermissionRepository;

        public RolePermissionQueryRepository()
        {
            this.context = new Models.Context();
            this.rolePermissionRepository = new RolePermissionRepository();
        }

        internal Models.RolePermission Find(long id = 0)
        {
            return this.context.RolePermissions.Include("Role").Include("Permission").Where(rolePermission => rolePermission.Id == id).FirstOrDefault();
        }

        public RolePermissionRepository FindById(long id = 0)
        {
            Models.RolePermission rolePermission = this.Find(id);
            if (rolePermission == null)
            {
                return (new RolePermissionRepository());
            }

            this.rolePermissionRepository.Id = rolePermission.Id;
            this.rolePermissionRepository.Permissionid = rolePermission.Permissionid;
            this.rolePermissionRepository.Roleid = rolePermission.Roleid;
            this.rolePermissionRepository.MapToRoleRepo(rolePermission.Role);
            this.rolePermissionRepository.MapToPermissionRepo(rolePermission.Permission);

            return this.rolePermissionRepository;
        }

        public RolePermissionRepository FindByRoleAndPermission(long roleid, long permission)
        {
            Models.RolePermission rolePermission = this.context.RolePermissions
                .Where(rolePermission => rolePermission.Roleid == roleid && rolePermission.Permissionid == permission)
                .FirstOrDefault();

            if (rolePermission == null)
            {
                return (new RolePermissionRepository());
            }

            this.rolePermissionRepository.Id = rolePermission.Id;
            this.rolePermissionRepository.Permissionid = rolePermission.Permissionid;
            this.rolePermissionRepository.Roleid = rolePermission.Roleid;

            return this.rolePermissionRepository;
        }
        public List<RolePermissionRepository> Get(int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.RolePermission> rolePermissions;
            rolePermissions = this.context.RolePermissions.Skip(skip).Take(perPage).ToList();
            return this.rolePermissionRepository.MapFromModel(rolePermissions);
        }
        public int CountAll()
        {
            return this.context.RolePermissions.Count();
        }
    }
}
using BookApi.Repositories.RolePermission;
using BookApi.Repositories.Role;
using BookApi.Repositories.Permission;
using System.Collections.Generic;
using Models = BookApi.Models;

namespace BookApi.Repositories.RolePermission
{
    public class RolePermissionRepository
    {
        public long Id { get; set; }
        public long Permissionid { get; set; }
        public long Roleid { get; set; }

        public PermissionRepository Permission { get; set; }
        public RoleRepository Role { get; set; }

        public void MapToPermissionRepo(Models.Permission permission)
        {
            this.Permission = new PermissionRepository()
            {
                Name = permission.Name,
                Id = permission.Id
            };
        }

        public void MapToRoleRepo(Models.Role role)
        {
            this.Role = new RoleRepository()
            {
                Name = role.Name,
                Id = role.Id
            };
        }

        public List<RolePermissionRepository> MapFromModel(List<Models.RolePermission> rolePermissions)
        {
            if (rolePermissions == null)
            {
                return (new List<RolePermissionRepository>());
            }

            List<RolePermissionRepository> rolePermissionsRepo = new List<RolePermissionRepository>();
            foreach (Models.RolePermission rolePermission in rolePermissions)
            {
                rolePermissionsRepo.Add((new RolePermissionRepository()
                {
                    Permissionid = rolePermission.Permissionid,
                    Roleid = rolePermission.Roleid
                }));
            }

            return rolePermissionsRepo;
        }
    }
}
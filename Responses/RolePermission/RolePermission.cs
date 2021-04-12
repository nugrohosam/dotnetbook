using BookApi.Repositories.RolePermission;
using BookApi.Responses.Role;
using BookApi.Responses.Permission;
using System.Collections.Generic;

namespace BookApi.Responses.RolePermission
{
    public class RolePermissionDetail
    {
        public long Id { get; set; }
        public long Roleid { get; set; }
        public RoleItem Role { get; set; }
        public long Permissionid { get; set; }
        public PermissionItem Permission { get; set; }

        public RolePermissionDetail()
        {
        }

        public RolePermissionDetail(RolePermissionRepository rolePermissionRepository)
        {
            this.Id = rolePermissionRepository.Id;
            this.Roleid = rolePermissionRepository.Roleid;
            this.Permissionid = rolePermissionRepository.Permissionid;
            this.Permission = (new PermissionItem(rolePermissionRepository.Permission));
            this.Role = (new RoleItem(rolePermissionRepository.Role));
        }
    }
    public class RolePermissionItem
    {
        public long Id { get; set; }
        public long Roleid { get; set; }
        public long Permissionid { get; set; }

        public RolePermissionItem()
        {
        }

        public RolePermissionItem(RolePermissionRepository rolePermissionRepository)
        {
            this.Id = rolePermissionRepository.Id;
            this.Roleid = rolePermissionRepository.Roleid;
            this.Permissionid = rolePermissionRepository.Permissionid;
        }

        public static List<RolePermissionItem> MapRepo(List<RolePermissionRepository> rolePermissionRepositories)
        {
            List<RolePermissionItem> rolePermissions = new List<RolePermissionItem>();
            if (rolePermissionRepositories == null)
            {
                return (new List<RolePermissionItem>());
            }

            foreach (RolePermissionRepository rolePermission in rolePermissionRepositories)
            {
                rolePermissions.Add(new RolePermissionItem(rolePermission));
            }

            return rolePermissions;
        }
    }

    public class RolePermissionList
    {
        public List<RolePermissionDetail> Data { get; set; }
        public string Count { get; set; }
    }
}
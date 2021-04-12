using BookApi.Repositories.Permission;
using System.Collections.Generic;

namespace BookApi.Responses.Permission
{
    public class PermissionDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public PermissionDetail()
        {
        }

        public PermissionDetail(PermissionRepository permissionRepository)
        {
            this.Id = permissionRepository.Id;
            this.Name = permissionRepository.Name;
        }
    }
    public class PermissionItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public PermissionItem()
        {
        }

        public PermissionItem(PermissionRepository permissionRepository)
        {
            this.Id = permissionRepository.Id;
            this.Name = permissionRepository.Name;
        }
        
        public static List<PermissionItem> MapRepo(List<PermissionRepository> permissionRepositories)
        {
            List<PermissionItem> Books = new List<PermissionItem>();
            if (permissionRepositories == null)
            {
                return (new List<PermissionItem>());
            }

            foreach (PermissionRepository permission in permissionRepositories)
            {
                Books.Add(new PermissionItem(permission));
            }

            return Books;
        }
    }
    public class PermissionList
    {

        public List<PermissionDetail> data { get; set; }
        public string count { get; set; }
    }
}
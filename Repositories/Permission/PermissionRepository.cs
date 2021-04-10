using BookApi.Repositories.Book;
using System.Collections.Generic;
using Models = BookApi.Models;

namespace BookApi.Repositories.Permission
{
    public class PermissionRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<PermissionRepository> MapFromModel(List<Models.Permission> permissions)
        {
            if (permissions == null)
            {
                return (new List<PermissionRepository>());
            }

            List<PermissionRepository> permissionsRepo = new List<PermissionRepository>();
            foreach (Models.Permission permission in permissions)
            {
                permissionsRepo.Add((new PermissionRepository()
                {
                    Id = permission.Id,
                    Name = permission.Name
                }));
            }

            return permissionsRepo;
        }
    }
}
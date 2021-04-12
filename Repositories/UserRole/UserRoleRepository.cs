using BookApi.Repositories.UserRole;
using BookApi.Repositories.Role;
using BookApi.Repositories.User;
using System.Collections.Generic;
using Models = BookApi.Models;

namespace BookApi.Repositories.UserRole
{
    public class UserRoleRepository
    {
        public long Id { get; set; }
        public long Userid { get; set; }
        public long Roleid { get; set; }

        public UserRepository User { get; set; }
        public RoleRepository Role { get; set; }

        public void MapToUserRepo(Models.User user)
        {
            this.User = new UserRepository()
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public void MapToRoleRepo(Models.Role role)
        {
            this.Role = new RoleRepository()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public List<UserRoleRepository> MapFromModel(List<Models.UserRole> userRoles)
        {
            if (userRoles == null)
            {
                return (new List<UserRoleRepository>());
            }

            List<UserRoleRepository> userRolesRepo = new List<UserRoleRepository>();
            foreach (Models.UserRole userRole in userRoles)
            {
                userRolesRepo.Add((new UserRoleRepository()
                {
                    Id = userRole.Id,
                    Userid = userRole.Userid,
                    Roleid = userRole.Roleid
                }));
            }

            return userRolesRepo;
        }
    }
}
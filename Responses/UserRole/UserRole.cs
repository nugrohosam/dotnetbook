using BookApi.Repositories.UserRole;
using BookApi.Responses.Role;
using BookApi.Responses.User;
using System.Collections.Generic;

namespace BookApi.Responses.UserRole
{
    public class UserRoleDetail
    {
        public long Id { get; set; }
        public long Roleid { get; set; }
        public RoleItem Role { get; set; }
        public long Userid { get; set; }
        public UserItem User { get; set; }

        public UserRoleDetail()
        {
        }

        public UserRoleDetail(UserRoleRepository userRoleRepository)
        {
            this.Id = userRoleRepository.Id;
            this.Roleid = userRoleRepository.Roleid;
            this.Userid = userRoleRepository.Userid;
            this.User = (new UserItem(userRoleRepository.User));
            this.Role = (new RoleItem(userRoleRepository.Role));
        }
    }
    public class UserRoleItem
    {
        public long Id { get; set; }
        public long Roleid { get; set; }
        public long Userid { get; set; }
        
        public UserRoleItem()
        {
        }

        public UserRoleItem(UserRoleRepository userRoleRepository)
        {
            this.Id = userRoleRepository.Id;
            this.Roleid = userRoleRepository.Roleid;
            this.Userid = userRoleRepository.Userid;
        }

        public static List<UserRoleItem> MapRepo(List<UserRoleRepository> userRoleRepositories)
        {
            List<UserRoleItem> userRoles = new List<UserRoleItem>();
            if (userRoleRepositories == null)
            {
                return (new List<UserRoleItem>());
            }

            foreach (UserRoleRepository userRole in userRoleRepositories)
            {
                userRoles.Add(new UserRoleItem(userRole));
            }

            return userRoles;
        }
    }

    public class UserRoleList
    {
        public List<UserRoleDetail> Data { get; set; }
        public string Count { get; set; }
    }
}
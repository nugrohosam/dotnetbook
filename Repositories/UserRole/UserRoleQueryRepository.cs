using Models = BookApi.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookApi.Repositories.UserRole
{
    public class UserRoleQueryRepository
    {
        Models.Context context;
        private UserRoleRepository userRoleRepository;

        public UserRoleQueryRepository()
        {
            this.context = new Models.Context();
            this.userRoleRepository = new UserRoleRepository();
        }

        internal Models.UserRole Find(long id = 0)
        {
            return this.context.UserRoles.Include("User").Include("Role").Where(userRole => userRole.Id == id).FirstOrDefault();
        }

        public UserRoleRepository FindById(long id = 0)
        {
            Models.UserRole userRole = this.Find(id);
            if (userRole == null)
            {
                return (new UserRoleRepository());
            }

            this.userRoleRepository.Id = userRole.Id;
            this.userRoleRepository.Userid = userRole.Userid;
            this.userRoleRepository.Roleid = userRole.Roleid;
            this.userRoleRepository.MapToRoleRepo(userRole.Role);
            this.userRoleRepository.MapToUserRepo(userRole.User);
            
            return this.userRoleRepository;
        }

        public List<UserRoleRepository> FindByUserId(long userId = 0)
        {
            List<Models.UserRole> userRoles = this.context.UserRoles.Where(userRole => userRole.Userid == userId).ToList();
            if (userRoles.Count < 1)
            {
                return (new List<UserRoleRepository>());
            }

            return this.userRoleRepository.MapFromModel(userRoles);
        }

        public List<UserRoleRepository> Get(int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.UserRole> userRoles;
            IQueryable<Models.UserRole> userQuery = this.context.UserRoles;
            userRoles = userQuery.Skip(skip).Take(perPage).ToList();
            return this.userRoleRepository.MapFromModel(userRoles);
        }

        public int CountAll()
        {
            return this.context.UserRoles.Count();
        }
    }
}
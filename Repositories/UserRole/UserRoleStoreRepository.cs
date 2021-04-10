using Models = BookApi.Models;
using System.Linq;

namespace BookApi.Repositories.UserRole
{
    public class UserRoleStoreRepository
    {
        private UserRoleQueryRepository userRoleQueryRepository;
        private Models.Context context;

        public UserRoleStoreRepository()
        {
            this.context = new Models.Context();
            this.userRoleQueryRepository = new UserRoleQueryRepository();
        }

        public void Create(UserRoleRepository userRoleRepository)
        {
            Models.UserRole newUserRole = new Models.UserRole();
            newUserRole.Userid = userRoleRepository.Userid;
            newUserRole.Roleid = userRoleRepository.Roleid;
            this.save(newUserRole);
        }

        public void Update(long id, UserRoleRepository userRoleRepository)
        {
            Models.UserRole oldUserRole = this.userRoleQueryRepository.Find(id);
            if (oldUserRole == null)
            {
                return;
            }

            oldUserRole.Userid = userRoleRepository.Userid;
            oldUserRole.Roleid = userRoleRepository.Roleid;
            this.save(oldUserRole, true);
        }

        public void Delete(long id)
        {
            Models.UserRole userRole = this.context.UserRoles.Where(userRole => userRole.Id == id).FirstOrDefault();
            this.context.UserRoles.Remove(userRole);
            this.context.SaveChanges();
        }

        private void save(Models.UserRole UserRole, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.UserRoles.Add(UserRole);
            }
            this.context.SaveChanges();
        }
    }
}
using BookApi.Requests.UserRole;
using BookApi.Repositories.UserRole;
using System.Collections.Generic;

namespace BookApi.Applications.UserRole
{
    public class UserRoleApplication
    {
        private UserRoleStoreRepository userRoleStoreRepository;
        private UserRoleQueryRepository userRoleQueryRepository;

        public UserRoleApplication()
        {
            this.userRoleStoreRepository = new UserRoleStoreRepository();
            this.userRoleQueryRepository = new UserRoleQueryRepository();
        }

        public void CreateFromAPI(UserRoleCreate userRoleCreate)
        {
            UserRoleRepository userRoleRepository = new UserRoleRepository();
            userRoleRepository.Roleid = userRoleCreate.Roleid;
            userRoleRepository.Userid = userRoleCreate.Userid;
            this.userRoleStoreRepository.Create(userRoleRepository);
        }

        public UserRoleRepository DetailById(long id)
        {
            return this.userRoleQueryRepository.FindById(id);
        }

        public List<UserRoleRepository> GetList(int page, int perPage)
        {
            return this.userRoleQueryRepository.Get(page, perPage);
        }

        public int Count(string search)
        {
            return this.userRoleQueryRepository.CountAll();
        }

        public void UpdateFromAPI(long id, UserRoleUpdate userRoleUpdate)
        {
            UserRoleRepository userRoleRepository = new UserRoleRepository();
            userRoleRepository.Roleid = userRoleUpdate.Roleid;
            userRoleRepository.Userid = userRoleUpdate.Userid;
            this.userRoleStoreRepository.Update(id, userRoleRepository);
        }

        public void DeleteFromAPI(long id)
        {
            this.userRoleStoreRepository.Delete(id);
        }

        public UserRoleRepository DetailByUserRole(long userid, long roleid)
        {
            return this.userRoleQueryRepository.FindByUserAndRole(userid, roleid);
        }
    }
}
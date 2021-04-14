using BookApi.Applications.UserRole;
using BookApi.Repositories.UserRole;

namespace BookApi.Validations.UserRole
{
    public class IsExists
    {
        UserRoleApplication userRoleApplication;
        private long userid;
        private long roleid;

        public IsExists(long userid, long roleid)
        {
            this.userRoleApplication = new UserRoleApplication();
            this.userid = userid;
            this.roleid = roleid;
        }

        public bool IsValid()
        {
            UserRoleRepository userRoleRepository = this.userRoleApplication.DetailByUserRole(this.userid, this.roleid);
            return userRoleRepository.Id > 0;
        }
    }
}
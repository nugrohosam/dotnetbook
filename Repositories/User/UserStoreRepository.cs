using Models = BookApi.Models;
using System.Linq;

namespace BookApi.Repositories.User
{
    public class UserStoreRepository
    {
        private UserQueryRepository userQueryRepository;
        private Models.Context context;

        public UserStoreRepository()
        {
            this.context = new Models.Context();
            this.userQueryRepository = new UserQueryRepository();
        }

        public void Create(UserRepository userRepository)
        {
            Models.User newUser = new Models.User();

            newUser.Name = userRepository.Name;
            newUser.Email = userRepository.Email;
            newUser.Password = userRepository.Password;
            
            this.save(newUser);
        }

        public void Update(long id, UserRepository userRepository)
        {
            Models.User oldUser = this.userQueryRepository.Find(id);
            if (oldUser == null)
            {
                return;
            }

            oldUser.Name = userRepository.Name;
            this.save(oldUser, true);
        }

        public void Delete(long id)
        {
            Models.User user = this.context.Users.Where(user => user.Id == id).FirstOrDefault();
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }

        private void save(Models.User User, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.Users.Add(User);
            }
            this.context.SaveChanges();
        }
    }
}
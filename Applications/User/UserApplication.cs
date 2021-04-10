using BookApi.Requests.User;
using BookApi.Repositories.User;
using System.Collections.Generic;

namespace BookApi.Applications.User
{
    public class UserApplication
    {
        private UserStoreRepository userStoreRepository;
        private UserQueryRepository userQueryRepository;
        
        public UserApplication()
        {
            this.userStoreRepository = new UserStoreRepository();
            this.userQueryRepository = new UserQueryRepository();
        }

        public void CreateFromAPI(UserCreate userCreate)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Name = userCreate.Name;
            this.userStoreRepository.Create(userRepository);
        }

        public UserRepository DetailById(long id)
        {
            return this.userQueryRepository.FindById(id);
        }

        public List<UserRepository> GetList(string search, int page, int perPage)
        {
            return this.userQueryRepository.Get(search, page, perPage);
        }

        public void UpdateFromAPI(long id, UserUpdate userUpdate)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Name = userUpdate.Name;
            this.userStoreRepository.Update(id, userRepository);
        }

        public void DeleteFromAPI(long id)
        {
            this.userStoreRepository.Delete(id);
        }
    }
}
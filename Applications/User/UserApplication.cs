using BookApi.Requests.User;
using BookApi.Requests.Auth;
using BookApi.Repositories.User;
using System.Collections.Generic;
using BC = BCrypt.Net.BCrypt;

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

        public void RegisterFromAPI(AuthRegister authRegister)
        {
            UserRepository userRepository = new UserRepository();
            
            userRepository.Name = authRegister.Name;
            userRepository.Email = authRegister.Email;
            userRepository.Password = BC.HashPassword(authRegister.Password);

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
        public int Count(string search)
        {
            return this.userQueryRepository.CountAll(search);
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

        public UserRepository FindWhere(string column, string data)
        {
            return this.userQueryRepository.FindQueryWhere(column, data);
        }
    }
}
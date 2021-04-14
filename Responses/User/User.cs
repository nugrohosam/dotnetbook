using BookApi.Repositories.User;
using System.Collections.Generic;

namespace BookApi.Responses.User
{
    public class UserDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public UserDetail()
        {
        }

        public UserDetail(UserRepository userRepository)
        {
            this.Id = userRepository.Id;
            this.Name = userRepository.Name;
            this.Email = userRepository.Email;
        }
    }
    public class UserItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserItem()
        {
        }

        public UserItem(UserRepository userRepository)
        {
            this.Id = userRepository.Id;
            this.Name = userRepository.Name;
            this.Email = userRepository.Email;
        }
        public static List<UserItem> MapRepo(List<UserRepository> userRepositories)
        {
            List<UserItem> Books = new List<UserItem>();
            if (userRepositories == null)
            {
                return (new List<UserItem>());
            }

            foreach (UserRepository user in userRepositories)
            {
                Books.Add(new UserItem(user));
            }

            return Books;
        }
    }
    public class UserList
    {

        public List<UserDetail> Data { get; set; }
        public string Count { get; set; }
    }
}
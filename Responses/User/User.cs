using BookApi.Repositories.User;
using System.Collections.Generic;

namespace BookApi.Responses.User
{
    public class UserDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public UserDetail()
        {
        }

        public UserDetail(UserRepository userRepository)
        {
            this.Id = userRepository.Id;
            this.Name = userRepository.Name;
        }
    }
    public class UserItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public UserItem()
        {
        }

        public UserItem(UserRepository userRepository)
        {
            this.Id = userRepository.Id;
            this.Name = userRepository.Name;
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

        public List<UserDetail> data { get; set; }
        public string count { get; set; }
    }
}
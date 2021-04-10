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

        public UserDetail(UserRepository authorRepository)
        {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;
        }
    }
    public class UserItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public UserItem()
        {
        }

        public UserItem(UserRepository authorRepository)
        {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;
        }
        public static List<UserItem> MapRepo(List<UserRepository> authorRepositories)
        {
            List<UserItem> Books = new List<UserItem>();
            if (authorRepositories == null)
            {
                return (new List<UserItem>());
            }

            foreach (UserRepository author in authorRepositories)
            {
                Books.Add(new UserItem(author));
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
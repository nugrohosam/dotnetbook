using Models = BookApi.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.User
{
    public class UserQueryRepository
    {
        Models.Context context;
        private UserRepository userRepository;

        public UserQueryRepository()
        {
            this.context = new Models.Context();
            this.userRepository = new UserRepository();
        }

        internal Models.User Find(long id = 0)
        {
            return this.context.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public UserRepository FindById(long id = 0)
        {
            Models.User user = this.Find(id);
            if (user == null)
            {
                return (new UserRepository());
            }

            this.userRepository.Id = user.Id;
            this.userRepository.Name = user.Name;

            return this.userRepository;
        }
        public UserRepository FindByEmail(string email = "")
        {
            Models.User user = this.context.Users.Where(user => user.Email == email).FirstOrDefault();
            if (user == null)
            {
                return (new UserRepository());
            }

            this.userRepository.Id = user.Id;
            this.userRepository.Name = user.Name;
            this.userRepository.Email = user.Email;
            this.userRepository.Password = user.Password;

            return this.userRepository;
        }
        public UserRepository FindQueryWhere(string column, string data)
        {
            string query = $"SELECT * FROM users WHERE {column} = '{data}'";
            Models.User user = this.context.Users.FromSqlRaw(query).FirstOrDefault();
            if (user == null)
            {
                return (new UserRepository());
            }

            this.userRepository.Id = user.Id;
            this.userRepository.Name = user.Name;
            this.userRepository.Email = user.Email;
            this.userRepository.Password = user.Password;

            return this.userRepository;
        }
        public List<UserRepository> Get(string search, int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.User> users;
            IQueryable<Models.User> userQuery = this.context.Users;
            if (search != null)
            {
                userQuery = userQuery.Where(user => user.Name.Contains(search));
            }
            users = userQuery.Skip(skip).Take(perPage).ToList();
            return this.userRepository.MapFromModel(users);
        }
        public int CountAll(string search)
        {
            IQueryable<Models.User> userQuery = this.context.Users;
            if (search != null)
            {
                userQuery = userQuery.Where(user => user.Name.Contains(search));
            }
            return userQuery.Count();
        }
    }
}
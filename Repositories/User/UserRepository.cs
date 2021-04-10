using BookApi.Repositories.UserRole;
using System.Collections.Generic;
using Models = BookApi.Models;

namespace BookApi.Repositories.User
{
    public class UserRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<UserRepository> MapFromModel(List<Models.User> users)
        {
            if (users == null)
            {
                return (new List<UserRepository>());
            }

            List<UserRepository> usersRepo = new List<UserRepository>();
            foreach (Models.User user in users)
            {
                usersRepo.Add((new UserRepository()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }));
            }

            return usersRepo;
        }
    }
}
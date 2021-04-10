using BookApi.Repositories.Book;
using System.Collections.Generic;
using Models = BookApi.Models;

namespace BookApi.Repositories.Role
{
    public class RoleRepository
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<RoleRepository> MapFromModel(List<Models.Role> roles)
        {
            if (roles == null)
            {
                return (new List<RoleRepository>());
            }

            List<RoleRepository> rolesRepo = new List<RoleRepository>();
            foreach (Models.Role role in roles)
            {
                rolesRepo.Add((new RoleRepository()
                {
                    Id = role.Id,
                    Name = role.Name
                }));
            }

            return rolesRepo;
        }
    }
}
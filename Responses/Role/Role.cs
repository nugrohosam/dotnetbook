using BookApi.Repositories.Role;
using System.Collections.Generic;

namespace BookApi.Responses.Role
{
    public class RoleDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public RoleDetail()
        {
        }

        public RoleDetail(RoleRepository roleRepository)
        {
            this.Id = roleRepository.Id;
            this.Name = roleRepository.Name;
        }
    }
    public class RoleItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public RoleItem()
        {
        }

        public RoleItem(RoleRepository roleRepository)
        {
            this.Id = roleRepository.Id;
            this.Name = roleRepository.Name;
        }
        public static List<RoleItem> MapRepo(List<RoleRepository> roleRepositories)
        {
            List<RoleItem> Books = new List<RoleItem>();
            if (roleRepositories == null)
            {
                return (new List<RoleItem>());
            }

            foreach (RoleRepository role in roleRepositories)
            {
                Books.Add(new RoleItem(role));
            }

            return Books;
        }
    }
    public class RoleList
    {

        public List<RoleDetail> data { get; set; }
        public string count { get; set; }
    }
}
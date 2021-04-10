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

        public RoleDetail(RoleRepository authorRepository)
        {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;
        }
    }
    public class RoleItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public RoleItem()
        {
        }

        public RoleItem(RoleRepository authorRepository)
        {
            this.Id = authorRepository.Id;
            this.Name = authorRepository.Name;
        }
        public static List<RoleItem> MapRepo(List<RoleRepository> authorRepositories)
        {
            List<RoleItem> Books = new List<RoleItem>();
            if (authorRepositories == null)
            {
                return (new List<RoleItem>());
            }

            foreach (RoleRepository author in authorRepositories)
            {
                Books.Add(new RoleItem(author));
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
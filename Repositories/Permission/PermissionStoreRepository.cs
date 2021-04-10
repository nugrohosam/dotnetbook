using Models = BookApi.Models;
using System.Linq;
using System;

namespace BookApi.Repositories.Permission
{
    public class PermissionStoreRepository
    {
        private PermissionQueryRepository authorQueryRepository;
        private Models.Context context;

        public PermissionStoreRepository()
        {
            this.context = new Models.Context();
            this.authorQueryRepository = new PermissionQueryRepository();
        }

        public void Create(PermissionRepository authorRepository)
        {
            Models.Permission newPermission = new Models.Permission();
            newPermission.Name = authorRepository.Name;
            this.save(newPermission);
        }

        public void Update(long id, PermissionRepository authorRepository)
        {
            Models.Permission oldPermission = this.authorQueryRepository.Find(id);
            if (oldPermission == null)
            {
                return;
            }

            oldPermission.Name = authorRepository.Name;
            this.save(oldPermission, true);
        }

        public void Delete(long id)
        {
            Models.Permission author = this.context.Permissions.Where(author => author.Id == id).FirstOrDefault();
            this.context.Permissions.Remove(author);
            this.context.SaveChanges();
        }

        private void save(Models.Permission Permission, bool isUpdate = false)
        {
            if (!isUpdate)
            {
                this.context.Permissions.Add(Permission);
            }
            this.context.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookApi.Models
{
    [Table("roles")]
    public class Role
    {
        private readonly ILazyLoader lazyLoader;

        public Role()
        {
        }

        public Role(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        private List<UserRole> userRoles;
        public List<UserRole> UserRoles
        {
            get => this.lazyLoader.Load(this, ref userRoles);
            set => userRoles = value;
        }

        private List<RolePermission> rolePermissions;
        public List<RolePermission> RolePermissions
        {
            get => this.lazyLoader.Load(this, ref rolePermissions);
            set => rolePermissions = value;
        }
    }
}
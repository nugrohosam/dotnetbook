using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookApi.Models
{
    [Table("role_permission")]
    public class RolePermission
    {
        private readonly ILazyLoader lazyLoader;

        public RolePermission()
        {
        }

        public RolePermission(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }


        [Column("id")]
        public long Id { get; set; }

        [Column("roleid")]
        public long Roleid { get; set; }
        [ForeignKey(nameof(Roleid))]
        private Role role;
        public Role Role
        {
            get => this.lazyLoader.Load(this, ref role);
            set => role = value;
        }

        [Column("permissionid")]
        public long Permissionid { get; set; }
        [ForeignKey(nameof(Permissionid))]

        private Permission permission;
        public Permission Permission
        {
            get => this.lazyLoader.Load(this, ref permission);
            set => permission = value;
        }
    }
}
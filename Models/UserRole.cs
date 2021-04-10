using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookApi.Models
{
    [Table("user_role")]
    public class UserRole
    {
        private readonly ILazyLoader lazyLoader;

        public UserRole()
        {
        }

        public UserRole(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        [Column("id")]
        public long Id { get; set; }


        [Column("userid")]
        public long Userid { get; set; }
        [ForeignKey(nameof(Userid))]

        private User user;
        public User User
        {
            get => this.lazyLoader.Load(this, ref user);
            set => user = value;
        }

        [Column("roleid")]
        public long Roleid { get; set; }
        [ForeignKey(nameof(Roleid))]
        
        private Role role;
        public Role Role
        {
            get => this.lazyLoader.Load(this, ref role);
            set => role = value;
        }

    }
}
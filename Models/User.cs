using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookApi.Models
{
    [Table("users")]
    public class User
    {
        private readonly ILazyLoader lazyLoader;

        public User()
        {
        }

        public User(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("email")]
        public string email { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookApi.Models
{
    [Table("authors")]
    public class Author
    {
        private readonly ILazyLoader lazyLoader;

        public Author()
        {
        }

        public Author(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        private List<Book> books;
        public List<Book> Books
        {
            get => this.lazyLoader.Load(this, ref books);
            set => books = value;
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookApi.Models
{
    [Table("books")]
    public class Book
    {

        private readonly ILazyLoader lazyLoader;

        public Book()
        {
        }

        public Book(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("sinopsis", TypeName = "text")]
        public string Sinopsis { get; set; }

        [Column("authorid")]
        public long Authorid { get; set; }
        [ForeignKey(nameof(Authorid))]

        private Author author;
        public Author Author
        {
            get => this.lazyLoader.Load(this, ref author);
            set => author = value;
        }
    }
}
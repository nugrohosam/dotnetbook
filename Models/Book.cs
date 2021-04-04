using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("sinopsis", TypeName = "text")]
        public string Sinopsis { get; set; }

        [Column("authorid")]
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
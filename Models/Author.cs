using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models
{
    [Table("authors")]
    public class Author
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
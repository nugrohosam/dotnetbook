using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookApi.Models
{
    public partial class BookApiContext : DbContext
    {
        public BookApiContext()
        {
        }

        public BookApiContext(DbContextOptions<BookApiContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Author> author { get; set; }
        
        public IEnumerable<Author> authorModel { get; internal set; }
        
        public virtual DbSet<Book> book { get; set; }
        
        public IEnumerable<Book> bookModel { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

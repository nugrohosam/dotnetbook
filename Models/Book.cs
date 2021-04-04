using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Models
{
    public class Book
    {
        public long id { get; set; }
        public string name { get; set; }
        public string sinopsis { get; set; }
        public Author author { get; set; }
    }
}
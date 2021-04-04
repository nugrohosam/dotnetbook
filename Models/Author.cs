using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Models
{
    public class Author
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}
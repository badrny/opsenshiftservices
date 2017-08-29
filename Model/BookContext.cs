using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioWebServicesCore.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
           // Database.ExecuteSqlCommand("Drop Table Book");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Type>().ToTable("Type");
            modelBuilder.Entity<BookType>().ToTable("BookType");

        }
    }
}


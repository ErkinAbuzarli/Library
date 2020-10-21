using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> opt) : base(opt)
        {
            
        }

        public DbSet<Copy> Copies { get; set; }
        public DbSet<Book> Books { get; set; }      
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Assigned_Book> Assigned_Books { get; set; }
        public DbSet<History> History { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => p.Username)
                .IsUnique(true);
        }
    }
}
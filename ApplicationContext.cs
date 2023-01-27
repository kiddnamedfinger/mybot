using Microsoft.EntityFrameworkCore;
using ReaderBot.Models;

namespace ReaderBot
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<ReadableBook> ReadableBooks { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Configuration.DatabaseName}.db");
        }
    }
}

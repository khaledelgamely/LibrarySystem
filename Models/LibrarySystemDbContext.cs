using Microsoft.EntityFrameworkCore;

namespace librarySystem.Models
{
    public class LibrarySystemDbContext : DbContext
    {
        public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options)
        {
            
        }
        public DbSet <Author> Authors{ get; set; }
        public DbSet <Book> Books{ get; set; }
    }
}

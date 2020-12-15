using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
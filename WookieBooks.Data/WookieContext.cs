using Microsoft.EntityFrameworkCore;
using WookieBooks.Models.Dbs;

namespace WookieBooks.Data
{
    public class WookieContext : DbContext
    {
        public WookieContext(DbContextOptions<WookieContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany<Book>(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}

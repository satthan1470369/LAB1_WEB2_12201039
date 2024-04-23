using LAB1_WEB2_12201039.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LAB1_WEB2_12201039.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<BookAuthors> BookAuthorss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthors>()
                .HasKey(ba => new { ba.BookID, ba.AuthorID });

            modelBuilder.Entity<BookAuthors>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookID);

            modelBuilder.Entity<BookAuthors>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorID);
        }
    }
}
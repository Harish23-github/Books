using Books.Contracts.Books.Dtos;
using Books.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace Books.Domain
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        // Stored Procedure Result Mapping
        public DbSet<BookData> FirstSortedBookData { get; set; }
        public DbSet<CommonBookData> SecondSortedBookData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookData>().HasNoKey().ToView(null);
            modelBuilder.Entity<CommonBookData>().HasNoKey().ToView(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using webthuchanhbuoi1.Models;



namespace webthuchanhbuoi1.Data
{
    public class AppDbContext : DbContext
    {
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Authors> Author { get; set; }
        public DbSet<Book_Author> BookAuthor { get; set; }
        public DbSet<Books> Book { get; set; }
        public DbSet<Publishers> publisher { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book_Author>()
         .HasKey(bc => new { bc.BookId, bc.AuthorId});

            builder.Entity<Book_Author>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Book_Authors)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<Book_Author>()
                .HasOne(bc => bc.Author)
                .WithMany(a => a.Book_Authors)
                .HasForeignKey(bc => bc.AuthorId);
        }


    }
}

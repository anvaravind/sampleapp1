using Microsoft.EntityFrameworkCore;

namespace SchedulerSampleApp
{
    public class BookDB:DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
    }
}

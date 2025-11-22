using EMMAModel;
using Microsoft.EntityFrameworkCore;

namespace EMMAData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        


        public DbSet<Person> Persons { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}

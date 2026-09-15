using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

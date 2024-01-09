using LarTechAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LarTechAPi.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsuilder.UseSqlServer("Server=localhost,1433;Database=LarTechApi;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true;");

            return new ApplicationDbContext(optionsuilder.Options);
        }
    }
}

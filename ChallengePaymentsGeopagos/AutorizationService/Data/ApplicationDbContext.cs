using Microsoft.EntityFrameworkCore;
using AuthorizationService.Models;

namespace AuthorizationService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AuthorizationRequest> AuthorizationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorizationRequest>().ToTable("AuthorizationRequests");
        }
    }
}

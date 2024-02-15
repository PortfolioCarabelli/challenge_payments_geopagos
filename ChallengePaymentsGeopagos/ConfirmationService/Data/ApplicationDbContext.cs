using Microsoft.EntityFrameworkCore;
using AuthorizationService.Models;

namespace AuthorizationService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ConfirmationRequest> ConfirmationRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfirmationRequest>().ToTable("ConfirmationRequest");
        }
    }
}

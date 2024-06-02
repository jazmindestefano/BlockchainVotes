using Microsoft.EntityFrameworkCore;
using VoteSolution.Entities.Models;

namespace VoteSolution.Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Votation> Votation { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }
        public virtual DbSet<Option> Option { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Votation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Options).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Active).IsRequired();
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}

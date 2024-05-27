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

        public DbSet<Votation> Votations { get; set; }
    }
}

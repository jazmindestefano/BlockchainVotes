﻿using Microsoft.EntityFrameworkCore;
using VoteSolution.Entities.Models;

namespace VoteSolution.Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Votation> Votations { get; set; }

        public virtual DbSet<Option> Options { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Votation>(entity =>
            {
                entity.ToTable("Votation");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);
                entity.Property(e => e.IsActive).IsRequired();

                entity.HasMany(e => e.Options)
                      .WithOne(o => o.Votation)
                      .HasForeignKey(o => o.VotationId);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.VotationId).IsRequired();
                
                entity.HasOne(e => e.Votation)
                    .WithMany(o => o.Options)
                    .HasForeignKey(o => o.VotationId);
            });
        }
    }
}

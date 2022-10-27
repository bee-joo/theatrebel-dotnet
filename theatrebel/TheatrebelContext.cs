using Microsoft.EntityFrameworkCore;
using theatrebel.Data.Models;

namespace theatrebel
{
    public class TheatrebelContext : DbContext
    {
        public DbSet<Play> Plays { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Writer> Writers { get; set; } = null!;

        public TheatrebelContext(DbContextOptions<TheatrebelContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Play>(entity =>
            {
                entity.ToTable("plays");

                entity.Property(e => e.Id);

                entity.Property(e => e.Date);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.Origname)
                    .HasMaxLength(255);

                entity.HasMany(e => e.Writers)
                    .WithMany(w => w.Plays);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id);

                entity.Property(e => e.PlayId);

                entity.Property(e => e.Text)
                    .IsRequired(true)
                    .HasMaxLength(2000);

                entity.HasOne(e => e.Play)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(e => e.PlayId);
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.ToTable("writers");

                entity.Property(e => e.Id);

                entity.Property(e => e.Country)
                    .HasMaxLength(60);

                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.HasMany(e => e.Plays)
                    .WithMany(p => p.Writers);
            });
        }
    }
}

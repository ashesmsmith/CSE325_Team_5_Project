using Microsoft.EntityFrameworkCore;
using GoalGrower.Models;

namespace GoalGrower.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Goal> Goals => Set<Goal>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<Goal>()
                .HasMany(g => g.Transactions)
                .WithOne(t => t.Goal)
                .HasForeignKey(t => t.GoalId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

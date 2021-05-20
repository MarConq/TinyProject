using Microsoft.EntityFrameworkCore;
using TinyModel.Entities;

namespace TinyModel.Context
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<LoyaltyCardTransaction> LoyaltyCardTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Client>().HasMany(x => x.LoyaltyCards).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<LoyaltyCard>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<LoyaltyCard>().HasOne(x => x.Client).WithMany(x => x.LoyaltyCards).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<LoyaltyCardTransaction>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<LoyaltyCardTransaction>().Property(x => x.LoyaltyPointsEarned).HasPrecision(18, 2);
            builder.Entity<LoyaltyCardTransaction>().HasOne(x => x.Client).WithMany(x => x.LoyaltyCardTransactions).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

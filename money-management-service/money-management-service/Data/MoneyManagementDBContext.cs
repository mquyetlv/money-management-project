using Microsoft.EntityFrameworkCore;
using money_management_service.Core;
using money_management_service.Entities;

namespace money_management_service.Data
{
    public class MoneyManagementDBContext : DbContext
    {
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<MoneyStorage> MoneyStorages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<InvestmentPortfolio> InvestmentPortfolioes { get; set; }
        public DbSet<InvestmentHistory> InvestmentHistories { get; set; }

        public MoneyManagementDBContext(DbContextOptions<MoneyManagementDBContext> options) : base(options) { }

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = "ADMIN";
                    Console.WriteLine("Created by admin");
                }

                entity.UpdatedDate = DateTime.Now;
            }
        }
    }
}

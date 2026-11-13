using Microsoft.EntityFrameworkCore;
using Ots.Api.Domain;

namespace Ots.Api.DbContext;

public class OtsDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public OtsDbContext(DbContextOptions<OtsDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<CustomerPhone> CustomerPhones { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
    public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OtsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
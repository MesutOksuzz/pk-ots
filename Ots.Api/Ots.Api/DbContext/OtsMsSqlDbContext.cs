using Microsoft.EntityFrameworkCore;
using Ots.Api.Domain;

namespace Ots.Api.DbContext;

public class OtsMsSqlDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public OtsMsSqlDbContext(DbContextOptions<OtsMsSqlDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<CustomerPhone> CustomerPhones { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OtsMsSqlDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
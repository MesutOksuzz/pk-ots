using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ots.Base.Domain;

namespace Ots.Api.Domain;

[Table("Account", Schema = "dbo")]
public class Account : BaseEntity
{
    public long CustomerId { get; set; }
    //ihtiyaç oldugunda db den lazyloading
    public virtual Customer Customer { get; set; }

    public string Name { get; set; }
    public int AccountNumber { get; set; }
    public string IBAN { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyCode { get; set; }

    public virtual List<AccountTransaction> AccountTransactions { get; set; }
}



public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CustomerId).IsRequired(true);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.AccountNumber).IsRequired();
        builder.Property(x => x.IBAN).IsRequired().HasMaxLength(26);
        builder.Property(x => x.Balance).IsRequired().HasPrecision(18, 4);
        builder.Property(x => x.CurrencyCode).IsRequired().HasMaxLength(3);

        builder.HasMany(x => x.AccountTransactions)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId).IsRequired(true);
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ots.Base.Domain;

namespace Ots.Api.Domain;

[Table("AccountTransaction", Schema = "dbo")]
public class AccountTransaction : BaseEntity
{
    public long AccountId { get; set; }
    public virtual Account Account { get; set; }

    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime TransactionDate { get; set; }
    public string ReferenceNumber { get; set; }
}

public class AccountTransactionConfiguration : IEntityTypeConfiguration<AccountTransaction>
{
    public void Configure(EntityTypeBuilder<AccountTransaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.AccountId).IsRequired(true);
        builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 4);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
        builder.Property(x => x.TransactionDate).IsRequired();
        builder.Property(x => x.ReferenceNumber).IsRequired().HasMaxLength(50);
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ots.Base.Domain;

namespace Ots.Api.Domain;

[Table("MoneyTransfer", Schema = "dbo")]
public class MoneyTransfer : BaseEntity
{
    public long FromAccountId { get; set; }
    public virtual Account FromAccount { get; set; }
    
    public long ToAccountId { get; set; }
    public virtual Account ToAccount { get; set; }
    
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime TransactionDate { get; set; }
    public string ReferenceNumber { get; set; }
}

public class MoneyTransferConfiguration : IEntityTypeConfiguration<MoneyTransfer>
{
    public void Configure(EntityTypeBuilder<MoneyTransfer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 4);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
        builder.Property(x => x.TransactionDate).IsRequired();
        builder.Property(x => x.ReferenceNumber).IsRequired().HasMaxLength(50);

        builder.HasOne(x => x.FromAccount)
            .WithMany()
            .HasForeignKey(x => x.FromAccountId).IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ToAccount)
            .WithMany()
            .HasForeignKey(x => x.ToAccountId).IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
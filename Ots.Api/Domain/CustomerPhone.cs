using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Ots.Base.Domain;

namespace Ots.Api.Domain;

[Table("CustomerPhone",Schema = "dbo")]
public class CustomerPhone : BaseEntity
{
    public long CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsDefault { get; set; }
}

public class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
{
    public void Configure(EntityTypeBuilder<CustomerPhone> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CustomerId).IsRequired(true);
        builder.Property(x => x.CountryCode).IsRequired().HasMaxLength(3);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Property(x => x.IsDefault).IsRequired();
    }
}
using FluentValidation;
using Ots.Schema;

namespace Ots.Api.Impl.Validation;

public class CustomerAddressValidator : AbstractValidator<CustomerAddressRequest>
{
    public CustomerAddressValidator()
    {
        RuleFor(x => x.CountryCode).NotEmpty().Length(3).WithMessage("Please enter a valid country code");
        RuleFor(x => x.City).NotEmpty().Length(2, 50).WithMessage("Please enter a valid city name");
        RuleFor(x => x.District).NotEmpty().Length(2, 50).WithMessage("Please enter a valid district name");
        RuleFor(x => x.Street).NotEmpty().Length(2, 50).WithMessage("Please enter a valid street name");
        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(10).Matches("^[0-9]+$").WithMessage("Please enter a valid zip code");


    }
}
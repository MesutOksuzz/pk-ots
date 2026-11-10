using System.Data;
using FluentValidation;
using Ots.Api.Domain;

namespace Ots.Api.Impl.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(55);
        When(x => !string.IsNullOrEmpty(x.MiddleName), () =>
        {
            RuleFor(x => x.MiddleName).MaximumLength(50);
        });
        RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(55);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.IdentityNumber).MinimumLength(11);
    }
}
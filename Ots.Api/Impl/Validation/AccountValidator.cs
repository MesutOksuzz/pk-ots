using FluentValidation;
using Ots.Schema;

namespace Ots.Api.Impl.Validation;

public class AccountValidator : AbstractValidator<AccountRequest>
{
    public AccountValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().Length(2, 50);
        RuleFor(x => x.CurrencyCode).NotEmpty().Length(3); 
    }
    
}
using FluentValidation;
using Ots.Schema;

namespace Ots.Api.Impl.Validation;

public class AuthorizationValidator : AbstractValidator<AuthorizationRequest>
{
    public AuthorizationValidator()
    {
        RuleFor(x => x.UserName).Length(5, 50);
        RuleFor(x => x.Password).Length(5, 50);
    }
}

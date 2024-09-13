
using Catalog.API.Application.Dtos.Users;
using FluentValidation;

namespace Catalog.API.Application.Validators.Users;

public class UserRegistrationValidator : AbstractValidator<UserRegistrationDto>
{
    public UserRegistrationValidator()
    {
        RuleFor(u => u.FullName).NotEmpty();

        RuleFor(u => u.UserName).NotEmpty();
                                

        RuleFor(u => u.Email).NotEmpty()
                             .EmailAddress();

        RuleFor(u => u.Password).NotEmpty()
                                .MinimumLength(6)
                                .MaximumLength(16)
                                .Matches(@"[A-Z]+")
                                .Matches(@"[a-z]+")
                                .Matches(@"[0-9]+")
                                .Matches(@"[\@\!\?\*\.]+");
    }
}

using DotNetCore.Validation;
using FluentValidation;

namespace Architecture.Model
{
    public sealed class AuthModelValidator : Validator<AuthModel>
    {
        public AuthModelValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Roles).NotEmpty();
        }
    }
}

using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model.Models
{
    public sealed class SignOutModelValidator : Validator<SignOutModel>
    {
        public SignOutModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}

using DotNetCore.Validation;
using DotNetCoreArchitecture.CrossCutting.Resources;
using FluentValidation;

namespace DotNetCoreArchitecture.Model.Models
{
    public sealed class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator() : base(Texts.AuthenticationInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}

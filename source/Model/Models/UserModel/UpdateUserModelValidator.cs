using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model.Models
{
    public sealed class UpdateUserModelValidator : Validator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
        }
    }
}

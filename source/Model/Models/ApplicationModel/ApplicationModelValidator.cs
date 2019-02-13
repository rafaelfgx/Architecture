using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model.Models
{
    public sealed class ApplicationModelValidator : Validator<ApplicationModel>
    {
        public ApplicationModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Version).NotNull().NotEmpty();
        }
    }
}

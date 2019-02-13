using DotNetCore.Validation;
using DotNetCoreArchitecture.Model.Enums;
using FluentValidation;
using System;

namespace DotNetCoreArchitecture.Model.Models
{
    public sealed class UserLogModelValidator : Validator<UserLogModel>
    {
        public UserLogModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.LogType).NotNull().NotEmpty().NotEqual(LogType.None);
            RuleFor(x => x.DateTime).NotNull().NotEmpty().NotEqual(DateTime.MinValue);
        }
    }
}

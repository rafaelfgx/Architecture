using DotNetCore.Validation;
using FluentValidation;

namespace Architecture.Model
{
    public abstract class UserModelValidator : Validator<UserModel>
    {
        public void Auth()
        {
            RuleFor(x => x.Auth).SetValidator(new AuthModelValidator());
        }

        public void Email()
        {
            RuleFor(x => x.Email).NotEmpty();
        }

        public void Id()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

        public void Name()
        {
            RuleFor(x => x.Name).NotEmpty();
        }

        public void Surname()
        {
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}

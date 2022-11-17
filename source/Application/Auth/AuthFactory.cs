using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application;

public sealed class AuthFactory : IAuthFactory
{
    public Auth Create(AuthModel model) => new(model.Login, model.Password, (Roles)model.Roles);
}

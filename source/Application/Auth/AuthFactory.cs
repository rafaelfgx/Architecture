using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public static class AuthFactory
    {
        public static Auth Create(AuthModel model)
        {
            return new Auth(model.Login, model.Password, (Roles)model.Roles);
        }
    }
}

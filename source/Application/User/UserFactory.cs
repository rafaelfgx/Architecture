using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public static class UserFactory
    {
        public static User Create(UserModel model, Auth auth)
        {
            return new User
            (
                new FullName(model.Name, model.Surname),
                new Email(model.Email),
                auth
            );
        }
    }
}

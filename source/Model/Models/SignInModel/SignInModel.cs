using DotNetCore.Security;

namespace DotNetCoreArchitecture.Model.Models
{
    public class SignInModel
    {
        public SignInModel()
        {
        }

        public SignInModel(string login, string password) : this()
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public string LoginHash()
        {
            return new Hash().Create(Login);
        }

        public string PasswordHash()
        {
            return new Hash().Create(Password);
        }
    }
}

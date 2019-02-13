using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model.Models;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class AuthenticationApplication : IAuthenticationApplication
    {
        public AuthenticationApplication(IAuthenticationDomain authenticationDomain)
        {
            AuthenticationDomain = authenticationDomain;
        }

        private IAuthenticationDomain AuthenticationDomain { get; }

        public Task<IDataResult<string>> SignInAsync(SignInModel signInModel)
        {
            return AuthenticationDomain.SignInAsync(signInModel);
        }

        public Task SignOutAsync(SignOutModel signOutModel)
        {
            return AuthenticationDomain.SignOutAsync(signOutModel);
        }
    }
}

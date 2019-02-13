using DotNetCore.Objects;
using DotNetCoreArchitecture.Model.Models;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public interface IAuthenticationDomain
    {
        Task<IDataResult<string>> SignInAsync(SignInModel signInModel);

        Task SignOutAsync(SignOutModel signOutModel);
    }
}

using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            AuthenticationApplication = authenticationApplication;
        }

        private IAuthenticationApplication AuthenticationApplication { get; }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult SignIn(SignInModel signInModel)
        {
            return new DataResult(AuthenticationApplication.SignInAsync(signInModel).Result);
        }

        [HttpPost("[action]")]
        public Task SignOutAsync()
        {
            return AuthenticationApplication.SignOutAsync(new SignOutModel(User.Id()));
        }
    }
}

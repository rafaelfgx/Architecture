using DotNetCore.Objects;
using DotNetCore.Security;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Model.Enums;
using DotNetCoreArchitecture.Model.Models;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public sealed class AuthenticationDomain : IAuthenticationDomain
    {
        public AuthenticationDomain
        (
            IJsonWebToken jsonWebToken,
            IUserLogDomain userLogDomain,
            IUserRepository userRepository
        )
        {
            JsonWebToken = jsonWebToken;
            UserLogDomain = userLogDomain;
            UserRepository = userRepository;
        }

        private IJsonWebToken JsonWebToken { get; }

        private IUserLogDomain UserLogDomain { get; }

        private IUserRepository UserRepository { get; }

        public async Task<IDataResult<string>> SignInAsync(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Valid(signInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<string>(validation.Message);
            }

            var signedInModel = await UserRepository.SignInAsync(signInModel);

            validation = new SignedInModelValidator().Valid(signedInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<string>(validation.Message);
            }

            await AddUserLogAsync(signedInModel.UserId, LogType.SignIn);

            var jwt = CreateJwt(signedInModel);

            return new SuccessDataResult<string>(jwt);
        }

        public async Task SignOutAsync(SignOutModel signOutModel)
        {
            await AddUserLogAsync(signOutModel.UserId, LogType.SignOut);
        }

        private async Task AddUserLogAsync(long userId, LogType logType)
        {
            var userLogModel = new UserLogModel(userId, logType);

            await UserLogDomain.AddAsync(userLogModel);
        }

        private string CreateJwt(SignedInModel signedInModel)
        {
            var sub = signedInModel.UserId.ToString();

            var roles = signedInModel.Roles.ToString().Split(", ");

            return JsonWebToken.Encode(sub, roles);
        }
    }
}

using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Extensions;
using DotNetCore.Results;
using DotNetCore.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public sealed class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashService _hashService;
        private readonly IJsonWebTokenService _jsonWebTokenService;

        public AuthService
        (
            IAuthRepository authRepository,
            IHashService hashService,
            IJsonWebTokenService jsonWebTokenService
        )
        {
            _authRepository = authRepository;
            _hashService = hashService;
            _jsonWebTokenService = jsonWebTokenService;
        }

        public async Task<IResult<Auth>> AddAsync(AuthModel model)
        {
            var validation = await new AuthModelValidator().ValidateAsync(model);

            if (validation.Failed)
            {
                return Result<Auth>.Fail(validation.Message);
            }

            if (await _authRepository.AnyByLoginAsync(model.Login))
            {
                return Result<Auth>.Fail("Login already exists!");
            }

            var auth = AuthFactory.Create(model);

            var password = _hashService.Create(auth.Password, auth.Salt);

            auth.UpdatePassword(password);

            await _authRepository.AddAsync(auth);

            return Result<Auth>.Success(auth);
        }

        public async Task DeleteAsync(long id)
        {
            await _authRepository.DeleteAsync(id);
        }

        public async Task<IResult<TokenModel>> SignInAsync(SignInModel model)
        {
            var failResult = Result<TokenModel>.Fail("Invalid login or password!");

            var validation = await new SignInModelValidator().ValidateAsync(model);

            if (validation.Failed)
            {
                return failResult;
            }

            var auth = await _authRepository.GetByLoginAsync(model.Login);

            if (auth == default)
            {
                return failResult;
            }

            var password = _hashService.Create(model.Password, auth.Salt);

            if (auth.Password != password)
            {
                return failResult;
            }

            return CreateToken(auth);
        }

        private IResult<TokenModel> CreateToken(Auth auth)
        {
            var claims = new List<Claim>();

            claims.AddSub(auth.Id.ToString());

            claims.AddRoles(auth.Roles.ToArray());

            var token = _jsonWebTokenService.Encode(claims);

            var tokenModel = new TokenModel(token);

            return Result<TokenModel>.Success(tokenModel);
        }
    }
}

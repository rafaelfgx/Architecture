using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Extensions;
using DotNetCore.Results;
using DotNetCore.Security;
using DotNetCore.Validation;
using System.Security.Claims;

namespace Architecture.Application;

public sealed class AuthService : IAuthService
{
    private readonly IAuthFactory _authFactory;
    private readonly IAuthRepository _authRepository;
    private readonly IHashService _hashService;
    private readonly IJwtService _jwtService;

    public AuthService
    (
        IAuthFactory authFactory,
        IAuthRepository authRepository,
        IHashService hashService,
        IJwtService jwtService
    )
    {
        _authFactory = authFactory;
        _authRepository = authRepository;
        _hashService = hashService;
        _jwtService = jwtService;
    }

    public async Task<Result<Auth>> AddAsync(AuthModel model)
    {
        var validationResult = new AuthModelValidator().Validation(model);

        if (validationResult.IsError) return Result<Auth>.Error(validationResult.Message);

        if (await _authRepository.AnyByLoginAsync(model.Login)) return Result<Auth>.Error("Login exists!");

        var auth = _authFactory.Create(model);

        var password = _hashService.Create(auth.Password, auth.Salt);

        auth.UpdatePassword(password);

        await _authRepository.AddAsync(auth);

        return Result<Auth>.Success(auth);
    }

    public async Task DeleteAsync(long id)
    {
        await _authRepository.DeleteAsync(id);
    }

    public async Task<Result<TokenModel>> SignInAsync(SignInModel model)
    {
        var errorResult = Result<TokenModel>.Error("Invalid login or password!");

        var validationResult = new SignInModelValidator().Validation(model);

        if (validationResult.IsError) return errorResult;

        var auth = await _authRepository.GetByLoginAsync(model.Login);

        if (auth is null) return errorResult;

        var password = _hashService.Create(model.Password, auth.Salt);

        if (auth.Password != password) return errorResult;

        return CreateToken(auth);
    }

    private Result<TokenModel> CreateToken(Auth auth)
    {
        var claims = new List<Claim>();

        claims.AddSub(auth.Id.ToString());

        claims.AddRoles(auth.Roles.ToArray());

        var token = _jwtService.Encode(claims);

        return Result<TokenModel>.Success(new TokenModel(token));
    }
}

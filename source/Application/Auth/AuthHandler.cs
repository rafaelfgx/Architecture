using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record AuthHandler
(
    IAuthRepository authRepository,
    IHashService hashService,
    IJwtService jwtService,
    IStringLocalizer stringLocalizer
)
: IHandler<AuthRequest, AuthResponse>
{
    public async Task<Result<AuthResponse>> HandleAsync(AuthRequest request)
    {
        var unauthorizedResult = new Result<AuthResponse>(Unauthorized, stringLocalizer[nameof(Unauthorized)]);

        var auth = await authRepository.GetByLoginAsync(request.Login);

        if (auth is null) return unauthorizedResult;

        if (!hashService.Validate(auth.Password, request.Password, auth.Salt.ToString())) return unauthorizedResult;

        var token = jwtService.Encode(auth.Id.ToString(), auth.Roles.ToArray());

        var response = new AuthResponse(token);

        return new Result<AuthResponse>(OK, response);
    }
}

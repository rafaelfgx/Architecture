using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class AuthHandler(
    IAuthRepository authRepository,
    IHashService hashService,
    IJwtService jwtService,
    IStringLocalizer stringLocalizer
    ) : IHandler<AuthRequest, AuthResponse>
{
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly IHashService _hashService = hashService;
    private readonly IJwtService _jwtService = jwtService;
    private readonly IStringLocalizer _stringLocalizer = stringLocalizer;

    public async Task<Result<AuthResponse>> HandleAsync(AuthRequest request)
    {
        var unauthorizedResult = new Result<AuthResponse>(Unauthorized, _stringLocalizer[nameof(Unauthorized)]);

        var auth = await _authRepository.GetByLoginAsync(request.Login);

        if (auth is null) return unauthorizedResult;

        if (!_hashService.Validate(auth.Password, request.Password, auth.Salt.ToString())) return unauthorizedResult;

        var token = _jwtService.Encode(auth.Id.ToString(), auth.Roles.ToArray());

        var response = new AuthResponse(token);

        return new Result<AuthResponse>(OK, response);
    }
}

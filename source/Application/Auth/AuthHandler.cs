namespace Architecture.Application;

public sealed record AuthHandler
(
    IConfiguration configuration,
    IAuthRepository authRepository,
    IHashService hashService,
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

        var response = new AuthResponse(Token(auth));

        return new Result<AuthResponse>(OK, response);
    }

    private string Token(Auth auth)
    {
        var claims = new List<Claim> { new("sub", auth.Id.ToString()) };

        claims.AddRange(auth.Roles.ToArray().Select(role => new Claim("role", role)));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SigningKey"]));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken("", "", claims, DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromDays(1)), signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

namespace Architecture.Application;

public sealed class AuthHandler(IConfiguration configuration, IAuthRepository authRepository, IHashService hashService, IStringLocalizer stringLocalizer) : IHandler<AuthRequest, AuthResponse>
{
    public async Task<Result<AuthResponse>> HandleAsync(AuthRequest request)
    {
        var auth = await authRepository.GetByLoginAsync(request.Login);

        return auth is null || !hashService.Validate(request.Password, auth.Salt.ToString(), auth.Password)
            ? new(Unauthorized, stringLocalizer[nameof(Unauthorized)])
            : new(OK, new AuthResponse(CreateToken(auth)));
    }

    private string CreateToken(Auth auth)
    {
        List<Claim> claims = [new("sub", auth.Id.ToString()), .. auth.Roles.ToArray().Select(role => new Claim("role", role))];

        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SigningKey"])), SecurityAlgorithms.HmacSha256);

        return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken("", "", claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(1), credentials));
    }
}

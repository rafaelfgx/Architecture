namespace Architecture.Model;

public sealed record UserModel
{
    public long Id { get; init; }

    public string Name { get; init; }

    public string Email { get; init; }
}

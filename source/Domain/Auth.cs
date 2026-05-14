namespace Architecture.Domain;

public sealed class Auth : Entity
{
    public Auth
    (
        string login,
        string password,
        User user
    )
    {
        Login = login;
        Password = password;
        User = user;
    }

    public Auth() { }

    public string Login { get; }

    public string Password { get; private set; }

    public Guid Salt { get; } = Guid.NewGuid();

    public Roles Roles { get; } = Roles.User;

    public User User { get; }

    public void UpdatePassword(string password) => Password = password;
}

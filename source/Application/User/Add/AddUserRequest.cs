namespace Architecture.Application;

public sealed record AddUserRequest(string Name, string Email, string Login, string Password);

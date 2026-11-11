namespace Architecture.Application;

public sealed record UpdateUserRequest([property: JsonIgnore] long Id, string Name, string Email);

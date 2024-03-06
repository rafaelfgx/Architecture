using System.Text.Json.Serialization;

namespace Architecture.Application;

public sealed record UpdateUserRequest(string Name, string Email)
{
    [JsonIgnore]
    public long Id { get; set; }
}

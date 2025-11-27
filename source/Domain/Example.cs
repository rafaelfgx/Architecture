namespace Architecture.Domain;

public sealed class Example(string name) : Entity
{
    public Example(long id, string name) : this(name) => Id = id;

    public string Name { get; } = name;
}

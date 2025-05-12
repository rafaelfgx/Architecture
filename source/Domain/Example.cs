namespace Architecture.Domain;

public sealed class Example : Entity
{
    public Example(long id, string name) : this(name) => Id = id;

    public Example(string name) => Name = name;

    public string Name { get; }
}

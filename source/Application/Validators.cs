namespace Architecture.Application;

public static class Validators
{
    public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().EmailAddress();

    public static IRuleBuilderOptions<T, IEnumerable<BinaryFile>> Files<T>(this IRuleBuilder<T, IEnumerable<BinaryFile>> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, GridParameters> Grid<T>(this IRuleBuilder<T, GridParameters> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, Guid> Guid<T>(this IRuleBuilder<T, Guid> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, long> Id<T>(this IRuleBuilder<T, long> builder) => builder.NotEmpty().GreaterThan(0);

    public static IRuleBuilderOptions<T, string> Login<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, string> Name<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().MinimumLength(3);

    public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();
}

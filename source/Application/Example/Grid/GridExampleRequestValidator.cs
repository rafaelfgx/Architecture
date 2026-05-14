namespace Architecture.Application;

public sealed class GridExampleRequestValidator : AbstractValidator<GridExampleRequest>
{
    public GridExampleRequestValidator() => RuleFor(request => request).Grid();
}

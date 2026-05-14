namespace Architecture.Application;

public sealed class AddExampleRequestValidator : AbstractValidator<AddExampleRequest>
{
    public AddExampleRequestValidator() => RuleFor(request => request.Name).Name();
}

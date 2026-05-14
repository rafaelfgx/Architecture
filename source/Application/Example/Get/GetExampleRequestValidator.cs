namespace Architecture.Application;

public sealed class GetExampleRequestValidator : AbstractValidator<GetExampleRequest>
{
    public GetExampleRequestValidator() => RuleFor(request => request.Id).Id();
}

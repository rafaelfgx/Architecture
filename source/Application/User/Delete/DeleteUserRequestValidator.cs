namespace Architecture.Application;

public sealed class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator() => RuleFor(request => request.Id).Id();
}

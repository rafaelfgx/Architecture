namespace Architecture.Application;

public sealed class DeleteExampleHandler
(
    IExampleRepository exampleRepository,
    IUnitOfWork unitOfWork
)
: IHandler<DeleteExampleRequest>
{
    public async Task<Result> HandleAsync(DeleteExampleRequest request)
    {
        await exampleRepository.DeleteAsync(request.Id);

        await unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}

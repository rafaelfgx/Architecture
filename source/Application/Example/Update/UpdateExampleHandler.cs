namespace Architecture.Application;

public sealed class UpdateExampleHandler
(
    IExampleRepository exampleRepository,
    IUnitOfWork unitOfWork
)
: IHandler<UpdateExampleRequest>
{
    public async Task<Result> HandleAsync(UpdateExampleRequest request)
    {
        var entity = new Example(request.Id, request.Name);

        await exampleRepository.UpdateAsync(entity);

        await unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}

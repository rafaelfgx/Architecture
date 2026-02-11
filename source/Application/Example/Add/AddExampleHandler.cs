namespace Architecture.Application;

public sealed class AddExampleHandler
(
    IExampleRepository exampleRepository,
    IUnitOfWork unitOfWork
)
: IHandler<AddExampleRequest, long>
{
    public async Task<Result<long>> HandleAsync(AddExampleRequest request)
    {
        var entity = new Example(request.Name);

        await exampleRepository.AddAsync(entity);

        await unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, entity.Id);
    }
}

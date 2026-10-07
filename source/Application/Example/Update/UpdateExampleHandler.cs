namespace Architecture.Application;

public sealed class UpdateExampleHandler(IExampleRepository exampleRepository, IUnitOfWork unitOfWork) : IHandler<UpdateExampleRequest>
{
    public async Task<Result> HandleAsync(UpdateExampleRequest request)
    {
        await exampleRepository.UpdateAsync(new(request.Id, request.Name));

        await unitOfWork.SaveChangesAsync();

        return new(NoContent);
    }
}

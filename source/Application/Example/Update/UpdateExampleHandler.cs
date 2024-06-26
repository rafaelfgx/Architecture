using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class UpdateExampleHandler(
    IExampleRepository exampleRepository,
    IUnitOfWork unitOfWork
    ) : IHandler<UpdateExampleRequest>
{
    private readonly IExampleRepository _exampleRepository = exampleRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> HandleAsync(UpdateExampleRequest request)
    {
        var entity = new Example(request.Id, request.Name);

        await _exampleRepository.UpdateAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}

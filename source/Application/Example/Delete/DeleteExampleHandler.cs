using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class DeleteExampleHandler(
    IExampleRepository exampleRepository,
    IUnitOfWork unitOfWork
    ) : IHandler<DeleteExampleRequest>
{
    private readonly IExampleRepository _exampleRepository = exampleRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> HandleAsync(DeleteExampleRequest request)
    {
        await _exampleRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}

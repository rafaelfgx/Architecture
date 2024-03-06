using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record DeleteExampleHandler : IHandler<DeleteExampleRequest>
{
    private readonly IExampleRepository _exampleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteExampleHandler
    (
        IExampleRepository exampleRepository,
        IUnitOfWork unitOfWork
    )
    {
        _exampleRepository = exampleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(DeleteExampleRequest request)
    {
        await _exampleRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}

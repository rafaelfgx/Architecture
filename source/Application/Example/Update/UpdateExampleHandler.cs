using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record UpdateExampleHandler : IHandler<UpdateExampleRequest>
{
    private readonly IExampleRepository _exampleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExampleHandler
    (
        IExampleRepository exampleRepository,
        IUnitOfWork unitOfWork
    )
    {
        _exampleRepository = exampleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(UpdateExampleRequest request)
    {
        var entity = new Example(request.Id, request.Name);

        await _exampleRepository.UpdateAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}

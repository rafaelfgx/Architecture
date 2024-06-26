using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class GridUserHandler(IUserRepository userRepository) : IHandler<GridUserRequest, Grid<UserModel>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<Grid<UserModel>>> HandleAsync(GridUserRequest request)
    {
        var grid = await _userRepository.GridAsync(request);

        return new Result<Grid<UserModel>>(grid is null ? NotFound : OK, grid);
    }
}

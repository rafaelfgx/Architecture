namespace Architecture.Application;

public sealed record GridUserHandler(IUserRepository userRepository) : IHandler<GridUserRequest, Grid<UserModel>>
{
    public async Task<Result<Grid<UserModel>>> HandleAsync(GridUserRequest request)
    {
        var grid = await userRepository.GridAsync(request);

        return new Result<Grid<UserModel>>(grid is null ? NotFound : OK, grid);
    }
}

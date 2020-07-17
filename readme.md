# Architecture

![](https://dev.azure.com/rafaelfgx/Architecture/_apis/build/status/Build)
![](https://app.codacy.com/project/badge/Grade/3d1ea5b1f4b745488384c744cb00d51e)
![](https://img.shields.io/github/repo-size/rafaelfgx/Architecture?label=Size)

This project is an example of architecture using new technologies and best practices.

The goal is to share knowledge and use it as reference for new projects.

Thanks for enjoying!

## Technologies

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core)
* [Entity Framework Core 3.1](https://docs.microsoft.com/en-us/ef/core)
* [C# 8.0](https://docs.microsoft.com/en-us/dotnet/csharp)
* [Angular 10](https://angular.io/docs)
* [UIkit](https://getuikit.com/docs/introduction)
* [Docker](https://docs.docker.com)
* [Azure DevOps](https://dev.azure.com)

## Practices

* Clean Code
* SOLID Principles
* DDD (Domain-Driven Design)
* Separation of Concerns
* DevOps
* Code Analysis

## Run

<details>
<summary>Command Line</summary>

#### Prerequisites

* [.NET Core SDK](https://aka.ms/dotnet-download)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm run restore**.
2. Open directory **source\Web** in command line and execute **dotnet run**.
3. Open <https://localhost:8090>.

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

* [.NET Core SDK](https://aka.ms/dotnet-download)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Visual Studio Code](https://code.visualstudio.com)
* [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm run restore**.
2. Open **source** directory in Visual Studio Code.
3. Press **F5**.

</details>

<details>
<summary>Visual Studio</summary>

#### Prerequisites

* [Visual Studio](https://visualstudio.microsoft.com)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm run restore**.
2. Open **source\Architecture.sln** in Visual Studio.
3. Set **Architecture.Web** as startup project.
4. Press **F5**.

</details>

<details>
<summary>Docker</summary>

#### Prerequisites

* [Docker](https://www.docker.com/get-started)

#### Steps

1. Execute **docker-compose up --build -d** in root directory.
2. Open <http://localhost:8090>.

</details>

## Utils

<details>
<summary>Books</summary>

* **Clean Code: A Handbook of Agile Software Craftsmanship** - Robert C. Martin (Uncle Bob)
* **Clean Architecture: A Craftsman's Guide to Software Structure and Design** - Robert C. Martin (Uncle Bob)
* **Implementing Domain-Driven Design** - Vaughn Vernon
* **Domain-Driven Design Distilled** - Vaughn Vernon
* **Domain-Driven Design: Tackling Complexity in the Heart of Software** - Eric Evans
* **Domain-Driven Design Reference: Definitions and Pattern Summaries** - Eric Evans

</details>

<details>
<summary>Tools</summary>

* [Visual Studio](https://visualstudio.microsoft.com)
* [Visual Studio Code](https://code.visualstudio.com)
* [SQL Server](https://www.microsoft.com/sql-server)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)
* [Postman](https://www.getpostman.com)
* [Codacy](https://codacy.com)
* [StackBlitz](https://stackblitz.com)

</details>

<details>
<summary>Visual Studio Extensions</summary>

* [CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)
* [ReSharper](https://www.jetbrains.com/resharper)

</details>

<details>
<summary>Visual Studio Code Extensions</summary>

* [Angular Language Service](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template)
* [Angular Snippets](https://marketplace.visualstudio.com/items?itemName=johnpapa.Angular2)
* [Atom One Dark Theme](https://marketplace.visualstudio.com/items?itemName=akamud.vscode-theme-onedark)
* [Bracket Pair Colorizer](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer)
* [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Debugger for Chrome](https://marketplace.visualstudio.com/items?itemName=msjsdiag.debugger-for-chrome)
* [Material Icon Theme](https://marketplace.visualstudio.com/items?itemName=PKief.material-icon-theme)
* [Sort Lines](https://marketplace.visualstudio.com/items?itemName=Tyriar.sort-lines)
* [TSLint](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin)
* [Visual Studio Keymap](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vs-keybindings)

</details>

## Nuget Packages

**Source:** [https://github.com/rafaelfgx/DotNetCore](https://github.com/rafaelfgx/DotNetCore)

**Published:** [https://www.nuget.org/profiles/rafaelfgx](https://www.nuget.org/profiles/rafaelfgx)

## Layers

**Web:** API and Frontend (Angular).

**Application:** Flow control.

**Domain:** Business rules and domain logic.

**Model:** Data transfer objects.

**Database:** Database persistence.

## Web

### Angular

### Component

```html
<form [formGroup]="form">
    <fieldset class="uk-fieldset">
        <div class="uk-margin">
            <app-label for="login" text="Login"></app-label>
            <app-input-text formControlName="login" text="Login" [autofocus]="true"></app-input-text>
        </div>
        <div class="uk-margin">
            <app-label for="password" text="Password"></app-label>
            <app-input-password formControlName="password" text="Password"></app-input-password>
        </div>
        <div class="uk-margin uk-text-center">
            <app-button text="Sign in" [disabled]="form.invalid" (click)="signin()"></app-button>
        </div>
    </fieldset>
</form>
```

```typescript
@Component({ selector: "app-signin", templateUrl: "./signin.component.html" })
export class AppSigninComponent {
    form = this.formBuilder.group({
        login: ["", Validators.required],
        password: ["", Validators.required]
    });

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly appAuthService: AppAuthService) {
    }

    signin() {
        this.appAuthService.signin(this.form.value);
    }
}
```

### Model

```typescript
export class SignInModel {
    login!: string;
    password!: string;
}
```

### Service

```typescript
@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly gridService: GridService) { }

    add(model: UserModel) {
        return this.http.post<number>("users", model);
    }

    delete(id: number) {
        return this.http.delete(`users/${id}`);
    }

    get(id: number) {
        return this.http.get<UserModel>(`users/${id}`);
    }

    grid(parameters: GridParametersModel) {
        return this.gridService.get<UserModel>("users/grid", parameters);
    }

    list() {
        return this.http.get<UserModel[]>("users");
    }

    update(model: UserModel) {
        return this.http.put(`users/${model.id}`, model);
    }
}
```

### Guard

```typescript
@Injectable({ providedIn: "root" })
export class AppRouteGuard implements CanActivate {
    constructor(
        private readonly router: Router,
        private readonly appStorageService: AppStorageService) { }

    canActivate() {
        if (this.appStorageService.any("token")) { return true; }
        this.router.navigate(["/login"]);
        return false;
    }
}
```

### ErrorHandler

```typescript
@Injectable({ providedIn: "root" })
export class AppErrorHandler implements ErrorHandler {
    constructor(private readonly injector: Injector) { }

    handleError(error: any) {
        if (error instanceof HttpErrorResponse) {
            switch (error.status) {
                case 401: {
                    const router = this.injector.get<Router>(Router);
                    router.navigate(["/login"]);
                    return;
                }
                case 422: {
                    const appModalService = this.injector.get<AppModalService>(AppModalService);
                    appModalService.alert(error.error);
                    return;
                }
            }
        }

        console.error(error);
    }
}
```

### HttpInterceptor

```typescript
@Injectable({ providedIn: "root" })
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private readonly appStorageService: AppStorageService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler) {
        const token = this.appStorageService.get("token");

        request = request.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
        });

        return next.handle(request);
    }
}
```
### ASP.NET Core

### Startup

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder application)
    {
        application.UseException();
        application.UseHttps();
        application.UseRouting();
        application.UseStaticFiles();
        application.UseResponseCompression();
        application.UseAuthentication();
        application.UseAuthorization();
        application.UseEndpoints();
        application.UseSpa();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSecurity();
        services.AddResponseCompression();
        services.AddControllersDefault();
        services.AddSpa();
        services.AddContext();
        services.AddServices();
    }
}
```

### Controller

```csharp
[ApiController]
[Route("Users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public Task<IActionResult> AddAsync(UserModel model)
    {
        return _userService.AddAsync(model).ResultAsync();
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteAsync(long id)
    {
        return _userService.DeleteAsync(id).ResultAsync();
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetAsync(long id)
    {
        return _userService.GetAsync(id).ResultAsync();
    }

    [HttpPatch("{id}/inactivate")]
    public Task InactivateAsync(long id)
    {
        return _userService.InactivateAsync(id);
    }

    [HttpGet("grid")]
    public Task<IActionResult> GridAsync([FromQuery]GridParameters parameters)
    {
        return _userService.GridAsync(parameters).ResultAsync();
    }

    [HttpGet]
    public Task<IActionResult> ListAsync()
    {
        return _userService.ListAsync().ResultAsync();
    }

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateAsync(UserModel model)
    {
        return _userService.UpdateAsync(model).ResultAsync();
    }
}
```

## Application

### Service

```csharp
public sealed class UserService : IUserService
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserService
    (
        IAuthService authService,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
    )
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IResult<long>> AddAsync(UserModel model)
    {
        var validation = await new AddUserModelValidator().ValidateAsync(model);

        if (validation.Failed)
        {
            return Result<long>.Fail(validation.Message);
        }

        var authResult = await _authService.AddAsync(model.Auth);

        if (authResult.Failed)
        {
            return Result<long>.Fail(authResult.Message);
        }

        var user = UserFactory.Create(model, authResult.Data);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result<long>.Success(user.Id);
    }

    public async Task<IResult> DeleteAsync(long id)
    {
        var authId = await _userRepository.GetAuthIdByUserIdAsync(id);

        await _userRepository.DeleteAsync(id);

        await _authService.DeleteAsync(authId);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public Task<UserModel> GetAsync(long id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
    {
        return _userRepository.Queryable.Select(UserExpression.Model).GridAsync(parameters);
    }

    public async Task InactivateAsync(long id)
    {
        var user = new User(id);

        user.Inactivate();

        await _userRepository.UpdateStatusAsync(user);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserModel>> ListAsync()
    {
        return await _userRepository.Queryable.Select(UserExpression.Model).ToListAsync();
    }

    public async Task<IResult> UpdateAsync(UserModel model)
    {
        var validation = await new UpdateUserModelValidator().ValidateAsync(model);

        if (validation.Failed)
        {
            return Result.Fail(validation.Message);
        }

        var user = await _userRepository.GetAsync(model.Id);

        if (user == default)
        {
            return Result.Success();
        }

        user.UpdateFullName(model.Name, model.Surname);

        user.UpdateEmail(model.Email);

        await _userRepository.UpdateAsync(user.Id, user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
```

### Factory

```csharp
public static class UserFactory
{
    public static User Create(UserModel model, Auth auth)
    {
        return new User
        (
            new FullName(model.Name, model.Surname),
            new Email(model.Email),
            auth
        );
    }
}
```

## Domain

### Entity

```csharp
public class User : Entity<long>
{
    public User
    (
        FullName fullName,
        Email email,
        Auth auth
    )
    {
        FullName = fullName;
        Email = email;
        Auth = auth;
        Activate();
    }

    public User(long id) : base(id) { }

    public FullName FullName { get; private set; }

    public Email Email { get; private set; }

    public Status Status { get; private set; }

    public Auth Auth { get; private set; }

    public void Activate()
    {
        Status = Status.Active;
    }

    public void Inactivate()
    {
        Status = Status.Inactive;
    }

    public void UpdateFullName(string name, string surname)
    {
        FullName = new FullName(name, surname);
    }

    public void UpdateEmail(string email)
    {
        Email = new Email(email);
    }
}
```

### ValueObject

```csharp
public sealed class FullName : ValueObject
{
    public FullName(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; }

    public string Surname { get; }

    protected override IEnumerable<object> Equals()
    {
        yield return Name;
        yield return Surname;
    }
}
```

## Model

### Model

```csharp
public class SignInModel
{
    public string Login { get; set; }

    public string Password { get; set; }
}
```

### ModelValidator

```csharp
public sealed class SignInModelValidator : Validator<SignInModel>
{
    public SignInModelValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
```

## Database

### Context

```csharp
public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        builder.Seed();
    }
}
```

### Configuration

```csharp
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Status).IsRequired();

        builder.OwnsOne(x => x.FullName, y =>
        {
            y.Property(x => x.Name).HasColumnName(nameof(FullName.Name)).HasMaxLength(100).IsRequired();
            y.Property(x => x.Surname).HasColumnName(nameof(FullName.Surname)).HasMaxLength(200).IsRequired();
        });

        builder.OwnsOne(x => x.Email, y =>
        {
            y.Property(x => x.Value).HasColumnName(nameof(User.Email)).HasMaxLength(300).IsRequired();
            y.HasIndex(x => x.Value).IsUnique();
        });

        builder.HasOne(x => x.Auth);
    }
}
```

### Repository

```csharp
public sealed class UserRepository : EFRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) { }

    public Task<long> GetAuthIdByUserIdAsync(long id)
    {
        return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.AuthId).SingleOrDefaultAsync();
    }

    public Task<UserModel> GetByIdAsync(long id)
    {
        return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.Model).SingleOrDefaultAsync();
    }

    public Task UpdateStatusAsync(User user)
    {
        return UpdatePartialAsync(user.Id, new { user.Status });
    }
}
```

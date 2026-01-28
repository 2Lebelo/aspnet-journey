# ASP.NET Quick Start Guide

## Introduction to ASP.NET Core

ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications.

## Project Types

### 1. Web API
RESTful HTTP services that can be consumed by various clients.
```bash
dotnet new webapi -n MyApi
```

### 2. MVC (Model-View-Controller)
Web applications with a clear separation of concerns.
```bash
dotnet new mvc -n MyMvcApp
```

### 3. Razor Pages
Page-focused framework for building web UI.
```bash
dotnet new webapp -n MyWebApp
```

### 4. Blazor
Build interactive web UIs using C# instead of JavaScript.
```bash
dotnet new blazorserver -n MyBlazorApp  # Server-side
dotnet new blazorwasm -n MyBlazorApp    # Client-side
```

### 5. gRPC
High-performance RPC framework.
```bash
dotnet new grpc -n MyGrpcService
```

## Common Commands

### Project Management
```bash
# Create a new solution
dotnet new sln -n MySolution

# Add project to solution
dotnet sln add ./MyProject/MyProject.csproj

# Restore dependencies
dotnet restore

# Build project
dotnet build

# Run project
dotnet run

# Watch for changes and auto-rebuild
dotnet watch run
```

### Package Management
```bash
# Add a NuGet package
dotnet add package PackageName

# Remove a NuGet package
dotnet remove package PackageName

# List packages
dotnet list package
```

### Testing
```bash
# Create test project
dotnet new xunit -n MyProject.Tests

# Run tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Project Structure

Typical ASP.NET Core project structure:
```
MyProject/
├── Program.cs              # Application entry point
├── appsettings.json        # Configuration
├── appsettings.Development.json
├── Controllers/            # API/MVC controllers
├── Models/                 # Data models
├── Views/                  # MVC views (if MVC)
├── wwwroot/               # Static files
│   ├── css/
│   ├── js/
│   └── images/
├── Services/              # Business logic
└── MyProject.csproj       # Project file
```

## Essential Concepts

### 1. Dependency Injection
ASP.NET Core has built-in DI support.
```csharp
// Register in Program.cs
builder.Services.AddScoped<IMyService, MyService>();

// Inject in controller
public class MyController : ControllerBase
{
    private readonly IMyService _myService;
    
    public MyController(IMyService myService)
    {
        _myService = myService;
    }
}
```

### 2. Middleware Pipeline
Request processing pipeline configuration.
```csharp
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### 3. Configuration
Access configuration from appsettings.json.
```csharp
// In appsettings.json
{
  "MySettings": {
    "ApiKey": "value"
  }
}

// In code
var apiKey = builder.Configuration["MySettings:ApiKey"];
```

### 4. Routing
Define routes for your endpoints.
```csharp
// Attribute routing
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok();
}
```

## Best Practices

1. **Use async/await** for I/O operations
2. **Implement proper error handling**
3. **Use configuration for environment-specific settings**
4. **Follow REST conventions** for APIs
5. **Use dependency injection** for loose coupling
6. **Write unit tests** for business logic
7. **Secure sensitive data** (use User Secrets in development)
8. **Log appropriately** using ILogger

## Useful Resources

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [ASP.NET Core Tutorials](https://dotnet.microsoft.com/learn/aspnet)

## Next Steps

1. Choose a project type to start with
2. Create your first project
3. Explore the generated code
4. Make small modifications
5. Build and run
6. Document what you learned

Happy coding! 🚀

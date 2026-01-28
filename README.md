# BlazorMovieApp

A full-stack **ASP.NET Core Blazor** web application demonstrating CRUD (Create, Read, Update, Delete) operations for managing a movie database. This project showcases modern Blazor Server-side rendering with Entity Framework Core and SQL Server integration.

## 🎯 Project Overview

BlazorMovieApp is a learning-focused application built to explore and demonstrate ASP.NET Core Blazor frontend concepts, including interactive server-side components, data binding, form validation, and database operations using Entity Framework Core.

## 🚀 Features

- **Full CRUD Operations**: Create, read, update, and delete movie records
- **Interactive Server Rendering**: Real-time UI updates using Blazor Server's `@rendermode InteractiveServer`
- **Paginated Data Grid**: Movie listing with QuickGrid component featuring sorting and pagination
- **Form Validation**: Client-side validation using Data Annotations
- **Responsive UI**: Bootstrap-based responsive design
- **Database Integration**: Entity Framework Core with SQL Server
- **Navigation Management**: Built-in routing with parameterized navigation
- **Error Handling**: Custom 404 handling with `NotFound()` navigation extension

## 🛠️ Technology Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| **.NET** | 10.0 | Runtime framework |
| **ASP.NET Core Blazor** | 10.0 | Frontend framework |
| **Entity Framework Core** | 10.0.2 | ORM for database operations |
| **SQL Server** | - | Relational database |
| **Bootstrap** | - | CSS framework for responsive UI |
| **QuickGrid** | 10.0.2 | Data grid component with sorting/pagination |

## 📦 NuGet Dependencies

```xml
<PackageReference Include="Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter" Version="10.0.2" />
<PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.2" />
<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="10.0.2" />
```

## 📋 Prerequisites

Before running this application, ensure you have the following installed:

- **.NET 10.0 SDK** or later - [Download](https://dotnet.microsoft.com/download/dotnet/10.0)
- **SQL Server** (LocalDB, Express, or Full) - [Download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Visual Studio 2022** (recommended) or **Visual Studio Code** with C# extension
- **Git** for version control

## 🚦 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/2Lebelo/BlazorMovieApp.git
cd BlazorMovieApp
```

### 2. Configure Database Connection

Update the connection string in `appsettings.json` if needed:

```json
{
  "ConnectionStrings": {
    "BlazorMovieAppContext": "Server=(localdb)\\mssqllocaldb;Database=BlazorMovieAppContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Apply Database Migrations

Run the following commands to create the database schema:

```bash
cd BlazorMovieApp
dotnet ef database update
```

Or using Package Manager Console in Visual Studio:

```powershell
Update-Database
```

### 4. Run the Application

```bash
dotnet run
```

The application will start and be accessible at:
- **HTTPS**: `https://localhost:5001`
- **HTTP**: `http://localhost:5000`

## 📖 Usage

### Managing Movies

1. **View All Movies**: Navigate to `/movies` to see the paginated list of all movies
2. **Create New Movie**: Click "Create New" to add a movie with title, release date, genre, and price
3. **Edit Movie**: Click "Edit" next to any movie to modify its details
4. **View Details**: Click "Details" to see full movie information
5. **Delete Movie**: Click "Delete" to remove a movie from the database

### Movie Properties

Each movie record contains:
- **Title** (required): The name of the movie
- **Release Date**: When the movie was released
- **Genre**: The movie category (e.g., Action, Comedy, Drama)
- **Price**: Movie price (must be between 1-100)

## 📂 Project Structure

```
BlazorMovieApp/
├── Components/
│   ├── Layout/           # Layout components
│   ├── Pages/            # Razor pages
│   │   ├── MoviesPages/  # CRUD pages for movies
│   │   │   ├── Index.razor    # List all movies
│   │   │   ├── Create.razor   # Create new movie
│   │   │   ├── Edit.razor     # Edit existing movie
│   │   │   ├── Details.razor  # View movie details
│   │   │   └── Delete.razor   # Delete movie
│   │   ├── Counter.razor
│   │   ├── Home.razor
│   │   ├── Weather.razor
│   │   ├── Error.razor
│   │   └── NotFound.razor
│   ├── App.razor
│   ├── Routes.razor
│   └── _Imports.razor
├── Data/
│   └── BlazorMovieAppContext.cs  # EF Core DbContext
├── Migrations/                    # Database migrations
├── Properties/
├── wwwroot/                       # Static files
├── Movie.cs                       # Movie entity model
├── Program.cs                     # App entry point & configuration
├── appsettings.json
└── appsettings.Development.json
```

## 🔧 Configuration

### Database Context

The application uses Entity Framework Core with a `DbContextFactory` pattern for Blazor Server applications:

```csharp
builder.Services.AddDbContextFactory<BlazorMovieAppContext>(options =>
    options.UseSqlServer(connectionString));
```

### Interactive Server Components

Blazor components are configured with Interactive Server rendering mode:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

### QuickGrid Configuration

The QuickGrid component is configured with Entity Framework adapter for efficient data operations:

```csharp
builder.Services.AddQuickGridEntityFrameworkAdapter();
```

## 🎨 Key Implementation Details

### Movie Model with Data Annotations

```csharp
public class Movies
{
    public int Id { get; set; }
    
    [Required]
    public string? Title { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime? ReleaseDate { get; set; }
    
    public string? Genre { get; set; }
    
    [Range(1, 100)]
    public decimal Price { get; set; }
}
```

### QuickGrid with Pagination

The Index page demonstrates QuickGrid usage with sorting and pagination:

```razor
<QuickGrid Class="table" Items="context.Movies" Pagination="state">
    <PropertyColumn Property="movies => movies.Title" Sortable="true"/>
    <PropertyColumn Property="movies => movies.ReleaseDate" Format="MM/dd/yyyy"/>
    <!-- Additional columns -->
</QuickGrid>
<Paginator State="state"/>
```

## 🧪 Development

### Adding a New Migration

When you modify the `Movies` model, create a new migration:

```bash
dotnet ef migrations add YourMigrationName
dotnet ef database update
```

### Building the Project

```bash
dotnet build
```

### Cleaning Build Artifacts

```bash
dotnet clean
```

## 📚 Learning Resources

This project demonstrates concepts from:
- [ASP.NET Core Blazor Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [QuickGrid for Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/quickgrid)
- [Blazor Forms and Validation](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License

This project is open source and available for educational purposes.

## 👤 Author

**2Lebelo**

- GitHub: [@2Lebelo](https://github.com/2Lebelo)

## 🙏 Acknowledgments

- Built following Microsoft's official Blazor tutorials and best practices
- Uses ASP.NET Core Blazor framework components and templates
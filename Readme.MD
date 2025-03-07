# AmolShirkeCrudOperationsAPI

This project is an ASP.NET Core API demonstrating CRUD operations on a Student database using Entity Framework Core. The repository includes features such as dependency injection, automatic migration application on startup, and guidance on handling common issues like cascade delete conflicts and SQL Server connection problems.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Setup and Configuration](#setup-and-configuration)
- [Dependency Injection](#dependency-injection)
- [Database Migrations](#database-migrations)
- [Automatic Migration Application](#automatic-migration-application)
- [Handling Cascade Delete Issues](#handling-cascade-delete-issues)
- [Troubleshooting Common Issues](#troubleshooting-common-issues)
- [Running the Application](#running-the-application)

## Prerequisites
- [.NET 6 (or later)](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (or LocalDB for development)
- EF Core Tools installed (via CLI or Visual Studio)
- IDE such as Visual Studio or VS Code

## Setup and Configuration

### 1. Clone the Repository
```bash
git clone <repository_url>
cd AmolShirkeCrudOperationsAPI
```

## Dependency Injection

### Configure EF Core with SQL Server and enable transient error resiliency

```bash

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDbConnectionString"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

```

### Register the repository interface and implementation
```bash

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

```

### Automatically apply pending migrations at startup.

```bash
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}
```

### Controller Constructor Update

```bash
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    // Controller methods...
}
```

## Database Migrations

### Install EF Core Tools
```bash
Install-Package Microsoft.EntityFrameworkCore.Tools
```

### Creating a Migration
```bash
Add-Migration <Your Migration Name>
```

### Applying the Migration (Optional as we are running migrations from code)
```bash
Update-Database
```

## Handling Cascade Delete Issues

SQL Server may report errors such as:

```bash
Introducing FOREIGN KEY constraint 'FK_Students_Countries_CountryId' on table 'Students' may cause cycles or multiple cascade paths.

```

To resolve this, configure the cascade delete behavior using Fluent API in your DbContext�s OnModelCreating method

```bash
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Disable cascade delete for relationships that could create multiple cascade paths.
    modelBuilder.Entity<Student>()
                .HasOne(s => s.Country)
                .WithMany() // or .WithMany(c => c.Students) if you have a navigation property.
                .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Student>()
                .HasOne(s => s.State)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Student>()
                .HasOne(s => s.City)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
}

```

## Troubleshooting Common Issues

- SQL Server Login Failed:
``Ensure that the target database exists and that the login (or Windows Authentication) has the proper permissions.``

- Certificate Errors:
``Use TrustServerCertificate=True in your connection string for development environments.``

- Transient Connection Failures:
``Enable retry policies with EnableRetryOnFailure() in your SQL Server configuration.``

- Migrations Not Recognized:
``Verify that EF Core Tools are installed and that your default project is set correctly in the Package Manager Console.``
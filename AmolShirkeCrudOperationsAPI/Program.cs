using AmolShirkeCrudOperationsAPI.Context;
using AmolShirkeCrudOperationsAPI.Repositories.CountryRepository;
using AmolShirkeCrudOperationsAPI.Repositories.StudentRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDbConnectionString"),
    sqlOption=>sqlOption.EnableRetryOnFailure())
    
);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

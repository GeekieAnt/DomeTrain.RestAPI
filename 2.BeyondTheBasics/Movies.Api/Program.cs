using Movies.Api.Mapping;
using Movies.Application;
using Movies.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(config.GetConnectionString("MoviesDbContext")!);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<ValidationMappingMiddleware>();
app.MapControllers();

app.Run();

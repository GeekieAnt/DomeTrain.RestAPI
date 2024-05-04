using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Services;

namespace Movies.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieService, MovieService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }

}

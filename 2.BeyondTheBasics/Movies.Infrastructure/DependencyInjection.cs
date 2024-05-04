using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Repositories;

namespace Movies.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IMovieRepo, MovieRepo>();


            services.AddDbContext<MoviesDbContext>(optionsBuilder =>
            {
                optionsBuilder
                   .UseSqlServer(connectionString, sqlBuilder =>
                       sqlBuilder.MaxBatchSize(50))
                   .LogTo(Console.WriteLine);
            },
              ServiceLifetime.Singleton);

            return services;
        }


    }
}

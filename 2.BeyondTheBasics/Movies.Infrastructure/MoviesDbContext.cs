using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;

namespace Movies.Infrastructure
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies => Set<Movie>();

        public DbSet<Genre> Genres => Set<Genre>();
    }
}

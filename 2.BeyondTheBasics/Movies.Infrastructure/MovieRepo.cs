using Microsoft.EntityFrameworkCore;
using Movies.Application.Repositories;
using Movies.Domain.Models;

namespace Movies.Infrastructure
{
    public class MovieRepo : IMovieRepo
    {
        private readonly MoviesDbContext _context;

        public MovieRepo(MoviesDbContext moviesDb)
        {
            _context = moviesDb;
        }

        public async Task<Movie> CreateAsync(Movie movie, CancellationToken token = default)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _context.Movies
                .AsNoTracking()
                .AnyAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default)
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        }

        //public async Task<Movie?> GetBySlugAsync(string slug, CancellationToken token = default)
        //{
        //    return await _context.Movies.FirstOrDefaultAsync(m => m.Slug == slug);
        //}

        public async Task<Movie?> UpdateAsync(Movie movie, CancellationToken token = default)
        {

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return movie;
        }
    }
}
;
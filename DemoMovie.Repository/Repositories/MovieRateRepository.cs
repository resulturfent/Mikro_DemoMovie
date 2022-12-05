using DemoMovie.Core;
using DemoMovie.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Repository.Repositories
{
    public class MovieRateRepository : GenericRepository<MovieRate>, IMovieRateRepository
    {
        public MovieRateRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<MovieRate>> GetAllAsync()
        {
            return await _context.MovieRate.Include(k => k.Movies ).ToListAsync();
            //Eager Loading=> MovieRate ile beraber Movie de çekilmesi Eager Loading örneğidir
            //MovieRate çekerken ihtiyaç olması dahilinde sonrasında Movie'leri de çekerseniz Lazy Loading olur
        }

        public async Task<List<MovieRate>> GetMovieRateByIdAsync(int movieId, int userId)
        {
            return await _context.MovieRate.Include(k => k.UserId==userId && k.MoviesId==movieId).ToListAsync();
        }
    }
}

using DemoMovie.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core.Repositories
{
    public interface IMovieRateRepository : IGenericRepository<MovieRate>
    {
        Task<List<MovieRate>> GetAllAsync();
        Task<List<MovieRate>> GetMovieRateByIdAsync(int movieId, int userId);
        List<MovieRate> AddMovieRate(string userName, int score, int movieId, int userId, string comment);
    }
}

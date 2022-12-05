using DemoMovie.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core.Services
{
    public interface IMovieRateService:IService<MovieRate>
    {
       public Task<List<MovieWithRateDTO>> GetAllAsync();
      public  Task<CustomResponseDTO<List<MovieWithRateDTO>>> GetMovieRateByIdAsync(int movieId, int userId);
    
    }
}

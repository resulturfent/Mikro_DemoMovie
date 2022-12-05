using AutoMapper;
using DemoMovie.Core;
using DemoMovie.Core.DTO;
using DemoMovie.Core.Repositories;
using DemoMovie.Core.Services;
using DemoMovie.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Service.Services
{
    public class MovieRateService : Service<MovieRate>, IMovieRateService
    {

        private readonly IMovieRateRepository _movieRateRepository;
        private readonly IMapper _mapper;

        public MovieRateService(IGenericRepository<MovieRate> repository, IUnitOfWork unitOfWork, IMapper mapper, IMovieRateRepository movieRateRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _movieRateRepository = movieRateRepository;
        }

       

        public async Task<CustomResponseDTO<List<MovieWithRateDTO>>> GetMovieRateByIdAsync(int movieId, int userId)
        {
           var  movieInformation= await _movieRateRepository.GetMovieRateByIdAsync(movieId, userId);

            var movieWithRateDTO = _mapper.Map<List<MovieWithRateDTO>>(movieInformation);

            return CustomResponseDTO<List<MovieWithRateDTO>>.Success(200, movieWithRateDTO);
        }

         

        async Task<List<MovieWithRateDTO>> IMovieRateService.GetAllAsync()
        {
            throw  new NotImplementedException();
        }

        Task<CustomResponseDTO<List<MovieWithRateDTO>>> IMovieRateService.GetMovieRateByIdAsync(int movieId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

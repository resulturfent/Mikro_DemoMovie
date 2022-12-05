using AutoMapper;
using DemoMovie.Core;
using DemoMovie.Core.DTO;
using DemoMovie.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRateController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<MovieRate> _service;
        private readonly IMovieRateService _movieRateService;

        public MovieRateController(IMapper mapper, IService<MovieRate> service, IMovieRateService movieRateService)
        {
            _mapper = mapper;
            _service = service;
            _movieRateService = movieRateService;
        }

        //[HttpGet("action")]//Direk method ismini al ması için kullanılır
        [HttpGet("GetMovieRate")]
        public async Task<IActionResult> GetMovieRate(int movieId,int userId=1)
        {
            return CreateActionResult(await _movieRateService.GetMovieRateByIdAsync(movieId, userId));
        }

        [HttpPost()]
        //public async Task<IActionResult> AddMovieRate(string userName,int score,int movieId,int userId,string comment)
        public async Task<IActionResult> AddMovieRate(MovieRateDTO movieRateDTO)
        {

            var movieRateAdd =await _service.AddAsync(_mapper.Map<MovieRate>(movieRateDTO));
            var movieRateDTO1 = _mapper.Map<MovieRateDTO>(movieRateAdd);
            return CreateActionResult(CustomResponseDTO<MovieRateDTO>.Success(201, movieRateDTO));

        }

        [HttpPut()]
        public async Task<IActionResult> UpdateMovieRate(MovieRate movieRate)
        {
             await _service.UpdateAsync(_mapper.Map<MovieRate>(movieRate));
           
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));

        }



    }
}

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
            //var getInformation =  _service.Where(k=>k.MoviesId==MovieId && k.UserId==1);

            //var moviesRateDTO = _mapper.Map<List<MovieRateDTO>>(getInformation.ToList());

            ////return Ok(CustomResponseDTO<List<MovieDTO>>.Success(200,movieDTO));
            //return CreateActionResult(CustomResponseDTO<List<MovieRateDTO>>.Success(200, moviesRateDTO));

            return CreateActionResult(await _movieRateService.GetMovieRateByIdAsync(movieId, userId));
        }

    }
}

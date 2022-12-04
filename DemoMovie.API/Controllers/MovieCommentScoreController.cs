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
    public class MovieCommentScoreController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Movies> _service;

        public MovieCommentScoreController(IMapper mapper, IService<Movies> service)
        {
            _mapper = mapper;
            _service = service;
        }


        /// <summary>
        /// Bu method filme yorum ve puan eklemek için kullanılır
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddMovieComment(int movieId)
        {
            var getMovies = await _service.GetAllAsync();

            var moviesDTO = _mapper.Map<List<MovieDTO>>(getMovies.ToList());

            //return Ok(CustomResponseDTO<List<MovieDTO>>.Success(200,movieDTO));
            return CreateActionResult(CustomResponseDTO<List<MovieDTO>>.Success(200, moviesDTO));
        }



    }
}

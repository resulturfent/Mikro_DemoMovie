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
    public class MovieController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Movies> _service;

        public MovieController(IMapper mapper, IService<Movies> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GelAllMovie")]
        public async Task<IActionResult> GetAllMovie()
        {
            var getMovies=await _service.GetAllAsync();

            var moviesDTO = _mapper.Map<List<MovieDTO>>(getMovies.ToList());

            //return Ok(CustomResponseDTO<List<MovieDTO>>.Success(200,movieDTO));
            return CreateActionResult(CustomResponseDTO<List<MovieDTO>>.Success(200, moviesDTO));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var getMovie = await _service.GetByIdAsync(Id);

            var movieDTO = _mapper.Map<List<MovieDTO>>(getMovie);

            //return Ok(CustomResponseDTO<List<MovieDTO>>.Success(200,movieDTO));
            return CreateActionResult(CustomResponseDTO<List<MovieDTO>>.Success(200, movieDTO));
        }


    }
}

using AutoMapper;
using DemoMovie.Core;
using DemoMovie.Core.DTO;

namespace DemoMovie.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<MovieComment, CommentDTO>().ReverseMap();
            CreateMap<Movies, MovieDTO>().ReverseMap();
            CreateMap<MovieScore, MovieScoreDTO>().ReverseMap();
            

        }
    }
}

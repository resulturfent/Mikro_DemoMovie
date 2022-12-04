using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core.DTO
{
    public class MovieScoreDTO:BaseDTO
    {
        public byte Score { get; set; }//filme verlecek puan
        public byte AverageScore { get; set; }//filmin puan oetalaması

        public int UserId { get; set; }
        public int MoviesId { get; set; }

    }
}

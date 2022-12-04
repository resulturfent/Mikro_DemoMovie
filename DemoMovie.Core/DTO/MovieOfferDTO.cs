using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core.DTO
{
    public class MovieOfferDTO:BaseDTO
    {
        public byte Score { get; set; }//filme verilecek puan
        public byte AverageScore { get; set; }//filmin puan ortalaması
        public int UserId { get; set; }
        public int MoviesId { get; set; }

    }
}

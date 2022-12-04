using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core.DTO
{
    public class MovieRateDTO : BaseDTO
    {
        public string Comment { get; set; }
        public byte Score { get; set; }
        public int UserId { get; set; }
        public int MoviesId { get; set; }

    }
}

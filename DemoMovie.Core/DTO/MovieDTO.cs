using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core.DTO
{
    public class MovieDTO:BaseDTO
    {
        public string MovieName { get; set; }
        public decimal AverageScore { get; set; }
        public string Description { get; set; }
        public int MovieCategoryId { get; set; }

    }
}

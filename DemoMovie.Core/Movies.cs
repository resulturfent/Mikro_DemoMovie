using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core
{
    public class Movies : BaseEntity
    {
        public string MovieName { get; set; }
        public decimal AverageScore { get; set; }
        public string Description { get; set; }
        public int MovieCategoryId { get; set; }

        public MovieCategory MovieCategory { get; set; }
        public ICollection<MovieComment> MovieComment { get; set; }
        public ICollection<MovieScore> MovieScore { get; set; }
        public ICollection<MovieRate> MovieRate { get; set; }
        public ICollection<MovieOffer> MovieOffer { get; set; }



    }
}

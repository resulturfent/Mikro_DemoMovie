using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core
{
    public  class MovieCategory:BaseEntity
    {
        public string  CategoryName { get; set; }

        public ICollection<Movies> Movies { get; set; }//Navigation Property

    }
}

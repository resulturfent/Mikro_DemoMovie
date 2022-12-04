using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core
{
    public class MovieScore:BaseEntity
    {

        public byte Score { get; set; }
        public int  UserId{ get; set; }
        public int MoviesId { get; set; }


        public User User { get; set; }
        public Movies Movies{ get; set; }

    }
}

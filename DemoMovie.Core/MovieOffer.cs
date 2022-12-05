using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Core
{
    public class MovieOffer:BaseEntity
    {
        public int UserId { get; set; }
        public string ToMail { get; set; }
        public int MovieId { get; set; }

        public Movies Movies { get; set; }
        public User User { get; set; }

    }
}

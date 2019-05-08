using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Models
{
    public class RootResponse : Resource
    {
        public Link History { get; set; }

        public Link Image { get; set; }
    }
}

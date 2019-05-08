using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Models
{
    public class Image : Resource
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
    }
}

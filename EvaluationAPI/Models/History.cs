using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Models
{
    public class History : Resource
    {
        public string ImageUrl { get; set; }

        public Boolean Liked { get; set; }

        [JsonIgnore]
        public Guid UserGuid { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}

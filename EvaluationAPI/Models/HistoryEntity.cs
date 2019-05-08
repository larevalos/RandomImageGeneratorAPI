using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Models
{
    public class HistoryEntity
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
       
        public Boolean Liked { get; set; }

        public DateTime? LastUpdate { get; set; }

        public Guid UserGuid { get; set; }

        public int ImageId { get; set; }
    }
}

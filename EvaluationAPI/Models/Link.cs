using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Models
{
    public class Link
    {
        public const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = null
            };

        public static Link ToCollection(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = new[] { "collection" }
            };

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3,
            PropertyName = "rel",
            NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }

        [JsonProperty(Order = -4, 
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling =NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)] //ion specification  if the method is blank or null, it's assumed to be get. 
        public string Method { get; set; }

        // It will store the route name before being rewritten by LinkRewrittingFilter 
        [JsonIgnore]
        public string RouteName { get; set; }

        // It will store the route parameters before being rewritten by LinkRewrittingFilter 
        [JsonIgnore]
        public object RouteValues { get; set; }
    }
}

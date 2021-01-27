using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modelos.Watson
{
    public class OutputWatson
    {
        [JsonProperty("generic", NullValueHandling = NullValueHandling.Include)]
        public List<Generic> Generic { get; set; }
        public object Textos { get; set; }
    }
}

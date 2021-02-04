using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class OutputConversaWatson
    {
        [JsonProperty("output", NullValueHandling = NullValueHandling.Include)]
        public OutputWatson Output { get; set; }
    }
}

using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class OutputConversaWatson
    {
        //[JsonProperty("context", NullValueHandling = NullValueHandling.Include)]
        //public MessageContext Context { get; set; }
        [JsonProperty("output", NullValueHandling = NullValueHandling.Include)]
        public OutputWatson Output { get; set; }
    }
}

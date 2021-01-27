using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class Generic
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Include)]
        public string Textos { get; set; }
    }
}

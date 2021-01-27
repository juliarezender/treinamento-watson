using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class UserInput
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Texto { get; set; }
    }
}

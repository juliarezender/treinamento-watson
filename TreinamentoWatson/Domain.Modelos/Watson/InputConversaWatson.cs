using Domain.Modelos.Watson;
using Newtonsoft.Json;

namespace Domain.Modelos
{
    public class InputConversaWatson
    {
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public UserInput Input { get; set; }
    }
}

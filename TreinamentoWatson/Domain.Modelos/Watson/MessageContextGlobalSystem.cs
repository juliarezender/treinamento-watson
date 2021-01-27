using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class MessageContextGlobalSystem
    {
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("turn_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? TurnCount { get; set; }
    }
}

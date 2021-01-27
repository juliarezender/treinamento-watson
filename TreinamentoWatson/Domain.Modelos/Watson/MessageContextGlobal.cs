using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class MessageContextGlobal
    {
        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public MessageContextGlobalSystem System { get; set; }

        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }
    }
}

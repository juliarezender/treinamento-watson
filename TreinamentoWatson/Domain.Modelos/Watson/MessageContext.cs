using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class MessageContext
    {
        [JsonProperty("global", NullValueHandling = NullValueHandling.Ignore)]
        public MessageContextGlobal Global { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public MessageContextSkills Skills { get; set; }
    }
}

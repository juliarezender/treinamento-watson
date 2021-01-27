using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class MainSkillContext
    {

        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic System { get; set; }
    }
}

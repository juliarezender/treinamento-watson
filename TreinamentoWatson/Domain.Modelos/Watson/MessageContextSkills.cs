using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class MessageContextSkills
    {
        [JsonProperty("main skill", NullValueHandling = NullValueHandling.Ignore)]
        public MainSkillContext MainSkillContext { get; set; }
    }
}

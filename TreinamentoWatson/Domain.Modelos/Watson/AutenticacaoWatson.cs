using Newtonsoft.Json;

namespace Domain.Modelos.Watson
{
    public class AutenticacaoWatson
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("expiration")]
        public long Expiration { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}

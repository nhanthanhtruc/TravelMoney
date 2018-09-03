using Newtonsoft.Json;
namespace TravelMoney.Models
{
    public partial class TokenGoogle
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}

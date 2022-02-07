using Newtonsoft.Json;

namespace Pixlpark.Models
{
    public class Shipping
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}

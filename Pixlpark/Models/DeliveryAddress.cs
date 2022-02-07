using Newtonsoft.Json;

namespace Pixlpark.Models
{
    public class DeliveryAddress
    {
        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("AddressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("AddressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }
    }
}

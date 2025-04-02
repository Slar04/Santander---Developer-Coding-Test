using Newtonsoft.Json;

namespace SantanderDeveloperCodingTest.Model.Models
{
    public class Comment
    {
        [JsonProperty("kids")]
        public List<int>? Kids { get; set; }
    }
}

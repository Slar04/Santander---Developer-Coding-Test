using Newtonsoft.Json;
using SantanderDeveloperCodingTest.Model.Converters;

namespace SantanderDeveloperCodingTest.Model.Models
{
    public class Story
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Uri { get; set; } = string.Empty;

        [JsonProperty("by")]
        public string PostedBy { get; set; } = string.Empty;

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public string Time { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("descendants")]
        public int CommentCount { get; set; }

        [JsonProperty("kids")]
        public List<int>? CommentIds { get; set; }
    }
}

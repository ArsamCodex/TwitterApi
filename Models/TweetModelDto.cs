using Newtonsoft.Json;

namespace TwitterApi.Models
{
    public class TweetModelDto
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}

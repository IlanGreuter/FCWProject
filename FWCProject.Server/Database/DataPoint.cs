using System.Text.Json;
using System.Text.Json.Serialization;
namespace FCWProject.Database
{
    public struct DataPoint
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("timestamp")]
        public string timestamp { get; set; }
    }
}

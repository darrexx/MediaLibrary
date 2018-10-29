using System.Collections.Generic;
using Newtonsoft.Json;

namespace MediaLibrary.Model
{
    public class GiantBombResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("number_of_page_results")]
        public int NumberOfPageResults { get; set; }

        [JsonProperty("number_of_total_results")]
        public int NumberOfTotalResults { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("results")]
        public IEnumerable<Game> Results { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
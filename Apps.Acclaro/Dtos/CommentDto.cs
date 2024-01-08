using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Dtos
{
    public class CommentDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("system")]
        public bool System { get; set; }
    }
}

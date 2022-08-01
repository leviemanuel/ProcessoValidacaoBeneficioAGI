using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class ApexRemoteRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("data")]
        public List<string> Data { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tid")]
        public long Tid { get; set; }

        [JsonProperty("ctx")]
        public Ctx Ctx { get; set; }
    }

    public partial class Ctx
    {
        [JsonProperty("csrf")]
        public string Csrf { get; set; }

        [JsonProperty("vid")]
        public string Vid { get; set; }

        [JsonProperty("ns")]
        public string Ns { get; set; }

        [JsonProperty("ver")]
        public long Ver { get; set; }
    }
}

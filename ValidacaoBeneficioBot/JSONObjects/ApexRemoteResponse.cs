using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public class ApexRemoteResponse
    {
        public List<ApexRemoteResponseItem> Items { get; set; }
    }

    public class ApexRemoteResponseItem
    {
        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tid")]
        public long Tid { get; set; }

        [JsonProperty("ref")]
        public bool Ref { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("errors")]
        public object[] Errors { get; set; }

        [JsonProperty("messages")]
        public object[] Messages { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("validations")]
        public object[] Validations { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("GevAtendimentoDetailSrcUrl")]
        public Uri GevAtendimentoDetailSrcUrl { get; set; }

        [JsonProperty("SimulatorPhoneSrcUrl")]
        public Uri SimulatorPhoneSrcUrl { get; set; }

        [JsonProperty("SimulatorSrcUrl")]
        public Uri SimulatorSrcUrl { get; set; }

        [JsonProperty("Step")]
        public string Step { get; set; }

        [JsonProperty("TaskId")]
        public string TaskId { get; set; }
    }
}
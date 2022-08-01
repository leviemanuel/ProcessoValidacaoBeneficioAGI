using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class VfrmRemotingProviderImplResponse
    {
        [JsonProperty("vf")]
        public Vf Vf { get; set; }

        [JsonProperty("actions")]
        public Actions Actions { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }
    }

    public partial class Actions
    {
        [JsonProperty("OriginationTabController")]
        public OriginationTabController OriginationTabController { get; set; }
    }

    public partial class OriginationTabController
    {
        [JsonProperty("ms")]
        public Ms[] Ms { get; set; }

        [JsonProperty("prm")]
        public long Prm { get; set; }
    }

    public partial class Ms
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("len")]
        public long Len { get; set; }

        [JsonProperty("ns")]
        public string Ns { get; set; }

        [JsonProperty("ver")]
        public long Ver { get; set; }

        [JsonProperty("csrf")]
        public string Csrf { get; set; }
    }

    public partial class Vf
    {
        [JsonProperty("vid")]
        public string Vid { get; set; }

        [JsonProperty("xhr")]
        public bool Xhr { get; set; }

        [JsonProperty("dev")]
        public bool Dev { get; set; }

        [JsonProperty("tst")]
        public bool Tst { get; set; }

        [JsonProperty("dbg")]
        public bool Dbg { get; set; }

        [JsonProperty("tm")]
        public long Tm { get; set; }

        [JsonProperty("ovrprm")]
        public bool Ovrprm { get; set; }
    }
}

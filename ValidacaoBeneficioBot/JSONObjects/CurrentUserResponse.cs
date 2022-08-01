using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class CurrentUserResponse
    {
        [JsonProperty("isChatterEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsChatterEnabled { get; set; }

        [JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}


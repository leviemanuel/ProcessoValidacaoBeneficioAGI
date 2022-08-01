using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class SimularResponse
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Data Data { get; set; }

        [JsonProperty("deveSolicitarChecklistDigital", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeveSolicitarChecklistDigital { get; set; }

        [JsonProperty("deveSolicitarChecklistSupervisor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeveSolicitarChecklistSupervisor { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("exibirMargemCompartilhada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExibirMargemCompartilhada { get; set; }

        [JsonProperty("tipoSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoSimulacao { get; set; }

        [JsonProperty("dataHoraSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraSimulacao { get; set; }

        [JsonProperty("valorMargemMaxima", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemMaxima { get; set; }

        [JsonProperty("politicaMargemCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PoliticaMargemCodigo { get; set; }

        [JsonProperty("erroList", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ErroList { get; set; }
    }
}

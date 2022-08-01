using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class SalvaDadosIdentificacaoRequest
    {
        [JsonProperty("atendimentoCliente")]
        public SalvaDadosIdentificacaoRequestAtendimentoCliente AtendimentoCliente { get; set; }

        [JsonProperty("dataNascimentoString")]
        public string DataNascimentoString { get; set; }

        [JsonProperty("confirma")]
        public bool? Confirma { get; set; }

        [JsonProperty("etapa")]
        public long? Etapa { get; set; }
    }

    public partial class SalvaDadosIdentificacaoRequestAtendimentoCliente
    {
        [JsonProperty("atendimentoClienteCodigo")]
        public long? AtendimentoClienteCodigo { get; set; }

        [JsonProperty("atendimentoCodigo")]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("regraPagamentoCodigo")]
        public object RegraPagamentoCodigo { get; set; }

        [JsonProperty("cpfCnpj")]
        public string CpfCnpj { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("dataNascimento")]
        public string DataNascimento { get; set; }

        [JsonProperty("dataNascimentoString")]
        public string DataNascimentoString { get; set; }

        [JsonProperty("aceitaReceberSMS")]
        public bool? AceitaReceberSms { get; set; }

        [JsonProperty("aceitaReceberEmail")]
        public bool? AceitaReceberEmail { get; set; }

        [JsonProperty("aceitaReceberMensagemSAC")]
        public bool? AceitaReceberMensagemSac { get; set; }

        [JsonProperty("naturezaOcupacaoCodigo")]
        public object NaturezaOcupacaoCodigo { get; set; }

        [JsonProperty("matricula")]
        public object Matricula { get; set; }

        [JsonProperty("skype")]
        public object Skype { get; set; }

        [JsonProperty("bloqueiaCpfTela")]
        public bool? BloqueiaCpfTela { get; set; }

        [JsonProperty("clienteNovo")]
        public bool? ClienteNovo { get; set; }

        [JsonProperty("clienteRestritivo")]
        public bool? ClienteRestritivo { get; set; }

        [JsonProperty("tipoRestritividade")]
        public long? TipoRestritividade { get; set; }

        [JsonProperty("mensagemRestritividade")]
        public string MensagemRestritividade { get; set; }

        [JsonProperty("erroHistoricoContrato")]
        public object ErroHistoricoContrato { get; set; }

        [JsonProperty("peso")]
        public object Peso { get; set; }

        [JsonProperty("altura")]
        public object Altura { get; set; }

        [JsonProperty("tipoDocumentoCodigo")]
        public long? TipoDocumentoCodigo { get; set; }

        [JsonProperty("documentoIdentificacao")]
        public string DocumentoIdentificacao { get; set; }

        [JsonProperty("orgaoExpedidorCodigo")]
        public object OrgaoExpedidorCodigo { get; set; }

        [JsonProperty("ufExpedicao")]
        public object UfExpedicao { get; set; }

        [JsonProperty("dataExpedicao")]
        public object DataExpedicao { get; set; }

        [JsonProperty("dataExpedicaoString")]
        public string DataExpedicaoString { get; set; }

        [JsonProperty("sexo")]
        public object Sexo { get; set; }

        [JsonProperty("nacionalidadeCodigo")]
        public object NacionalidadeCodigo { get; set; }

        [JsonProperty("naturalidadeEstadoUF")]
        public object NaturalidadeEstadoUf { get; set; }

        [JsonProperty("naturalidadeCidadeCodigo")]
        public object NaturalidadeCidadeCodigo { get; set; }

        [JsonProperty("nomePai")]
        public object NomePai { get; set; }

        [JsonProperty("nomeMae")]
        public object NomeMae { get; set; }

        [JsonProperty("ocupacaoCodigo")]
        public object OcupacaoCodigo { get; set; }

        [JsonProperty("estadoCivilCodigo")]
        public object EstadoCivilCodigo { get; set; }

        [JsonProperty("conjugeNome")]
        public object ConjugeNome { get; set; }

        [JsonProperty("escolaridadeCodigo")]
        public object EscolaridadeCodigo { get; set; }

        [JsonProperty("ppe")]
        public object Ppe { get; set; }

        [JsonProperty("conjugeCpf")]
        public object ConjugeCpf { get; set; }

        [JsonProperty("biometriaFacialMotivoCodigo")]
        public object BiometriaFacialMotivoCodigo { get; set; }

        [JsonProperty("biometriaFacialMotivoPontoCodigo")]
        public object BiometriaFacialMotivoPontoCodigo { get; set; }

        [JsonProperty("envioEmailRestricaoBiometriaFacial")]
        public bool? EnvioEmailRestricaoBiometriaFacial { get; set; }

        [JsonProperty("divergenciaBiometriaFacial")]
        public bool? DivergenciaBiometriaFacial { get; set; }

        [JsonProperty("indisponibilidadeBiometriaFacial")]
        public bool? IndisponibilidadeBiometriaFacial { get; set; }

        [JsonProperty("statusBiometriaFacial")]
        public object StatusBiometriaFacial { get; set; }

        [JsonProperty("patrimonioCodigo")]
        public object PatrimonioCodigo { get; set; }

        [JsonProperty("atendimento")]
        public object Atendimento { get; set; }

        [JsonProperty("regraPagamento")]
        public object RegraPagamento { get; set; }

        [JsonProperty("procuradorCpf")]
        public object ProcuradorCpf { get; set; }

        [JsonProperty("dataValidadeFoto")]
        public object DataValidadeFoto { get; set; }

        [JsonProperty("origemCapturaBiometria")]
        public object OrigemCapturaBiometria { get; set; }

        [JsonProperty("scoreAcesso")]
        public object ScoreAcesso { get; set; }

        [JsonProperty("liveness")]
        public object Liveness { get; set; }

        [JsonProperty("clienteAlfabetizado")]
        public object ClienteAlfabetizado { get; set; }

        [JsonProperty("dataNascimentoDataPrev")]
        public object DataNascimentoDataPrev { get; set; }

        [JsonProperty("erroList")]
        public List<object> ErroList { get; set; }

        [JsonProperty("enderecoResidencial")]
        public AtendimentoClienteEndereco EnderecoResidencial { get; set; }

        [JsonProperty("enderecoProspeccao")]
        public object EnderecoProspeccao { get; set; }

        [JsonProperty("referenciaList")]
        public List<object> ReferenciaList { get; set; }

        [JsonProperty("contratoHistoricoList")]
        public List<object> ContratoHistoricoList { get; set; }

        [JsonProperty("atendimentoClienteEmailList")]
        public List<object> AtendimentoClienteEmailList { get; set; }

        [JsonProperty("atendimentoClienteEnderecoList")]
        public List<AtendimentoClienteEndereco> AtendimentoClienteEnderecoList { get; set; }

        [JsonProperty("atendimentoClienteTelefoneList")]
        public List<AtendimentoClienteTelefoneList> AtendimentoClienteTelefoneList { get; set; }

        [JsonProperty("atendimentoClienteReferenciaList")]
        public List<AtendimentoClienteReferenciaList> AtendimentoClienteReferenciaList { get; set; }

        [JsonProperty("atendimentoClienteTestemunhaList")]
        public List<object> AtendimentoClienteTestemunhaList { get; set; }

        [JsonProperty("clienteContaCorrente")]
        public object ClienteContaCorrente { get; set; }

        [JsonProperty("possuiContaCorrente")]
        public bool? PossuiContaCorrente { get; set; }

        [JsonProperty("atendimentoClienteEndereco")]
        public AtendimentoClienteEndereco AtendimentoClienteEndereco { get; set; }
    }

    public partial class AtendimentoClienteEndereco
    {
        [JsonProperty("atendimentoClienteEnderecoCodigo")]
        public long? AtendimentoClienteEnderecoCodigo { get; set; }

        [JsonProperty("atendimentoClienteCodigo")]
        public long? AtendimentoClienteCodigo { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("estadoUF")]
        public object EstadoUf { get; set; }

        [JsonProperty("cidadeCodigo")]
        public object CidadeCodigo { get; set; }

        [JsonProperty("bairroCodigo")]
        public object BairroCodigo { get; set; }

        [JsonProperty("outroBairroDescricao")]
        public object OutroBairroDescricao { get; set; }

        [JsonProperty("tipoLogradouroCodigo")]
        public object TipoLogradouroCodigo { get; set; }

        [JsonProperty("logradouro")]
        public object Logradouro { get; set; }

        [JsonProperty("numero")]
        public object Numero { get; set; }

        [JsonProperty("semNumero")]
        public bool? SemNumero { get; set; }

        [JsonProperty("complemento")]
        public object Complemento { get; set; }

        [JsonProperty("tipoResidenciaCodigo")]
        public object TipoResidenciaCodigo { get; set; }

        [JsonProperty("valorParcelaFinanciamento")]
        public object ValorParcelaFinanciamento { get; set; }

        [JsonProperty("valorParcelaFinanciamentoString")]
        public string ValorParcelaFinanciamentoString { get; set; }

        [JsonProperty("tipoEndereco")]
        public long? TipoEndereco { get; set; }

        [JsonProperty("atendimentoCliente")]
        public AtendimentoClienteEnderecoAtendimentoCliente AtendimentoCliente { get; set; }

        [JsonProperty("temDados")]
        public bool? TemDados { get; set; }

        [JsonProperty("estadoUfDescricao")]
        public object EstadoUfDescricao { get; set; }

        [JsonProperty("cidadeNome")]
        public object CidadeNome { get; set; }

        [JsonProperty("bairroNome")]
        public object BairroNome { get; set; }

        [JsonProperty("tipoLogradouroDescricao")]
        public object TipoLogradouroDescricao { get; set; }
    }

    public partial class AtendimentoClienteEnderecoAtendimentoCliente
    {
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class ObterUltimaOperacaoResponse
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("atendimentoOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoOperacao AtendimentoOperacao { get; set; }

        [JsonProperty("cliente", NullValueHandling = NullValueHandling.Ignore)]
        public Cliente Cliente { get; set; }

        [JsonProperty("valorSimulacaoAutomatica", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSimulacaoAutomatica { get; set; }

        [JsonProperty("regraPagamento", NullValueHandling = NullValueHandling.Ignore)]
        public RegraPagamento RegraPagamento { get; set; }

        [JsonProperty("etapaCadastroConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaCadastroConfirmada { get; set; }

        [JsonProperty("etapaTestemunhaConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaTestemunhaConfirmada { get; set; }

        [JsonProperty("etapaDadosContatoConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaDadosContatoConfirmada { get; set; }

        [JsonProperty("etapaDocumentosConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaDocumentosConfirmada { get; set; }

        [JsonProperty("etapaEnderecoConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaEnderecoConfirmada { get; set; }

        [JsonProperty("etapaOperacaoConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaOperacaoConfirmada { get; set; }

        [JsonProperty("etapaReferenciasConfirmada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtapaReferenciasConfirmada { get; set; }
    }

    public partial class AtendimentoOperacao
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("atendimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("dataHoraOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraOperacao { get; set; }

        [JsonProperty("usuarioOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsuarioOperacaoCodigo { get; set; }

        [JsonProperty("regraPagamentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegraPagamentoCodigo { get; set; }

        [JsonProperty("upagCodigo")]
        public object UpagCodigo { get; set; }

        [JsonProperty("instituicaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? InstituicaoCodigo { get; set; }

        [JsonProperty("grupoInstituicaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoInstituicaoCodigo { get; set; }

        [JsonProperty("naturezaOcupacaoCodigo")]
        public object NaturezaOcupacaoCodigo { get; set; }

        [JsonProperty("situacaoFuncionalCodigo")]
        public object SituacaoFuncionalCodigo { get; set; }

        [JsonProperty("matricula", NullValueHandling = NullValueHandling.Ignore)]
        public string Matricula { get; set; }

        [JsonProperty("matriculaInstituidor")]
        public object MatriculaInstituidor { get; set; }

        [JsonProperty("dataPermanenciaOrgao")]
        public object DataPermanenciaOrgao { get; set; }

        [JsonProperty("bancoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string BancoCodigo { get; set; }

        [JsonProperty("agenciaNumero")]
        public object AgenciaNumero { get; set; }

        [JsonProperty("tipoCodigoOperacaoCEFCodigo")]
        public object TipoCodigoOperacaoCefCodigo { get; set; }

        [JsonProperty("contaNumero")]
        public object ContaNumero { get; set; }

        [JsonProperty("tipoContaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaCodigo { get; set; }

        [JsonProperty("valorRendaBruta", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorRendaBruta { get; set; }

        [JsonProperty("valorRendaLiquida", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorRendaLiquida { get; set; }

        [JsonProperty("rendaEstimada")]
        public object RendaEstimada { get; set; }

        [JsonProperty("diaPagamentoCalculado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DiaPagamentoCalculado { get; set; }

        [JsonProperty("valorTipoDespesa")]
        public double? ValorTipoDespesa { get; set; }

        [JsonProperty("valorTipoDespesaOriginal")]
        public double? ValorTipoDespesaOriginal { get; set; }

        [JsonProperty("naoPossuiTipoDespesa", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiTipoDespesa { get; set; }

        [JsonProperty("valorAditivoDesconto")]
        public object ValorAditivoDesconto { get; set; }

        [JsonProperty("valorAditivoDescontoOriginal")]
        public object ValorAditivoDescontoOriginal { get; set; }

        [JsonProperty("naoPossuiAditivoDesconto", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiAditivoDesconto { get; set; }

        [JsonProperty("possuiAditivoDesconto", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PossuiAditivoDesconto { get; set; }

        [JsonProperty("valorParcelaDevedorRefin")]
        public object ValorParcelaDevedorRefin { get; set; }

        [JsonProperty("valorSaldoDevedorRefin")]
        public object ValorSaldoDevedorRefin { get; set; }

        [JsonProperty("dataRecebimentoSalario", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataRecebimentoSalario { get; set; }

        [JsonProperty("especieCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? EspecieCodigo { get; set; }

        [JsonProperty("valorMargemConsignavel")]
        public object ValorMargemConsignavel { get; set; }

        [JsonProperty("valorMargemDisponivel")]
        public object ValorMargemDisponivel { get; set; }

        [JsonProperty("possivelRMC")]
        public object PossivelRmc { get; set; }

        [JsonProperty("meioPagamentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string MeioPagamentoCodigo { get; set; }

        [JsonProperty("meioPagamentoSimulador")]
        public object MeioPagamentoSimulador { get; set; }

        [JsonProperty("valorProventosBeneficio")]
        public object ValorProventosBeneficio { get; set; }

        [JsonProperty("valorProventosBeneficioOriginal")]
        public object ValorProventosBeneficioOriginal { get; set; }

        [JsonProperty("valorDebitosBeneficio")]
        public object ValorDebitosBeneficio { get; set; }

        [JsonProperty("valorDebitosBeneficioOriginal")]
        public object ValorDebitosBeneficioOriginal { get; set; }

        [JsonProperty("valorEmprestimosBeneficio")]
        public object ValorEmprestimosBeneficio { get; set; }

        [JsonProperty("valorEmprestimosBeneficioOriginal")]
        public object ValorEmprestimosBeneficioOriginal { get; set; }

        [JsonProperty("naoPossuiProventosBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiProventosBeneficio { get; set; }

        [JsonProperty("naoPossuiDebitosBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiDebitosBeneficio { get; set; }

        [JsonProperty("naoPossuiEmprestimosBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiEmprestimosBeneficio { get; set; }

        [JsonProperty("valorLimiteAgiCardConsignado")]
        public object ValorLimiteAgiCardConsignado { get; set; }

        [JsonProperty("bureauHigienizacaoCodigo")]
        public object BureauHigienizacaoCodigo { get; set; }

        [JsonProperty("contaDV")]
        public object ContaDv { get; set; }

        [JsonProperty("percentualSeguroPrestamista")]
        public object PercentualSeguroPrestamista { get; set; }

        [JsonProperty("valorSeguroPrestamista")]
        public object ValorSeguroPrestamista { get; set; }

        [JsonProperty("bancoCedente")]
        public object BancoCedente { get; set; }

        [JsonProperty("agenciaCedente")]
        public object AgenciaCedente { get; set; }

        [JsonProperty("contaCedente")]
        public object ContaCedente { get; set; }

        [JsonProperty("bancoCredito")]
        public object BancoCredito { get; set; }

        [JsonProperty("agenciaCredito")]
        public object AgenciaCredito { get; set; }

        [JsonProperty("contaCredito")]
        public object ContaCredito { get; set; }

        [JsonProperty("tipoOperacaoCreditoCEFCodigo")]
        public object TipoOperacaoCreditoCefCodigo { get; set; }

        [JsonProperty("tipoContaCreditoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaCreditoCodigo { get; set; }

        [JsonProperty("valorCompra")]
        public long? ValorCompra { get; set; }

        [JsonProperty("valorPrestacao")]
        public long? ValorPrestacao { get; set; }

        [JsonProperty("statusContaCorrente")]
        public object StatusContaCorrente { get; set; }

        [JsonProperty("renovacaoAutomatica")]
        public object RenovacaoAutomatica { get; set; }

        [JsonProperty("domicilioEstadoUF")]
        public object DomicilioEstadoUf { get; set; }

        [JsonProperty("contaAtributo")]
        public object ContaAtributo { get; set; }

        [JsonProperty("manterSalarioBancoAgiplan")]
        public object ManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("identificadorSenhaCanais")]
        public object IdentificadorSenhaCanais { get; set; }

        [JsonProperty("declaracaoFinsDeAberturaCodigo")]
        public object DeclaracaoFinsDeAberturaCodigo { get; set; }

        [JsonProperty("idConta")]
        public object IdConta { get; set; }

        [JsonProperty("idCartao")]
        public object IdCartao { get; set; }

        [JsonProperty("pagarCpAgibank", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PagarCpAgibank { get; set; }

        [JsonProperty("valorAutorizacaoDebitoCp")]
        public object ValorAutorizacaoDebitoCp { get; set; }

        [JsonProperty("valorAutorizacaoDebitoSeguro")]
        public object ValorAutorizacaoDebitoSeguro { get; set; }

        [JsonProperty("margemDataPrev")]
        public object MargemDataPrev { get; set; }

        [JsonProperty("margemCartaoDataPrev")]
        public object MargemCartaoDataPrev { get; set; }

        [JsonProperty("bancoAverbacao")]
        public object BancoAverbacao { get; set; }

        [JsonProperty("agenciaAverbacao")]
        public object AgenciaAverbacao { get; set; }

        [JsonProperty("tipoOperacaoCefAverbacaoCodigo")]
        public object TipoOperacaoCefAverbacaoCodigo { get; set; }

        [JsonProperty("contaAverbacao")]
        public object ContaAverbacao { get; set; }

        [JsonProperty("tipoContaAverbacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaAverbacaoCodigo { get; set; }

        [JsonProperty("operacaoSimulador", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OperacaoSimulador { get; set; }

        [JsonProperty("dataCessacaoBeneficio")]
        public object DataCessacaoBeneficio { get; set; }

        [JsonProperty("anoExpedicaoBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public long? AnoExpedicaoBeneficio { get; set; }

        [JsonProperty("scoreBehavior")]
        public object ScoreBehavior { get; set; }

        [JsonProperty("dataCessacaoMotor")]
        public object DataCessacaoMotor { get; set; }

        [JsonProperty("simulacaoChecklistDigital")]
        public object SimulacaoChecklistDigital { get; set; }

        [JsonProperty("bancoNumeroSimulador")]
        public object BancoNumeroSimulador { get; set; }

        [JsonProperty("atendimento")]
        public object Atendimento { get; set; }

        [JsonProperty("regraPagamento")]
        public object RegraPagamento { get; set; }

        [JsonProperty("banco")]
        public object Banco { get; set; }

        [JsonProperty("especie", NullValueHandling = NullValueHandling.Ignore)]
        public Especie Especie { get; set; }

        [JsonProperty("atendimentoOperacaoAditivoDescontoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoAditivoDescontoList { get; set; }

        [JsonProperty("atendimentoOperacaoTipoDespesaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoTipoDespesaList { get; set; }

        [JsonProperty("atendimentoOperacaoRefinContratoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoRefinContratoList { get; set; }

        [JsonProperty("atendimentoOperacaoParcelaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoParcelaList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCPList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoSimulacaoCpList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCartaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoSimulacaoCartaoList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoSeguroList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoSimulacaoSeguroList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoContaCorrenteList")]
        public object AtendimentoOperacaoSimulacaoContaCorrenteList { get; set; }

        [JsonProperty("clienteDomiciliado")]
        public object ClienteDomiciliado { get; set; }

        [JsonProperty("especieValor", NullValueHandling = NullValueHandling.Ignore)]
        public long? EspecieValor { get; set; }

        [JsonProperty("meioPagamento")]
        public object MeioPagamento { get; set; }

        [JsonProperty("dataPermanenciaOrgaoObrigatoria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DataPermanenciaOrgaoObrigatoria { get; set; }

        [JsonProperty("ehInstituicaoGrupoINSS", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EhInstituicaoGrupoInss { get; set; }

        [JsonProperty("dadosAverbacaoOrigemMotor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DadosAverbacaoOrigemMotor { get; set; }

        [JsonProperty("atendimentoSimulador", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AtendimentoSimulador { get; set; }

        [JsonProperty("maximoDiasContraCheque", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaximoDiasContraCheque { get; set; }

        [JsonProperty("maximoDiasDataFuturaContraCheque", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaximoDiasDataFuturaContraCheque { get; set; }

        [JsonProperty("tipoOperacaoCEF")]
        public object TipoOperacaoCef { get; set; }

        [JsonProperty("tipoOperacaoCEFCredito")]
        public object TipoOperacaoCefCredito { get; set; }

        [JsonProperty("tipoOperacaoCEFAverbacao")]
        public object TipoOperacaoCefAverbacao { get; set; }

        [JsonProperty("possuiCartaoRMC")]
        public string PossuiCartaoRmc { get; set; }

        [JsonProperty("numeroConta")]
        public object NumeroConta { get; set; }

        [JsonProperty("numeroAgencia")]
        public object NumeroAgencia { get; set; }

        [JsonProperty("tipoOperacaoCEFCodigo")]
        public object TipoOperacaoCefCodigo { get; set; }

        [JsonProperty("upag")]
        public object Upag { get; set; }

        [JsonProperty("tipoContaSalario", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaSalario { get; set; }

        [JsonProperty("agenciaDV")]
        public object AgenciaDv { get; set; }
    }

    public partial class Cliente
    {

        [JsonProperty("atendimentoClienteCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteCodigo { get; set; }

        [JsonProperty("atendimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("regraPagamentoCodigo")]
        public object RegraPagamentoCodigo { get; set; }

        [JsonProperty("cpfCnpj", NullValueHandling = NullValueHandling.Ignore)]
        public string CpfCnpj { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("dataNascimento", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataNascimento { get; set; }

        [JsonProperty("dataNascimentoString", NullValueHandling = NullValueHandling.Ignore)]
        public string DataNascimentoString { get; set; }

        [JsonProperty("aceitaReceberSMS", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AceitaReceberSms { get; set; }

        [JsonProperty("aceitaReceberEmail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AceitaReceberEmail { get; set; }

        [JsonProperty("aceitaReceberMensagemSAC", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AceitaReceberMensagemSac { get; set; }

        [JsonProperty("naturezaOcupacaoCodigo")]
        public object NaturezaOcupacaoCodigo { get; set; }

        [JsonProperty("matricula")]
        public object Matricula { get; set; }

        [JsonProperty("skype")]
        public object Skype { get; set; }

        [JsonProperty("bloqueiaCpfTela", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BloqueiaCpfTela { get; set; }

        [JsonProperty("clienteNovo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClienteNovo { get; set; }

        [JsonProperty("clienteRestritivo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClienteRestritivo { get; set; }

        [JsonProperty("tipoRestritividade", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoRestritividade { get; set; }

        [JsonProperty("mensagemRestritividade")]
        public object MensagemRestritividade { get; set; }

        [JsonProperty("erroHistoricoContrato")]
        public object ErroHistoricoContrato { get; set; }

        [JsonProperty("peso")]
        public object Peso { get; set; }

        [JsonProperty("altura")]
        public object Altura { get; set; }

        [JsonProperty("dataExpedicaoString", NullValueHandling = NullValueHandling.Ignore)]
        public string DataExpedicaoString { get; set; }

        [JsonProperty("biometriaFacialMotivoCodigo")]
        public object BiometriaFacialMotivoCodigo { get; set; }

        [JsonProperty("biometriaFacialMotivoPontoCodigo")]
        public object BiometriaFacialMotivoPontoCodigo { get; set; }

        [JsonProperty("envioEmailRestricaoBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnvioEmailRestricaoBiometriaFacial { get; set; }

        [JsonProperty("divergenciaBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DivergenciaBiometriaFacial { get; set; }

        [JsonProperty("indisponibilidadeBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IndisponibilidadeBiometriaFacial { get; set; }

        [JsonProperty("statusBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public long? StatusBiometriaFacial { get; set; }

        [JsonProperty("atendimento", NullValueHandling = NullValueHandling.Ignore)]
        public Atendimento Atendimento { get; set; }

        [JsonProperty("regraPagamento")]
        public object RegraPagamento { get; set; }

        [JsonProperty("dataValidadeFoto")]
        public object DataValidadeFoto { get; set; }

        [JsonProperty("origemCapturaBiometria")]
        public object OrigemCapturaBiometria { get; set; }

        [JsonProperty("scoreAcesso")]
        public object ScoreAcesso { get; set; }

        [JsonProperty("liveness")]
        public object Liveness { get; set; }

        [JsonProperty("dataNascimentoDataPrev")]
        public object DataNascimentoDataPrev { get; set; }

        [JsonProperty("erroList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ErroList { get; set; }

        [JsonProperty("enderecoResidencial", NullValueHandling = NullValueHandling.Ignore)]
        public EnderecoResidencial EnderecoResidencial { get; set; }

        [JsonProperty("enderecoProspeccao")]
        public object EnderecoProspeccao { get; set; }

        [JsonProperty("referenciaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ReferenciaList { get; set; }

        [JsonProperty("contratoHistoricoList")]
        public object ContratoHistoricoList { get; set; }

        [JsonProperty("atendimentoClienteEmailList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoClienteEmailList { get; set; }

        [JsonProperty("atendimentoClienteEnderecoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<EnderecoResidencial> AtendimentoClienteEnderecoList { get; set; }

        [JsonProperty("atendimentoClienteTelefoneList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoClienteTelefoneList { get; set; }

        [JsonProperty("atendimentoClienteReferenciaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoClienteReferenciaList> AtendimentoClienteReferenciaList { get; set; }

        [JsonProperty("atendimentoClienteTestemunhaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoClienteTestemunhaList { get; set; }

        [JsonProperty("clienteContaCorrente")]
        public object ClienteContaCorrente { get; set; }

        [JsonProperty("possuiContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PossuiContaCorrente { get; set; }
    }

    public partial class AtendimentoCliente
    {
        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }
    }

    public partial class AtendimentoClienteReferenciaList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("atendimentoClienteReferenciaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteReferenciaCodigo { get; set; }

        [JsonProperty("atendimentoClienteCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteCodigo { get; set; }

        [JsonProperty("nome")]
        public object Nome { get; set; }

        [JsonProperty("grauRelacionamentoCodigo")]
        public object GrauRelacionamentoCodigo { get; set; }

        [JsonProperty("tipoTelefoneCodigo")]
        public object TipoTelefoneCodigo { get; set; }

        [JsonProperty("ddd")]
        public object Ddd { get; set; }

        [JsonProperty("numero")]
        public object Numero { get; set; }

        [JsonProperty("atendimentoCliente", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoCliente AtendimentoCliente { get; set; }
    }

    public partial class Instituicao
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("instituicaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? InstituicaoCodigo { get; set; }

        [JsonProperty("fontePagadoraNome", NullValueHandling = NullValueHandling.Ignore)]
        public string FontePagadoraNome { get; set; }

        [JsonProperty("fontePagadoraId", NullValueHandling = NullValueHandling.Ignore)]
        public string FontePagadoraId { get; set; }

        [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
        public string Situacao { get; set; }

        [JsonProperty("grupoInstituicaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoInstituicaoCodigo { get; set; }

        [JsonProperty("razaoSocial", NullValueHandling = NullValueHandling.Ignore)]
        public string RazaoSocial { get; set; }

        [JsonProperty("cnpj", NullValueHandling = NullValueHandling.Ignore)]
        public string Cnpj { get; set; }

        [JsonProperty("codigoDaFormaDePagamento", NullValueHandling = NullValueHandling.Ignore)]
        public string CodigoDaFormaDePagamento { get; set; }

        [JsonProperty("nomeDaFormaDePagamento", NullValueHandling = NullValueHandling.Ignore)]
        public string NomeDaFormaDePagamento { get; set; }

        [JsonProperty("nomeDoGrupoDaFontePagadora", NullValueHandling = NullValueHandling.Ignore)]
        public string NomeDoGrupoDaFontePagadora { get; set; }

        [JsonProperty("ufDaFontePagadora", NullValueHandling = NullValueHandling.Ignore)]
        public string UfDaFontePagadora { get; set; }

        [JsonProperty("grupoInstituicao", NullValueHandling = NullValueHandling.Ignore)]
        public GrupoInstituicao GrupoInstituicao { get; set; }

        [JsonProperty("instituicaoEndereco", NullValueHandling = NullValueHandling.Ignore)]
        public InstituicaoEndereco InstituicaoEndereco { get; set; }
    }

    public partial class GrupoInstituicao
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("grupoInstituicaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoInstituicaoCodigo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("codigoAnterior", NullValueHandling = NullValueHandling.Ignore)]
        public string CodigoAnterior { get; set; }

        [JsonProperty("codigoLegado", NullValueHandling = NullValueHandling.Ignore)]
        public string CodigoLegado { get; set; }
    }

    public partial class InstituicaoEndereco
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("instituicaoId", NullValueHandling = NullValueHandling.Ignore)]
        public string InstituicaoId { get; set; }

        [JsonProperty("instituicaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? InstituicaoCodigo { get; set; }

        [JsonProperty("cep", NullValueHandling = NullValueHandling.Ignore)]
        public string Cep { get; set; }

        [JsonProperty("logradouro", NullValueHandling = NullValueHandling.Ignore)]
        public string Logradouro { get; set; }

        [JsonProperty("numero", NullValueHandling = NullValueHandling.Ignore)]
        public string Numero { get; set; }

        [JsonProperty("complemento", NullValueHandling = NullValueHandling.Ignore)]
        public string Complemento { get; set; }

        [JsonProperty("bairro", NullValueHandling = NullValueHandling.Ignore)]
        public string Bairro { get; set; }

        [JsonProperty("cidade", NullValueHandling = NullValueHandling.Ignore)]
        public string Cidade { get; set; }

        [JsonProperty("uf", NullValueHandling = NullValueHandling.Ignore)]
        public string Uf { get; set; }

        [JsonProperty("pais", NullValueHandling = NullValueHandling.Ignore)]
        public string Pais { get; set; }
    }
}

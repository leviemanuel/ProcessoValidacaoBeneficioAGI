using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class ProdutoResponse
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("mensagemInformativaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MensagemInformativaList { get; set; }

        [JsonProperty("erroList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ErroList { get; set; }

        [JsonProperty("avisoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AvisoList { get; set; }

        [JsonProperty("infoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> InfoList { get; set; }

        [JsonProperty("alertaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AlertaList { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("produto", NullValueHandling = NullValueHandling.Ignore)]
        public string Produto { get; set; }

        [JsonProperty("politicaMargemCodigo")]
        public long? PoliticaMargemCodigo { get; set; }

        [JsonProperty("politicaMargemNome", NullValueHandling = NullValueHandling.Ignore)]
        public string PoliticaMargemNome { get; set; }

        [JsonProperty("margemPropria")]
        public MargemPropria MargemPropria { get; set; }

        [JsonProperty("planoCodigo")]
        public string PlanoCodigo { get; set; }

        [JsonProperty("empresaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string EmpresaCodigo { get; set; }

        [JsonProperty("selecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selecionado { get; set; }

        [JsonProperty("permiteSerPreSelecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermiteSerPreSelecionado { get; set; }

        [JsonProperty("compartilhaMargem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CompartilhaMargem { get; set; }

        [JsonProperty("grupoProdutoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoProdutoCodigo { get; set; }

        [JsonProperty("grupoProdutoDescricao")]
        public string GrupoProdutoDescricao { get; set; }

        [JsonProperty("produtoMigracaoCEF", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProdutoMigracaoCef { get; set; }

        [JsonProperty("tipoProduto", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoProduto { get; set; }

        [JsonProperty("tipoSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoSimulacao { get; set; }

        [JsonProperty("creditoPessoalModel")]
        public CreditoPessoalModel CreditoPessoalModel { get; set; }

        [JsonProperty("cartaoModel")]
        public CartaoModel CartaoModel { get; set; }

        [JsonProperty("seguroModel")]
        public SeguroModel SeguroModel { get; set; }

        [JsonProperty("contaCorrenteModel")]
        public ContaCorrenteModel ContaCorrenteModel { get; set; }

        [JsonProperty("grupoProdutoCodigoCompartilhaMargemList")]
        public object GrupoProdutoCodigoCompartilhaMargemList { get; set; }

        [JsonProperty("produtoConfiguracaoCompartilhaMargemList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ProdutoConfiguracaoCompartilhaMargemList { get; set; }

        [JsonProperty("produtoConfiguracaoVinculadoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ProdutoConfiguracaoVinculadoList { get; set; }

        [JsonProperty("bancoOrigemList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> BancoOrigemList { get; set; }

        [JsonProperty("ordemApresentacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrdemApresentacao { get; set; }

        [JsonProperty("produtoConfiguracao", NullValueHandling = NullValueHandling.Ignore)]
        public ProdutoConfiguracao ProdutoConfiguracao { get; set; }

        [JsonProperty("exigeContaCredito", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeContaCredito { get; set; }

        [JsonProperty("refinLiquidacaoBanco", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RefinLiquidacaoBanco { get; set; }

        [JsonProperty("refinConsignadoRenovacao", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RefinConsignadoRenovacao { get; set; }

        [JsonProperty("refinDomicilioInad", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RefinDomicilioInad { get; set; }

        [JsonProperty("familiaDomicilio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FamiliaDomicilio { get; set; }

        [JsonProperty("familiaDomicilioAgibank", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FamiliaDomicilioAgibank { get; set; }

        [JsonProperty("familiaDomicilioSadAgibank", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FamiliaDomicilioSadAgibank { get; set; }

        [JsonProperty("familiaCorrentista", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FamiliaCorrentista { get; set; }

        [JsonProperty("bancoCredito")]
        public long? BancoCredito { get; set; }

        [JsonProperty("agenciaCredito")]
        public long? AgenciaCredito { get; set; }

        [JsonProperty("contaCredito")]
        public string ContaCredito { get; set; }

        [JsonProperty("tipoOperacaoCreditoCEFCodigo")]
        public object TipoOperacaoCreditoCefCodigo { get; set; }

        [JsonProperty("tipoContaCreditoCodigo")]
        public object TipoContaCreditoCodigo { get; set; }

        [JsonProperty("produtoConfiguracaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProdutoConfiguracaoCodigo { get; set; }

        [JsonProperty("parcelaAutomaticaAgendada")]
        public ParcelaAutomaticaAgendada ParcelaAutomaticaAgendada { get; set; }

        [JsonProperty("criaPropostaCredito", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CriaPropostaCredito { get; set; }

        [JsonProperty("obrigatoriedadeVenda", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ObrigatoriedadeVenda { get; set; }

        [JsonProperty("obrigatoriedadeOferta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ObrigatoriedadeOferta { get; set; }

        [JsonProperty("manterSalarioBancoAgiplan")]
        public object ManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("pagarCpAgibank", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PagarCpAgibank { get; set; }

        [JsonProperty("exibirManterSalarioBancoAgiplan", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExibirManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("exibirPagarCpAgibank", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExibirPagarCpAgibank { get; set; }

        [JsonProperty("parametroHabilitarManterSalarioBancoAgiplan", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ParametroHabilitarManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("habilitarManterSalarioBancoAgiplan", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HabilitarManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("identificadorSenhaCanais")]
        public object IdentificadorSenhaCanais { get; set; }

        [JsonProperty("contaAtributo")]
        public object ContaAtributo { get; set; }

        [JsonProperty("agenciaAgiplan")]
        public object AgenciaAgiplan { get; set; }

        [JsonProperty("bancoAgiplan")]
        public object BancoAgiplan { get; set; }

        [JsonProperty("exigeCartaoMultiplo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeCartaoMultiplo { get; set; }

        [JsonProperty("senha")]
        public object Senha { get; set; }

        [JsonProperty("confirmarSenha")]
        public object ConfirmarSenha { get; set; }

        [JsonProperty("exigeContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeContaCorrente { get; set; }

        [JsonProperty("exigeParecerContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeParecerContaCorrente { get; set; }

        [JsonProperty("aptoBiometria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AptoBiometria { get; set; }

        [JsonProperty("capturaBiometriaObrigatoria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CapturaBiometriaObrigatoria { get; set; }

        [JsonProperty("biometriaFacialBypass", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BiometriaFacialBypass { get; set; }

        [JsonProperty("porcentagemMaxAumentoRendaBruta")]
        public decimal? PorcentagemMaxAumentoRendaBruta { get; set; }

        [JsonProperty("porcentagemMaxReducaoRendaBruta")]
        public long? PorcentagemMaxReducaoRendaBruta { get; set; }

        [JsonProperty("mensagemBiometia", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> MensagemBiometia { get; set; }

        [JsonProperty("validarCallId", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarCallId { get; set; }

        [JsonProperty("manterDadosUltimaSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ManterDadosUltimaSimulacao { get; set; }

        [JsonProperty("permitePreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermitePreSaque { get; set; }

        [JsonProperty("clienteOptante")]
        public bool? ClienteOptante { get; set; }

        [JsonProperty("contaDebito")]
        public long? ContaDebito { get; set; }

        [JsonProperty("contaLiberacao")]
        public long? ContaLiberacao { get; set; }

        [JsonProperty("contaAverbacao")]
        public long? ContaAverbacao { get; set; }

        [JsonProperty("requerAutorizacaoDebito")]
        public bool? RequerAutorizacaoDebito { get; set; }

        [JsonProperty("dataLiberacao")]
        public DateTimeOffset? DataLiberacao { get; set; }

        [JsonProperty("tipoProdutoMotor")]
        public string TipoProdutoMotor { get; set; }

        [JsonProperty("produtoScore")]
        public object ProdutoScore { get; set; }

        [JsonProperty("segmentoProdutoCodigo")]
        public object SegmentoProdutoCodigo { get; set; }

        [JsonProperty("margemScr")]
        public decimal? MargemScr { get; set; }

        [JsonProperty("margemScrCP")]
        public long? MargemScrCp { get; set; }

        [JsonProperty("grupoRisco")]
        public object GrupoRisco { get; set; }

        [JsonProperty("tipoEntrega")]
        public object TipoEntrega { get; set; }

        [JsonProperty("idPrazoMotor")]
        public object IdPrazoMotor { get; set; }

        [JsonProperty("valorPercentualRendaBruta")]
        public decimal? ValorPercentualRendaBruta { get; set; }

        [JsonProperty("valorPercentualRendaLiquida")]
        public decimal? ValorPercentualRendaLiquida { get; set; }

        [JsonProperty("dataCessacaoMotor")]
        public object DataCessacaoMotor { get; set; }

        [JsonProperty("indiceTaxaMotor")]
        public object IndiceTaxaMotor { get; set; }

        [JsonProperty("reservaContratoNumero")]
        public object ReservaContratoNumero { get; set; }

        [JsonProperty("motorAutomaticApprove", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MotorAutomaticApprove { get; set; }

        [JsonProperty("documentosMotor")]
        public List<DocumentosMotor> DocumentosMotor { get; set; }

        [JsonProperty("valorDividaMotor")]
        public object ValorDividaMotor { get; set; }

        [JsonProperty("deveHabilitarTeimosinha")]
        public bool? DeveHabilitarTeimosinha { get; set; }

        [JsonProperty("mensagemBiometriaString", NullValueHandling = NullValueHandling.Ignore)]
        public string MensagemBiometriaString { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemDisponivel", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorMargemDisponivel { get; set; }

        [JsonProperty("produtoTeveContratoGerado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProdutoTeveContratoGerado { get; set; }

        [JsonProperty("validarPortabilidadeAtiva", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarPortabilidadeAtiva { get; set; }
    }

    public partial class ContaCorrenteModel
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("valorLimitePreAprovado", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorLimitePreAprovado { get; set; }

        [JsonProperty("valorMinimo")]
        public object ValorMinimo { get; set; }

        [JsonProperty("valorMaximo")]
        public object ValorMaximo { get; set; }

        [JsonProperty("mensagemPadrao")]
        public object MensagemPadrao { get; set; }

        [JsonProperty("mensagemPadraoMinimo")]
        public object MensagemPadraoMinimo { get; set; }

        [JsonProperty("mensagemPadraoMaximo")]
        public object MensagemPadraoMaximo { get; set; }

        [JsonProperty("valorMargemCompartilhada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCompartilhada { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemReservada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemReservada { get; set; }

        [JsonProperty("valorMargemDisponivel", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemDisponivel { get; set; }

        [JsonProperty("politicaMargemCodigo")]
        public object PoliticaMargemCodigo { get; set; }

        [JsonProperty("politicaMargemNome")]
        public object PoliticaMargemNome { get; set; }

        [JsonProperty("declaracaoFinsDeAberturaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeclaracaoFinsDeAberturaCodigo { get; set; }
    }

    public partial class AgrupadorPrazoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("descricao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }

        [JsonProperty("taxa", NullValueHandling = NullValueHandling.Ignore)]
        public long? Taxa { get; set; }

        [JsonProperty("indiceTaxaMotor")]
        public string IndiceTaxaMotor { get; set; }
    }

    public partial class Prazo
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("idPrazo")]
        public long? IdPrazo { get; set; }

        [JsonProperty("prazo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrazoPrazo { get; set; }

        [JsonProperty("valorParcela", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorParcela { get; set; }

        [JsonProperty("valorCredito", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCredito { get; set; }

        [JsonProperty("valorBruto", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorBruto { get; set; }

        [JsonProperty("valorLiquido", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorLiquido { get; set; }

        [JsonProperty("selecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selecionado { get; set; }

        [JsonProperty("valorAliquotaIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIof { get; set; }

        [JsonProperty("valorAliquotaIOFAdicional", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIofAdicional { get; set; }

        [JsonProperty("valorTaxaAnual", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTaxaAnual { get; set; }

        [JsonProperty("valorTaxaMensal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTaxaMensal { get; set; }

        [JsonProperty("valorCETAnual", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCetAnual { get; set; }

        [JsonProperty("valorCETMensal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCetMensal { get; set; }

        [JsonProperty("valorCoeficienteIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficienteIof { get; set; }

        [JsonProperty("valorCoeficientePMT", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficientePmt { get; set; }

        [JsonProperty("valorFinanciado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorFinanciado { get; set; }

        [JsonProperty("valorIOF", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorIof { get; set; }

        [JsonProperty("valorSeguroPrestamista", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSeguroPrestamista { get; set; }

        [JsonProperty("valorTC", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorTc { get; set; }

        [JsonProperty("valorTFC", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorTfc { get; set; }

        [JsonProperty("valorTarifas", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorTarifas { get; set; }

        [JsonProperty("percentualSeguroPrestamista")]
        public object PercentualSeguroPrestamista { get; set; }

        [JsonProperty("grupoApresentacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoApresentacao { get; set; }

        [JsonProperty("indiceTaxaMotor")]
        public string IndiceTaxaMotor { get; set; }

        [JsonProperty("prazoIdentificadorUnico", NullValueHandling = NullValueHandling.Ignore)]
        public string PrazoIdentificadorUnico { get; set; }

        [JsonProperty("valorDivida", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorDivida { get; set; }

        [JsonProperty("valorLiquidoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorLiquidoTotal { get; set; }
    }

    public partial class DocumentosMotor
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentosMotorId { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public partial class ParcelaAutomaticaAgendada
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("simulacao")]
        public object Simulacao { get; set; }

        [JsonProperty("disponivel", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disponivel { get; set; }

        [JsonProperty("mensagemDeErro")]
        public object MensagemDeErro { get; set; }

        [JsonProperty("opcaoDefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OpcaoDefault { get; set; }
    }

    public partial class Produto
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("empresaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string EmpresaCodigo { get; set; }

        [JsonProperty("produtoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string ProdutoCodigo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("ativaInternetBanking")]
        public string AtivaInternetBanking { get; set; }

        [JsonProperty("tipoOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoOperacao { get; set; }
    }
}

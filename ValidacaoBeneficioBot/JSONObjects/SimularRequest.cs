using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class SimularRequest
    {
        [JsonProperty("operacao")]
        public Operacao Operacao { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("valorCredito")]
        public long? ValorCredito { get; set; }

        [JsonProperty("valorParcela")]
        public long? ValorParcela { get; set; }

        [JsonProperty("manterSalarioContaAgiplan")]
        public object ManterSalarioContaAgiplan { get; set; }

        [JsonProperty("atualizandoAtendimentoTelefonico")]
        public bool? AtualizandoAtendimentoTelefonico { get; set; }

        [JsonProperty("atualizandoSimulacao")]
        public bool? AtualizandoSimulacao { get; set; }

        [JsonProperty("simularDemaisPrazos")]
        public bool? SimularDemaisPrazos { get; set; }
    }

    public partial class Operacao
    {
        [JsonProperty("atendimentoCodigo")]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo")]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("regraPagamentoCodigo")]
        public long? RegraPagamentoCodigo { get; set; }

        [JsonProperty("regraPagamentoNome")]
        public string RegraPagamentoNome { get; set; }

        [JsonProperty("domicilioEstadoUF")]
        public object DomicilioEstadoUf { get; set; }

        [JsonProperty("instituicaoCodigo")]
        public long? InstituicaoCodigo { get; set; }

        [JsonProperty("grupoInstituicaoCodigo")]
        public long? GrupoInstituicaoCodigo { get; set; }

        [JsonProperty("naturezaOcupacaoCodigo")]
        public object NaturezaOcupacaoCodigo { get; set; }

        [JsonProperty("situacaoFuncionalCodigo")]
        public object SituacaoFuncionalCodigo { get; set; }

        [JsonProperty("matricula")]
        public string Matricula { get; set; }

        [JsonProperty("dataPermanenciaOrgao")]
        public object DataPermanenciaOrgao { get; set; }

        [JsonProperty("bancoCodigo")]
        public string BancoCodigo { get; set; }

        [JsonProperty("numeroAgencia")]
        public object NumeroAgencia { get; set; }

        [JsonProperty("tipoOperacaoCEFCodigo")]
        public object TipoOperacaoCefCodigo { get; set; }

        [JsonProperty("numeroConta")]
        public object NumeroConta { get; set; }

        [JsonProperty("tipoContaCodigo")]
        public long? TipoContaCodigo { get; set; }

        [JsonProperty("valorRendaBruta")]
        public long? ValorRendaBruta { get; set; }

        [JsonProperty("valorRendaLiquida")]
        public double? ValorRendaLiquida { get; set; }

        [JsonProperty("valorTipoDespesa")]
        public double? ValorTipoDespesa { get; set; }

        [JsonProperty("valorTipoDespesaOriginal")]
        public double? ValorTipoDespesaOriginal { get; set; }

        [JsonProperty("naoPossuiTipoDespesa")]
        public bool? NaoPossuiTipoDespesa { get; set; }

        [JsonProperty("valorAditivoDesconto")]
        public object ValorAditivoDesconto { get; set; }

        [JsonProperty("valorAditivoDescontoOriginal")]
        public object ValorAditivoDescontoOriginal { get; set; }

        [JsonProperty("naoPossuiAditivoDesconto")]
        public bool? NaoPossuiAditivoDesconto { get; set; }

        [JsonProperty("naoPossuiProventosBeneficio")]
        public bool? NaoPossuiProventosBeneficio { get; set; }

        [JsonProperty("naoPossuiDebitosBeneficio")]
        public bool? NaoPossuiDebitosBeneficio { get; set; }

        [JsonProperty("naoPossuiEmprestimosBeneficio")]
        public bool? NaoPossuiEmprestimosBeneficio { get; set; }

        [JsonProperty("diaRecebimentoSalario")]
        public object DiaRecebimentoSalario { get; set; }

        [JsonProperty("alteracaoDadosCadastrais")]
        public bool? AlteracaoDadosCadastrais { get; set; }

        [JsonProperty("exibirEmModoSiape")]
        public bool? ExibirEmModoSiape { get; set; }

        [JsonProperty("upagSigla")]
        public object UpagSigla { get; set; }

        [JsonProperty("upagNome")]
        public object UpagNome { get; set; }

        [JsonProperty("upagCodigo")]
        public object UpagCodigo { get; set; }

        [JsonProperty("matriculaInstituidor")]
        public object MatriculaInstituidor { get; set; }

        [JsonProperty("informouRenda")]
        public bool? InformouRenda { get; set; }

        [JsonProperty("dataRecebimentoSalario")]
        public string DataRecebimentoSalario { get; set; }

        [JsonProperty("especieCodigo")]
        public long? EspecieCodigo { get; set; }

        [JsonProperty("especie")]
        public Especie Especie { get; set; }

        [JsonProperty("dataPermanenciaOrgaoObrigatoria")]
        public bool? DataPermanenciaOrgaoObrigatoria { get; set; }

        [JsonProperty("ehInstituicaoGrupoINSS")]
        public bool? EhInstituicaoGrupoInss { get; set; }

        [JsonProperty("ehInstituicaoGrupoSiape")]
        public bool? EhInstituicaoGrupoSiape { get; set; }

        [JsonProperty("maximoDiasContraCheque")]
        public long? MaximoDiasContraCheque { get; set; }

        [JsonProperty("maximoDiasDataFuturaContraCheque")]
        public long? MaximoDiasDataFuturaContraCheque { get; set; }

        [JsonProperty("meioPagamentoCodigo")]
        public int MeioPagamentoCodigo { get; set; }

        [JsonProperty("meioPagamentoSimulador")]
        public object MeioPagamentoSimulador { get; set; }

        [JsonProperty("possuiCartaoRMC")]
        public string PossuiCartaoRmc { get; set; }

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

        [JsonProperty("valorMargemConsignavel")]
        public object ValorMargemConsignavel { get; set; }

        [JsonProperty("valorMargemDisponivel")]
        public object ValorMargemDisponivel { get; set; }

        [JsonProperty("agenciaDV")]
        public object AgenciaDv { get; set; }

        [JsonProperty("bureauHigienizacaoCodigo")]
        public object BureauHigienizacaoCodigo { get; set; }

        [JsonProperty("matriculaMascara")]
        public string MatriculaMascara { get; set; }

        [JsonProperty("valorPrestacao")]
        public long? ValorPrestacao { get; set; }

        [JsonProperty("valorCompra")]
        public long? ValorCompra { get; set; }

        [JsonProperty("statusContaCorrente")]
        public object StatusContaCorrente { get; set; }

        [JsonProperty("bancoAgiplan")]
        public object BancoAgiplan { get; set; }

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

        [JsonProperty("agenciaNumero")]
        public object AgenciaNumero { get; set; }

        [JsonProperty("contaCredito")]
        public object ContaCredito { get; set; }

        [JsonProperty("tipoOperacaoCreditoCEFCodigo")]
        public object TipoOperacaoCreditoCefCodigo { get; set; }

        [JsonProperty("tipoContaCreditoCodigo")]
        public long? TipoContaCreditoCodigo { get; set; }

        [JsonProperty("tipoContaSalario")]
        public long? TipoContaSalario { get; set; }

        [JsonProperty("contaAtributo")]
        public object ContaAtributo { get; set; }

        [JsonProperty("usuarioOperacaoCodigo")]
        public long? UsuarioOperacaoCodigo { get; set; }

        [JsonProperty("declaracaoFinsDeAberturaCodigo")]
        public object DeclaracaoFinsDeAberturaCodigo { get; set; }

        [JsonProperty("idConta")]
        public object IdConta { get; set; }

        [JsonProperty("idCartao")]
        public object IdCartao { get; set; }

        [JsonProperty("valorAutorizacaoDebitoCp")]
        public object ValorAutorizacaoDebitoCp { get; set; }

        [JsonProperty("valorAutorizacaoDebitoSeguro")]
        public object ValorAutorizacaoDebitoSeguro { get; set; }

        [JsonProperty("bancoAverbacao")]
        public object BancoAverbacao { get; set; }

        [JsonProperty("agenciaAverbacao")]
        public object AgenciaAverbacao { get; set; }

        [JsonProperty("tipoOperacaoCefAverbacaoCodigo")]
        public object TipoOperacaoCefAverbacaoCodigo { get; set; }

        [JsonProperty("contaAverbacao")]
        public object ContaAverbacao { get; set; }

        [JsonProperty("tipoContaAverbacaoCodigo")]
        public long? TipoContaAverbacaoCodigo { get; set; }

        [JsonProperty("clienteDomiciliado")]
        public object ClienteDomiciliado { get; set; }

        [JsonProperty("dataCessacaoBeneficio")]
        public object DataCessacaoBeneficio { get; set; }

        [JsonProperty("rendaEstimada")]
        public object RendaEstimada { get; set; }

        [JsonProperty("diaPagamentoCalculado")]
        public bool? DiaPagamentoCalculado { get; set; }

        [JsonProperty("anoExpedicaoBeneficio")]
        public long? AnoExpedicaoBeneficio { get; set; }

        [JsonProperty("manterSalarioBancoAgiplan")]
        public object ManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("bancoNumeroSimulador")]
        public object BancoNumeroSimulador { get; set; }

        [JsonProperty("atendimentoSimulador")]
        public bool? AtendimentoSimulador { get; set; }

        [JsonProperty("dadosAverbacaoOrigemMotor")]
        public bool? DadosAverbacaoOrigemMotor { get; set; }

        [JsonProperty("dataCessacaoMotor")]
        public string DataCessacaoMotor { get; set; }

        [JsonProperty("dataHoraOperacao")]
        public string DataHoraOperacao { get; set; }

        [JsonProperty("especieValor")]
        public int? EspecieValor { get; set; }

        [JsonProperty("operacaoSimulador")]
        public bool? OperacaoSimulador { get; set; }

        [JsonProperty("pagarCpAgibank")]
        public bool? PagarCpAgibank { get; set; }

        [JsonProperty("possuiAditivoDesconto")]
        public bool? PossuiAditivoDesconto { get; set; }
    }

    public partial class Especie
    {
        [JsonProperty("especieCodigo")]
        public long? EspecieCodigo { get; set; }

        [JsonProperty("especieValor")]
        public long? EspecieValor { get; set; }

        [JsonProperty("especieNome")]
        public string EspecieNome { get; set; }

        [JsonProperty("tipoEspecieNome")]
        public string TipoEspecieNome { get; set; }

        [JsonProperty("especieSituacao")]
        public long? EspecieSituacao { get; set; }

        [JsonProperty("tipoEspecieSituacao")]
        public long? TipoEspecieSituacao { get; set; }

        [JsonProperty("especieConsignado")]
        public string EspecieConsignado { get; set; }

        [JsonProperty("especieDomicilio")]
        public string EspecieDomicilio { get; set; }

        [JsonProperty("especieAgidebito")]
        public string EspecieAgidebito { get; set; }

        [JsonProperty("tipoEspeciePrazoPermanencia")]
        public string TipoEspeciePrazoPermanencia { get; set; }

        [JsonProperty("tipoEspecieDecimoTerceiro")]
        public string TipoEspecieDecimoTerceiro { get; set; }

        [JsonProperty("tipoEspecieCodigo")]
        public long? TipoEspecieCodigo { get; set; }

        [JsonProperty("valorFormatadoSicred")]
        public string ValorFormatadoSicred { get; set; }

        [JsonProperty("dataPermanenciaOrgaoObrigatoria")]
        public bool? DataPermanenciaOrgaoObrigatoria { get; set; }
    }
}



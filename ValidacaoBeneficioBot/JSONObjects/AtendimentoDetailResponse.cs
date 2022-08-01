using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class AtendimentoDetailResponse
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoMidiaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<TipoMidiaList> TipoMidiaList { get; set; }

        [JsonProperty("tipoTelefone", NullValueHandling = NullValueHandling.Ignore)]
        public List<TipoTelefoneElement> TipoTelefone { get; set; }

        [JsonProperty("ddDs", NullValueHandling = NullValueHandling.Ignore)]
        public List<DdD> DdDs { get; set; }

        [JsonProperty("naturezaOcupacaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<NaturezaOcupacaoList> NaturezaOcupacaoList { get; set; }

        [JsonProperty("situacaoFuncionalList", NullValueHandling = NullValueHandling.Ignore)]
        public List<SituacaoFuncionalList> SituacaoFuncionalList { get; set; }

        [JsonProperty("bancoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<BancoOList> BancoList { get; set; }

        [JsonProperty("bancoDestinoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<BancoOList> BancoDestinoList { get; set; }

        [JsonProperty("tipoOperacaoCEFList", NullValueHandling = NullValueHandling.Ignore)]
        public List<TipoOperacaoCefList> TipoOperacaoCefList { get; set; }

        [JsonProperty("tipoContaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<TipoContaList> TipoContaList { get; set; }

        [JsonProperty("estadoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<EstadoListElement> EstadoList { get; set; }

        //[JsonProperty("tipoLogradouroList", NullValueHandling = NullValueHandling.Ignore)]
        //public List<TipoLogradouroList> TipoLogradouroList { get; set; }

        //[JsonProperty("tipoResidenciaList", NullValueHandling = NullValueHandling.Ignore)]
        //public List<TipoResidenciaList> TipoResidenciaList { get; set; }

        [JsonProperty("meioPagamentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<EstadoListElement> MeioPagamentoList { get; set; }

        [JsonProperty("possuiCartaoRMCList", NullValueHandling = NullValueHandling.Ignore)]
        public List<EstadoListElement> PossuiCartaoRmcList { get; set; }

        [JsonProperty("generoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> GeneroList { get; set; }

        [JsonProperty("cidadeList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> CidadeList { get; set; }

        [JsonProperty("ramoAtividadeList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> RamoAtividadeList { get; set; }

        [JsonProperty("atendimentoModel", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoModel AtendimentoModel { get; set; }

        [JsonProperty("grupoPerfilConfiguracao", NullValueHandling = NullValueHandling.Ignore)]
        public GrupoPerfilConfiguracao GrupoPerfilConfiguracao { get; set; }

        [JsonProperty("tipoDocumentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> TipoDocumentoList { get; set; }

        [JsonProperty("orgaoExpedidorList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> OrgaoExpedidorList { get; set; }

        [JsonProperty("nacionalidadeList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> NacionalidadeList { get; set; }

        [JsonProperty("profissaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> ProfissaoList { get; set; }

        [JsonProperty("patrimonioList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> PatrimonioList { get; set; }

        [JsonProperty("declaracaoFinsDeAberturaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> DeclaracaoFinsDeAberturaList { get; set; }

        [JsonProperty("estadoCivilList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> EstadoCivilList { get; set; }

        [JsonProperty("simNaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<SimNaoList> SimNaoList { get; set; }

        [JsonProperty("escolaridadeList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> EscolaridadeList { get; set; }

        [JsonProperty("grauRelacionamentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> GrauRelacionamentoList { get; set; }

        [JsonProperty("documentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DocumentoList { get; set; }

        [JsonProperty("dadosOcrList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DadosOcrList { get; set; }

        [JsonProperty("documentoPendenteList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DocumentoPendenteList { get; set; }

        [JsonProperty("tipoDocumentoDigitalizacaoDesvinculadoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> TipoDocumentoDigitalizacaoDesvinculadoList { get; set; }

        [JsonProperty("documentosViewModel", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentosViewModel DocumentosViewModel { get; set; }

        [JsonProperty("tipoEntregaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeclaracaoFinsDeAberturaListElement> TipoEntregaList { get; set; }

        [JsonProperty("pontoPermiteCriacaoContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PontoPermiteCriacaoContaCorrente { get; set; }

        [JsonProperty("habilitaOCR", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HabilitaOcr { get; set; }

        [JsonProperty("btnCriarContaCorrenteEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BtnCriarContaCorrenteEnabled { get; set; }

        [JsonProperty("tamanhoMaximoArquivoUpload", NullValueHandling = NullValueHandling.Ignore)]
        public long? TamanhoMaximoArquivoUpload { get; set; }

        [JsonProperty("statusBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public long? StatusBiometriaFacial { get; set; }

        [JsonProperty("webSocketUrl")]
        public object WebSocketUrl { get; set; }

        [JsonProperty("webSocketHub")]
        public object WebSocketHub { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("warning")]
        public object Warning { get; set; }

        [JsonProperty("servicoOcrUrlDisponivel")]
        public object ServicoOcrUrlDisponivel { get; set; }

        [JsonProperty("servicoOcrUrlInsereDocumento")]
        public object ServicoOcrUrlInsereDocumento { get; set; }

        [JsonProperty("mostrarBotaoGerarProposta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MostrarBotaoGerarProposta { get; set; }

        [JsonProperty("contaAtributoObrigatorio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ContaAtributoObrigatorio { get; set; }

        [JsonProperty("nomeFilaRetornoResultadoDatacap")]
        public object NomeFilaRetornoResultadoDatacap { get; set; }

        [JsonProperty("timeoutProcessamentoOcr", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeoutProcessamentoOcr { get; set; }

        [JsonProperty("enviarEcm", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnviarEcm { get; set; }

        [JsonProperty("acuracidadeMinimaServicoOcr", NullValueHandling = NullValueHandling.Ignore)]
        public long? AcuracidadeMinimaServicoOcr { get; set; }

        [JsonProperty("temContratoAtivo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TemContratoAtivo { get; set; }

        [JsonProperty("exibirCapturaDocumentosQrCode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExibirCapturaDocumentosQrCode { get; set; }

        [JsonProperty("bancosOptantes", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> BancosOptantes { get; set; }

        [JsonProperty("valorSimulacaoAutomatica", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSimulacaoAutomatica { get; set; }
    }

    public partial class AtendimentoModel
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimento", NullValueHandling = NullValueHandling.Ignore)]
        public Atendimento Atendimento { get; set; }

        [JsonProperty("cadastro", NullValueHandling = NullValueHandling.Ignore)]
        public Cadastro Cadastro { get; set; }

        [JsonProperty("atendimentoOperacaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoModelAtendimentoOperacaoList> AtendimentoOperacaoList { get; set; }

        [JsonProperty("atendimentoDocumentoList")]
        public object AtendimentoDocumentoList { get; set; }

        [JsonProperty("pesquisaMidiaBloqueada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PesquisaMidiaBloqueada { get; set; }

        [JsonProperty("mostrarEnderecoProspeccao", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MostrarEnderecoProspeccao { get; set; }

        [JsonProperty("possuiConta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PossuiConta { get; set; }

        [JsonProperty("bloquearEdicaoDeDados", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BloquearEdicaoDeDados { get; set; }

        [JsonProperty("possuiSolicitacaoPortabilidadeCip")]
        public object PossuiSolicitacaoPortabilidadeCip { get; set; }

        [JsonProperty("clienteContaCorrente")]
        public object ClienteContaCorrente { get; set; }

        [JsonProperty("atendimentoFinalizado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AtendimentoFinalizado { get; set; }

        [JsonProperty("produtoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<ProdutoList> ProdutoList { get; set; }
    }

    public partial class Atendimento
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("dataHoraInicio", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraInicio { get; set; }

        [JsonProperty("dataHoraFim")]
        public object DataHoraFim { get; set; }

        [JsonProperty("tipoAtendimento", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoAtendimento { get; set; }

        [JsonProperty("origemAtendimento", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrigemAtendimento { get; set; }

        [JsonProperty("clienteNovo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClienteNovo { get; set; }

        [JsonProperty("baseDistribuicaoCodigo")]
        public object BaseDistribuicaoCodigo { get; set; }

        [JsonProperty("baseDistribuicaoDescricao")]
        public object BaseDistribuicaoDescricao { get; set; }

        [JsonProperty("baseDistribuicaoMensagem")]
        public object BaseDistribuicaoMensagem { get; set; }

        [JsonProperty("agendamentoCodigo")]
        public object AgendamentoCodigo { get; set; }

        [JsonProperty("usuarioCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsuarioCodigo { get; set; }

        [JsonProperty("usuarioRegionalCodigo")]
        public object UsuarioRegionalCodigo { get; set; }

        [JsonProperty("usuarioGerenteCodigo")]
        public object UsuarioGerenteCodigo { get; set; }

        [JsonProperty("usuarioSupervisorCodigo")]
        public object UsuarioSupervisorCodigo { get; set; }

        [JsonProperty("usuarioVendedorCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsuarioVendedorCodigo { get; set; }

        [JsonProperty("pontoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PontoCodigo { get; set; }

        [JsonProperty("pontoSuperiorCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PontoSuperiorCodigo { get; set; }

        [JsonProperty("plataformaPontoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlataformaPontoCodigo { get; set; }

        [JsonProperty("usuarioRepresentanteFilialCodigo")]
        public object UsuarioRepresentanteFilialCodigo { get; set; }

        [JsonProperty("usuarioRepresentanteCodigo")]
        public object UsuarioRepresentanteCodigo { get; set; }

        [JsonProperty("regiaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegiaoCodigo { get; set; }

        [JsonProperty("estadoUF", NullValueHandling = NullValueHandling.Ignore)]
        public string EstadoUf { get; set; }

        [JsonProperty("cidadeCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? CidadeCodigo { get; set; }

        [JsonProperty("tipoPonto", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoPonto { get; set; }

        [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? Situacao { get; set; }

        [JsonProperty("origemCaptura", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrigemCaptura { get; set; }

        [JsonProperty("usuario", NullValueHandling = NullValueHandling.Ignore)]
        public Usuario Usuario { get; set; }

        [JsonProperty("ponto")]
        public object Ponto { get; set; }

        [JsonProperty("plataformaPonto")]
        public object PlataformaPonto { get; set; }

        [JsonProperty("agendamentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AgendamentoList { get; set; }

        [JsonProperty("atendimentoOcorrenciaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOcorrenciaList { get; set; }

        [JsonProperty("atendimentoClienteList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoClienteList> AtendimentoClienteList { get; set; }

        [JsonProperty("pesquisaMidiaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> PesquisaMidiaList { get; set; }

        [JsonProperty("atendimentoMovimentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoMovimentoList> AtendimentoMovimentoList { get; set; }

        [JsonProperty("atendimentoOperacaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoAtendimentoOperacaoList> AtendimentoOperacaoList { get; set; }

        [JsonProperty("atendimentoDocumentoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoDocumentoList { get; set; }

        [JsonProperty("atendimentoCobrancaAviso")]
        public object AtendimentoCobrancaAviso { get; set; }

        [JsonProperty("atendimentoPropostaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoPropostaList { get; set; }

        [JsonProperty("atendimentoAceiteDigitalList")]
        public object AtendimentoAceiteDigitalList { get; set; }

        [JsonProperty("atendimentoEnvioChecklistList")]
        public object AtendimentoEnvioChecklistList { get; set; }

        [JsonProperty("base")]
        public object Base { get; set; }

        [JsonProperty("distribuicaoLogList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DistribuicaoLogList { get; set; }

        [JsonProperty("atendimentoCobrancaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoCobrancaList { get; set; }

        [JsonProperty("atendimentoDadosRetornoOcrList")]
        public object AtendimentoDadosRetornoOcrList { get; set; }

        [JsonProperty("fichaClienteCodigo")]
        public object FichaClienteCodigo { get; set; }

        [JsonProperty("origemP2a", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OrigemP2A { get; set; }

        [JsonProperty("possuiSolicitacaoPortabilidadeCip")]
        public object PossuiSolicitacaoPortabilidadeCip { get; set; }

        [JsonProperty("temSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TemSimulacao { get; set; }

        [JsonProperty("callId")]
        public object CallId { get; set; }

        [JsonProperty("resimular", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Resimular { get; set; }

        [JsonProperty("atendimentoSimulador", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AtendimentoSimulador { get; set; }

        [JsonProperty("autorizaConsultaDataPrev", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutorizaConsultaDataPrev { get; set; }

        [JsonProperty("processoAprovacaoAutomaticaCodigo")]
        public object ProcessoAprovacaoAutomaticaCodigo { get; set; }

        [JsonProperty("checklistDigitalCodigo")]
        public object ChecklistDigitalCodigo { get; set; }

        [JsonProperty("identificadorGravacao")]
        public object IdentificadorGravacao { get; set; }

        [JsonProperty("removeuCheckListSupervisor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RemoveuCheckListSupervisor { get; set; }

        [JsonProperty("tipoAceiteDigital")]
        public object TipoAceiteDigital { get; set; }

        [JsonProperty("deveDisponibilizarChecklistDigital", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeveDisponibilizarChecklistDigital { get; set; }

        [JsonProperty("aptoContratacaoDigitalViaBiometria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AptoContratacaoDigitalViaBiometria { get; set; }

        [JsonProperty("checklistCorretivoCodigo")]
        public object ChecklistCorretivoCodigo { get; set; }

        [JsonProperty("dataNascimentoConsultada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DataNascimentoConsultada { get; set; }

        [JsonProperty("rendaCalculadaSimulador", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RendaCalculadaSimulador { get; set; }
    }

    public partial class AtendimentoClienteList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

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

        [JsonProperty("mensagemRestritividade", NullValueHandling = NullValueHandling.Ignore)]
        public string MensagemRestritividade { get; set; }

        [JsonProperty("erroHistoricoContrato")]
        public object ErroHistoricoContrato { get; set; }

        [JsonProperty("peso", NullValueHandling = NullValueHandling.Ignore)]
        public long? Peso { get; set; }

        [JsonProperty("altura", NullValueHandling = NullValueHandling.Ignore)]
        public long? Altura { get; set; }

        [JsonProperty("tipoDocumentoCodigo")]
        public object TipoDocumentoCodigo { get; set; }

        [JsonProperty("documentoIdentificacao")]
        public object DocumentoIdentificacao { get; set; }

        [JsonProperty("orgaoExpedidorCodigo")]
        public object OrgaoExpedidorCodigo { get; set; }

        [JsonProperty("ufExpedicao")]
        public object UfExpedicao { get; set; }

        [JsonProperty("dataExpedicao")]
        public object DataExpedicao { get; set; }

        [JsonProperty("dataExpedicaoString", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("envioEmailRestricaoBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnvioEmailRestricaoBiometriaFacial { get; set; }

        [JsonProperty("divergenciaBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DivergenciaBiometriaFacial { get; set; }

        [JsonProperty("indisponibilidadeBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IndisponibilidadeBiometriaFacial { get; set; }

        [JsonProperty("statusBiometriaFacial", NullValueHandling = NullValueHandling.Ignore)]
        public long? StatusBiometriaFacial { get; set; }

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

        [JsonProperty("dataNascimentoDataPrev", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataNascimentoDataPrev { get; set; }

        [JsonProperty("erroList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ErroList { get; set; }

        //[JsonProperty("enderecoResidencial", NullValueHandling = NullValueHandling.Ignore)]
        //public EnderecoResidencial EnderecoResidencial { get; set; }

        [JsonProperty("enderecoProspeccao")]
        public object EnderecoProspeccao { get; set; }

        [JsonProperty("referenciaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ReferenciaList { get; set; }

        [JsonProperty("contratoHistoricoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ContratoHistoricoList { get; set; }

        [JsonProperty("atendimentoClienteEmailList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoClienteEmailList { get; set; }

        //[JsonProperty("atendimentoClienteEnderecoList", NullValueHandling = NullValueHandling.Ignore)]
        //public List<EnderecoResidencial> AtendimentoClienteEnderecoList { get; set; }

        //[JsonProperty("atendimentoClienteTelefoneList", NullValueHandling = NullValueHandling.Ignore)]
        //public List<AtendimentoClienteTelefoneList> AtendimentoClienteTelefoneList { get; set; }

        //[JsonProperty("atendimentoClienteReferenciaList", NullValueHandling = NullValueHandling.Ignore)]
        //public List<ReferenciaList> AtendimentoClienteReferenciaList { get; set; }

        [JsonProperty("atendimentoClienteTestemunhaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoClienteTestemunhaList { get; set; }

        [JsonProperty("clienteContaCorrente")]
        public object ClienteContaCorrente { get; set; }

        [JsonProperty("possuiContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PossuiContaCorrente { get; set; }
    }

    public partial class EnderecoResidencial
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoClienteEnderecoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteEnderecoCodigo { get; set; }

        [JsonProperty("atendimentoClienteCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteCodigo { get; set; }

        [JsonProperty("cep", NullValueHandling = NullValueHandling.Ignore)]

        public long? Cep { get; set; }

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

        [JsonProperty("semNumero", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SemNumero { get; set; }

        [JsonProperty("complemento")]
        public object Complemento { get; set; }

        [JsonProperty("tipoResidenciaCodigo")]
        public object TipoResidenciaCodigo { get; set; }

        [JsonProperty("valorParcelaFinanciamento")]
        public object ValorParcelaFinanciamento { get; set; }

        [JsonProperty("valorParcelaFinanciamentoString", NullValueHandling = NullValueHandling.Ignore)]
        public string ValorParcelaFinanciamentoString { get; set; }

        [JsonProperty("tipoEndereco", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoEndereco { get; set; }

        //[JsonProperty("atendimentoCliente")]
        //public AtendimentoClass AtendimentoCliente { get; set; }

        [JsonProperty("temDados", NullValueHandling = NullValueHandling.Ignore)]
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

    public partial class AtendimentoClass
    {
        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore)]

        public string Ref { get; set; }
    }

    public partial class ReferenciaList
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
        public string Numero { get; set; }

        [JsonProperty("atendimentoCliente", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass AtendimentoCliente { get; set; }

        [JsonProperty("identificador", NullValueHandling = NullValueHandling.Ignore)]
        public string Identificador { get; set; }

        [JsonProperty("tittle", NullValueHandling = NullValueHandling.Ignore)]
        public string Tittle { get; set; }
    }

    public partial class AtendimentoClienteTelefoneList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoClienteTelefoneCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteTelefoneCodigo { get; set; }

        [JsonProperty("atendimentoClienteCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoClienteCodigo { get; set; }

        [JsonProperty("tipoTelefoneCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoTelefoneCodigo { get; set; }

        [JsonProperty("ddd", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ddd { get; set; }

        [JsonProperty("numero", NullValueHandling = NullValueHandling.Ignore)]
        public long? Numero { get; set; }

        [JsonProperty("ramal")]
        public object Ramal { get; set; }

        [JsonProperty("classificacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? Classificacao { get; set; }

        [JsonProperty("ativo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ativo { get; set; }

        [JsonProperty("tipoTelefone", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClienteTelefoneListTipoTelefone TipoTelefone { get; set; }

        [JsonProperty("atendimentoCliente", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass AtendimentoCliente { get; set; }

        [JsonProperty("principal", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Principal { get; set; }

        [JsonProperty("origem")]
        public long? Origem { get; set; }

        [JsonProperty("restricaoCodigo")]
        public object RestricaoCodigo { get; set; }

        [JsonProperty("oculto", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Oculto { get; set; }

        [JsonProperty("statusValidacao")]
        public long? StatusValidacao { get; set; }

        [JsonProperty("dataHoraAtualizacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraAtualizacao { get; set; }
    }

    public partial class AtendimentoClienteTelefoneListTipoTelefone
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoTelefoneCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoTelefoneCodigo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? Situacao { get; set; }

        [JsonProperty("validar", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Validar { get; set; }

        [JsonProperty("telefoneFaixaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> TelefoneFaixaList { get; set; }

        [JsonProperty("dataCriacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataCriacao { get; set; }

        [JsonProperty("dataAtualizacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataAtualizacao { get; set; }

        [JsonProperty("usuarioProprietario", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsuarioProprietario { get; set; }

        [JsonProperty("grupoProprietario", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoProprietario { get; set; }
    }

    public partial class AtendimentoMovimentoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoMovimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoMovimentoCodigo { get; set; }

        [JsonProperty("atendimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("etapa", NullValueHandling = NullValueHandling.Ignore)]
        public long? Etapa { get; set; }

        [JsonProperty("confirmado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Confirmado { get; set; }

        [JsonProperty("dataHoraMovimento", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraMovimento { get; set; }

        [JsonProperty("atendimento", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass Atendimento { get; set; }
    }

    public partial class AtendimentoAtendimentoOperacaoList
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

        public long? BancoCodigo { get; set; }

        [JsonProperty("agenciaNumero", NullValueHandling = NullValueHandling.Ignore)]

        public long? AgenciaNumero { get; set; }

        [JsonProperty("tipoCodigoOperacaoCEFCodigo")]
        public object TipoCodigoOperacaoCefCodigo { get; set; }

        [JsonProperty("contaNumero", NullValueHandling = NullValueHandling.Ignore)]
        public string ContaNumero { get; set; }

        [JsonProperty("tipoContaCodigo")]
        public object TipoContaCodigo { get; set; }

        [JsonProperty("valorRendaBruta", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorRendaBruta { get; set; }

        [JsonProperty("valorRendaLiquida", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorRendaLiquida { get; set; }

        [JsonProperty("rendaEstimada")]
        public object RendaEstimada { get; set; }

        [JsonProperty("diaPagamentoCalculado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DiaPagamentoCalculado { get; set; }

        [JsonProperty("valorTipoDespesa")]
        public object ValorTipoDespesa { get; set; }

        [JsonProperty("valorTipoDespesaOriginal")]
        public object ValorTipoDespesaOriginal { get; set; }

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

        [JsonProperty("possivelRMC", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PossivelRmc { get; set; }

        [JsonProperty("meioPagamentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeioPagamentoCodigo { get; set; }

        [JsonProperty("meioPagamentoSimulador", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeioPagamentoSimulador { get; set; }

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

        [JsonProperty("valorCompra", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCompra { get; set; }

        [JsonProperty("valorPrestacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorPrestacao { get; set; }

        [JsonProperty("statusContaCorrente")]
        public object StatusContaCorrente { get; set; }

        [JsonProperty("renovacaoAutomatica", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RenovacaoAutomatica { get; set; }

        [JsonProperty("domicilioEstadoUF", NullValueHandling = NullValueHandling.Ignore)]
        public string DomicilioEstadoUf { get; set; }

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

        [JsonProperty("margemDataPrev", NullValueHandling = NullValueHandling.Ignore)]
        public double? MargemDataPrev { get; set; }

        [JsonProperty("margemCartaoDataPrev", NullValueHandling = NullValueHandling.Ignore)]
        public long? MargemCartaoDataPrev { get; set; }

        [JsonProperty("bancoAverbacao", NullValueHandling = NullValueHandling.Ignore)]

        public long? BancoAverbacao { get; set; }

        [JsonProperty("agenciaAverbacao", NullValueHandling = NullValueHandling.Ignore)]

        public long? AgenciaAverbacao { get; set; }

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

        [JsonProperty("bancoNumeroSimulador", NullValueHandling = NullValueHandling.Ignore)]

        public long? BancoNumeroSimulador { get; set; }

        [JsonProperty("atendimento")]
        public object Atendimento { get; set; }

        [JsonProperty("regraPagamento", NullValueHandling = NullValueHandling.Ignore)]
        public RegraPagamento RegraPagamento { get; set; }

        [JsonProperty("banco")]
        public object Banco { get; set; }

        [JsonProperty("especie", NullValueHandling = NullValueHandling.Ignore)]
        public PurpleEspecie Especie { get; set; }

        [JsonProperty("atendimentoOperacaoAditivoDescontoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoAditivoDescontoList { get; set; }

        [JsonProperty("atendimentoOperacaoTipoDespesaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoTipoDespesaList { get; set; }

        [JsonProperty("atendimentoOperacaoRefinContratoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoRefinContratoList { get; set; }

        [JsonProperty("atendimentoOperacaoParcelaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoParcelaList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCPList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoOperacaoSimulacaoCpList> AtendimentoOperacaoSimulacaoCpList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCartaoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoOperacaoSimulacaoCartaoList> AtendimentoOperacaoSimulacaoCartaoList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoSeguroList", NullValueHandling = NullValueHandling.Ignore)]
        public List<AtendimentoOperacaoSimulacaoSeguroList> AtendimentoOperacaoSimulacaoSeguroList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoContaCorrenteList")]
        public object AtendimentoOperacaoSimulacaoContaCorrenteList { get; set; }

        [JsonProperty("clienteDomiciliado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClienteDomiciliado { get; set; }

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
        public object PossuiCartaoRmc { get; set; }

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

    public partial class AtendimentoOperacaoSimulacaoCartaoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCartaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoSimulacaoCartaoCodigo { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("dataHoraSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraSimulacao { get; set; }

        [JsonProperty("grupoProdutoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoProdutoCodigo { get; set; }

        [JsonProperty("empresa", NullValueHandling = NullValueHandling.Ignore)]
        public string Empresa { get; set; }

        [JsonProperty("produto", NullValueHandling = NullValueHandling.Ignore)]
        public string Produto { get; set; }

        [JsonProperty("produtoSelecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProdutoSelecionado { get; set; }

        [JsonProperty("tipoSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoSimulacao { get; set; }

        [JsonProperty("politicaMargemCodigo")]
        public object PoliticaMargemCodigo { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemCompartilhada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCompartilhada { get; set; }

        [JsonProperty("valorLimiteCalculado", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorLimiteCalculado { get; set; }

        [JsonProperty("plano", NullValueHandling = NullValueHandling.Ignore)]
        public string Plano { get; set; }

        [JsonProperty("contratarPreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ContratarPreSaque { get; set; }

        [JsonProperty("percentualPreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public long? PercentualPreSaque { get; set; }

        [JsonProperty("valorDisponivelPreSaque")]
        public object ValorDisponivelPreSaque { get; set; }

        [JsonProperty("valorSolicitadoPreSaque")]
        public object ValorSolicitadoPreSaque { get; set; }

        [JsonProperty("produtoConfiguracaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProdutoConfiguracaoCodigo { get; set; }

        [JsonProperty("atendimentoOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass AtendimentoOperacao { get; set; }

        [JsonProperty("clienteOptante")]
        public object ClienteOptante { get; set; }

        [JsonProperty("contaDebito")]
        public object ContaDebito { get; set; }

        [JsonProperty("contaLiberacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaLiberacao { get; set; }

        [JsonProperty("contaAverbacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaAverbacao { get; set; }

        [JsonProperty("requerAutorizacaoDebito")]
        public object RequerAutorizacaoDebito { get; set; }

        [JsonProperty("tipoProdutoMotor")]
        public object TipoProdutoMotor { get; set; }

        [JsonProperty("produtoScore")]
        public object ProdutoScore { get; set; }

        [JsonProperty("multiplicadorLimite")]
        public object MultiplicadorLimite { get; set; }

        [JsonProperty("segmentoProdutoCodigo")]
        public object SegmentoProdutoCodigo { get; set; }

        [JsonProperty("atualizarTipoVinculoConta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AtualizarTipoVinculoConta { get; set; }

        [JsonProperty("tipoEntrega")]
        public object TipoEntrega { get; set; }

        [JsonProperty("reservaContratoNumero", NullValueHandling = NullValueHandling.Ignore)]
        public string ReservaContratoNumero { get; set; }

        [JsonProperty("requerLimiteSadMotor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequerLimiteSadMotor { get; set; }

        [JsonProperty("deveHabilitarTeimosinha")]
        public object DeveHabilitarTeimosinha { get; set; }
    }

    public partial class AtendimentoOperacaoSimulacaoCpList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCPCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoSimulacaoCpCodigo { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("dataHoraSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraSimulacao { get; set; }

        [JsonProperty("grupoProdutoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoProdutoCodigo { get; set; }

        [JsonProperty("empresa", NullValueHandling = NullValueHandling.Ignore)]
        public string Empresa { get; set; }

        [JsonProperty("produto", NullValueHandling = NullValueHandling.Ignore)]
        public string Produto { get; set; }

        [JsonProperty("produtoSelecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProdutoSelecionado { get; set; }

        [JsonProperty("tipoSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoSimulacao { get; set; }

        [JsonProperty("valorMaximo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValorMaximo { get; set; }

        [JsonProperty("politicaMargemCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PoliticaMargemCodigo { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemCompartilhada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCompartilhada { get; set; }

        [JsonProperty("dataLiberacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataLiberacao { get; set; }

        [JsonProperty("dataCorte", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataCorte { get; set; }

        [JsonProperty("quantidadeDiasCarencia", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantidadeDiasCarencia { get; set; }

        [JsonProperty("dataPrimeiroVencimento", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataPrimeiroVencimento { get; set; }

        [JsonProperty("plano", NullValueHandling = NullValueHandling.Ignore)]

        public long? Plano { get; set; }

        [JsonProperty("prazo", NullValueHandling = NullValueHandling.Ignore)]

        public long? Prazo { get; set; }

        [JsonProperty("valorCompra", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCompra { get; set; }

        [JsonProperty("valorPrestacao", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorPrestacao { get; set; }

        [JsonProperty("valorFinanciado", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorFinanciado { get; set; }

        [JsonProperty("valorCoeficientePMT", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficientePmt { get; set; }

        [JsonProperty("valorTaxaMensal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorTaxaMensal { get; set; }

        [JsonProperty("valorTaxaAnual", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorTaxaAnual { get; set; }

        [JsonProperty("valorCETMensal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCetMensal { get; set; }

        [JsonProperty("valorCETAnual", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCetAnual { get; set; }

        [JsonProperty("valorCoeficienteIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficienteIof { get; set; }

        [JsonProperty("valorAliquotaIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIof { get; set; }

        [JsonProperty("valorAliquotaIOFAdicional", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIofAdicional { get; set; }

        [JsonProperty("valorIOF", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorIof { get; set; }

        [JsonProperty("valorTC", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorTc { get; set; }

        [JsonProperty("valorLiquido", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorLiquido { get; set; }

        [JsonProperty("valorTFC", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorTfc { get; set; }

        [JsonProperty("valorTarifas", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorTarifas { get; set; }

        [JsonProperty("valorAliquotaSeguroPrestamista")]
        public object ValorAliquotaSeguroPrestamista { get; set; }

        [JsonProperty("valorSeguroPrestamista", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSeguroPrestamista { get; set; }

        [JsonProperty("valorParcelaDevedorRefin", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorParcelaDevedorRefin { get; set; }

        [JsonProperty("valorSaldoDevedorRefin", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSaldoDevedorRefin { get; set; }

        [JsonProperty("dataVencimentoAgi13")]
        public object DataVencimentoAgi13 { get; set; }

        [JsonProperty("dataSimulacaoAgi13")]
        public object DataSimulacaoAgi13 { get; set; }

        [JsonProperty("valorParcelaAgi13")]
        public object ValorParcelaAgi13 { get; set; }

        [JsonProperty("valorLiquidoAgi13")]
        public object ValorLiquidoAgi13 { get; set; }

        [JsonProperty("contratarProximaParcelaAgi13", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ContratarProximaParcelaAgi13 { get; set; }

        [JsonProperty("produtoConfiguracaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProdutoConfiguracaoCodigo { get; set; }

        [JsonProperty("atendimentoOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass AtendimentoOperacao { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCPRefinContratoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoSimulacaoCpRefinContratoList { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoCPDadosOptanteList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> AtendimentoOperacaoSimulacaoCpDadosOptanteList { get; set; }

        [JsonProperty("clienteOptante", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClienteOptante { get; set; }

        [JsonProperty("contaDebito", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaDebito { get; set; }

        [JsonProperty("contaLiberacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaLiberacao { get; set; }

        [JsonProperty("contaAverbacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaAverbacao { get; set; }

        [JsonProperty("requerAutorizacaoDebito", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequerAutorizacaoDebito { get; set; }

        [JsonProperty("tipoProdutoMotor", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoProdutoMotor { get; set; }

        [JsonProperty("produtoScore")]
        public object ProdutoScore { get; set; }

        [JsonProperty("segmentoProdutoCodigo")]
        public object SegmentoProdutoCodigo { get; set; }

        [JsonProperty("margemScr")]
        public double? MargemScr { get; set; }

        [JsonProperty("margemScrCP")]
        public long? MargemScrCp { get; set; }

        [JsonProperty("grupoRisco")]
        public object GrupoRisco { get; set; }

        [JsonProperty("valorPercentualRendaBruta")]
        public double? ValorPercentualRendaBruta { get; set; }

        [JsonProperty("valorPercentualRendaLiquida")]
        public double? ValorPercentualRendaLiquida { get; set; }

        [JsonProperty("idPrazoMotor")]

        public long? IdPrazoMotor { get; set; }

        [JsonProperty("indiceTaxaMotor")]
        public string IndiceTaxaMotor { get; set; }

        [JsonProperty("reservaContratoNumero")]

        public long? ReservaContratoNumero { get; set; }

        [JsonProperty("valorLiquidoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorLiquidoTotal { get; set; }

        [JsonProperty("deveHabilitarTeimosinha", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeveHabilitarTeimosinha { get; set; }
    }

    public partial class AtendimentoOperacaoSimulacaoSeguroList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoOperacaoSimulacaoSeguroCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoSimulacaoSeguroCodigo { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("dataHoraSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataHoraSimulacao { get; set; }

        [JsonProperty("grupoProdutoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoProdutoCodigo { get; set; }

        [JsonProperty("produtoSelecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProdutoSelecionado { get; set; }

        [JsonProperty("tipoSimulacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoSimulacao { get; set; }

        [JsonProperty("plano")]
        public object Plano { get; set; }

        [JsonProperty("ddd", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ddd { get; set; }

        [JsonProperty("telefone", NullValueHandling = NullValueHandling.Ignore)]
        public long? Telefone { get; set; }

        [JsonProperty("produtoConfiguracaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProdutoConfiguracaoCodigo { get; set; }

        [JsonProperty("atendimentoOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass AtendimentoOperacao { get; set; }

        [JsonProperty("clienteOptante", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClienteOptante { get; set; }

        [JsonProperty("contaDebito", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaDebito { get; set; }

        [JsonProperty("contaLiberacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaLiberacao { get; set; }

        [JsonProperty("contaAverbacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContaAverbacao { get; set; }

        [JsonProperty("requerAutorizacaoDebito", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequerAutorizacaoDebito { get; set; }

        [JsonProperty("dataLiberacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataLiberacao { get; set; }

        [JsonProperty("tipoProdutoMotor", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoProdutoMotor { get; set; }

        [JsonProperty("produtoScore")]
        public object ProdutoScore { get; set; }

        [JsonProperty("segmentoProdutoCodigo")]
        public object SegmentoProdutoCodigo { get; set; }

        [JsonProperty("grupoRisco")]
        public object GrupoRisco { get; set; }
    }

    public partial class PurpleEspecie
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("especieCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? EspecieCodigo { get; set; }

        [JsonProperty("especieValor", NullValueHandling = NullValueHandling.Ignore)]
        public long? EspecieValor { get; set; }

        [JsonProperty("especieNome", NullValueHandling = NullValueHandling.Ignore)]
        public string EspecieNome { get; set; }

        [JsonProperty("tipoEspecieNome", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoEspecieNome { get; set; }

        [JsonProperty("especieSituacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? EspecieSituacao { get; set; }

        [JsonProperty("tipoEspecieSituacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoEspecieSituacao { get; set; }

        [JsonProperty("especieConsignado", NullValueHandling = NullValueHandling.Ignore)]
        public string EspecieConsignado { get; set; }

        [JsonProperty("especieDomicilio", NullValueHandling = NullValueHandling.Ignore)]
        public string EspecieDomicilio { get; set; }

        [JsonProperty("especieAgidebito", NullValueHandling = NullValueHandling.Ignore)]
        public string EspecieAgidebito { get; set; }

        [JsonProperty("tipoEspeciePrazoPermanencia", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoEspeciePrazoPermanencia { get; set; }

        [JsonProperty("tipoEspecieDecimoTerceiro", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoEspecieDecimoTerceiro { get; set; }

        [JsonProperty("tipoEspecieCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoEspecieCodigo { get; set; }

        [JsonProperty("valorFormatadoSicred", NullValueHandling = NullValueHandling.Ignore)]
        public string ValorFormatadoSicred { get; set; }

        [JsonProperty("dataPermanenciaOrgaoObrigatoria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DataPermanenciaOrgaoObrigatoria { get; set; }
    }

    public partial class RegraPagamento
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("regraPagamentoCodigoInteiro", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegraPagamentoCodigoInteiro { get; set; }

        [JsonProperty("regraPagamentoNome", NullValueHandling = NullValueHandling.Ignore)]
        public string RegraPagamentoNome { get; set; }

        [JsonProperty("regraPagamentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegraPagamentoCodigo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("regraPagamentoId", NullValueHandling = NullValueHandling.Ignore)]
        public string RegraPagamentoId { get; set; }

        [JsonProperty("regraPagamentoDiaMaximo", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegraPagamentoDiaMaximo { get; set; }

        [JsonProperty("regraPagamentoSituacao", NullValueHandling = NullValueHandling.Ignore)]
        public string RegraPagamentoSituacao { get; set; }

        [JsonProperty("fontePagadoraCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? FontePagadoraCodigo { get; set; }

        [JsonProperty("origemOrgaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string OrigemOrgaoCodigo { get; set; }

        [JsonProperty("instituicao")]
        public object Instituicao { get; set; }

        [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
        public string Situacao { get; set; }

        [JsonProperty("diaUtil", NullValueHandling = NullValueHandling.Ignore)]
        public long? DiaUtil { get; set; }

        [JsonProperty("dataFixa")]
        public object DataFixa { get; set; }

        [JsonProperty("aPartirDoDia")]
        public object APartirDoDia { get; set; }

        [JsonProperty("qtdDiasUteis")]
        public object QtdDiasUteis { get; set; }

        [JsonProperty("formaPagamento", NullValueHandling = NullValueHandling.Ignore)]
        public string FormaPagamento { get; set; }

        [JsonProperty("nomeDaFormaDePagamento", NullValueHandling = NullValueHandling.Ignore)]
        public string NomeDaFormaDePagamento { get; set; }
    }

    public partial class Usuario
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("usuarioCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsuarioCodigo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        public string Login { get; set; }

        [JsonProperty("senha", NullValueHandling = NullValueHandling.Ignore)]
        public string Senha { get; set; }

        [JsonProperty("pessoaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PessoaCodigo { get; set; }

        [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? Situacao { get; set; }

        [JsonProperty("captacaoRefin")]
        public object CaptacaoRefin { get; set; }

        [JsonProperty("captacaoInss")]
        public object CaptacaoInss { get; set; }

        [JsonProperty("captacaoNovo")]
        public object CaptacaoNovo { get; set; }

        [JsonProperty("pessoa")]
        public object Pessoa { get; set; }

        [JsonProperty("usuarioGrupoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> UsuarioGrupoList { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("endereco")]
        public object Endereco { get; set; }

        [JsonProperty("cidadeCodigo")]
        public object CidadeCodigo { get; set; }

        [JsonProperty("cidadeNome")]
        public object CidadeNome { get; set; }

        [JsonProperty("estadoUF")]
        public object EstadoUf { get; set; }

        [JsonProperty("regiaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegiaoCodigo { get; set; }

        [JsonProperty("regiaoNome")]
        public object RegiaoNome { get; set; }
    }

    public partial class AtendimentoModelAtendimentoOperacaoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("atendimentoOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoOperacaoCodigo { get; set; }

        [JsonProperty("regraPagamentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegraPagamentoCodigo { get; set; }

        [JsonProperty("regraPagamentoNome", NullValueHandling = NullValueHandling.Ignore)]
        public string RegraPagamentoNome { get; set; }

        [JsonProperty("domicilioEstadoUF", NullValueHandling = NullValueHandling.Ignore)]
        public string DomicilioEstadoUf { get; set; }

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

        [JsonProperty("dataPermanenciaOrgao")]
        public object DataPermanenciaOrgao { get; set; }

        [JsonProperty("bancoCodigo", NullValueHandling = NullValueHandling.Ignore)]

        public long? BancoCodigo { get; set; }

        [JsonProperty("numeroAgencia", NullValueHandling = NullValueHandling.Ignore)]

        public long? NumeroAgencia { get; set; }

        [JsonProperty("tipoOperacaoCEFCodigo")]
        public object TipoOperacaoCefCodigo { get; set; }

        [JsonProperty("numeroConta", NullValueHandling = NullValueHandling.Ignore)]
        public string NumeroConta { get; set; }

        [JsonProperty("tipoContaCodigo")]
        public object TipoContaCodigo { get; set; }

        [JsonProperty("valorRendaBruta", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorRendaBruta { get; set; }

        [JsonProperty("valorRendaLiquida", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorRendaLiquida { get; set; }

        [JsonProperty("valorTipoDespesa")]
        public object ValorTipoDespesa { get; set; }

        [JsonProperty("valorTipoDespesaOriginal")]
        public object ValorTipoDespesaOriginal { get; set; }

        [JsonProperty("naoPossuiTipoDespesa", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiTipoDespesa { get; set; }

        [JsonProperty("valorAditivoDesconto")]
        public object ValorAditivoDesconto { get; set; }

        [JsonProperty("valorAditivoDescontoOriginal")]
        public object ValorAditivoDescontoOriginal { get; set; }

        [JsonProperty("naoPossuiAditivoDesconto", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiAditivoDesconto { get; set; }

        [JsonProperty("naoPossuiProventosBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiProventosBeneficio { get; set; }

        [JsonProperty("naoPossuiDebitosBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiDebitosBeneficio { get; set; }

        [JsonProperty("naoPossuiEmprestimosBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NaoPossuiEmprestimosBeneficio { get; set; }

        [JsonProperty("diaRecebimentoSalario")]
        public object DiaRecebimentoSalario { get; set; }

        [JsonProperty("alteracaoDadosCadastrais", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AlteracaoDadosCadastrais { get; set; }

        [JsonProperty("exibirEmModoSiape", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExibirEmModoSiape { get; set; }

        [JsonProperty("upagSigla")]
        public object UpagSigla { get; set; }

        [JsonProperty("upagNome")]
        public object UpagNome { get; set; }

        [JsonProperty("upagCodigo")]
        public object UpagCodigo { get; set; }

        [JsonProperty("matriculaInstituidor")]
        public object MatriculaInstituidor { get; set; }

        [JsonProperty("informouRenda", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InformouRenda { get; set; }

        [JsonProperty("dataRecebimentoSalario", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataRecebimentoSalario { get; set; }

        [JsonProperty("especieCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? EspecieCodigo { get; set; }

        [JsonProperty("especie", NullValueHandling = NullValueHandling.Ignore)]
        public AtendimentoClass Especie { get; set; }

        [JsonProperty("dataPermanenciaOrgaoObrigatoria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DataPermanenciaOrgaoObrigatoria { get; set; }

        [JsonProperty("ehInstituicaoGrupoINSS", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EhInstituicaoGrupoInss { get; set; }

        [JsonProperty("ehInstituicaoGrupoSiape", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EhInstituicaoGrupoSiape { get; set; }

        [JsonProperty("maximoDiasContraCheque", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaximoDiasContraCheque { get; set; }

        [JsonProperty("maximoDiasDataFuturaContraCheque", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaximoDiasDataFuturaContraCheque { get; set; }

        [JsonProperty("meioPagamentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeioPagamentoCodigo { get; set; }

        [JsonProperty("meioPagamentoSimulador", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeioPagamentoSimulador { get; set; }

        [JsonProperty("possuiCartaoRMC", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("matriculaMascara", NullValueHandling = NullValueHandling.Ignore)]
        public string MatriculaMascara { get; set; }

        [JsonProperty("valorPrestacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorPrestacao { get; set; }

        [JsonProperty("valorCompra", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("contaCredito")]
        public object ContaCredito { get; set; }

        [JsonProperty("tipoOperacaoCreditoCEFCodigo")]
        public object TipoOperacaoCreditoCefCodigo { get; set; }

        [JsonProperty("tipoContaCreditoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaCreditoCodigo { get; set; }

        [JsonProperty("tipoContaSalario", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaSalario { get; set; }

        [JsonProperty("contaAtributo")]
        public object ContaAtributo { get; set; }

        [JsonProperty("usuarioOperacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("bancoAverbacao", NullValueHandling = NullValueHandling.Ignore)]

        public long? BancoAverbacao { get; set; }

        [JsonProperty("agenciaAverbacao", NullValueHandling = NullValueHandling.Ignore)]

        public long? AgenciaAverbacao { get; set; }

        [JsonProperty("tipoOperacaoCefAverbacaoCodigo")]
        public object TipoOperacaoCefAverbacaoCodigo { get; set; }

        [JsonProperty("contaAverbacao")]
        public object ContaAverbacao { get; set; }

        [JsonProperty("tipoContaAverbacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaAverbacaoCodigo { get; set; }

        [JsonProperty("clienteDomiciliado")]
        public object ClienteDomiciliado { get; set; }

        [JsonProperty("dataCessacaoBeneficio")]
        public object DataCessacaoBeneficio { get; set; }

        [JsonProperty("rendaEstimada")]
        public object RendaEstimada { get; set; }

        [JsonProperty("diaPagamentoCalculado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DiaPagamentoCalculado { get; set; }

        [JsonProperty("anoExpedicaoBeneficio", NullValueHandling = NullValueHandling.Ignore)]
        public long? AnoExpedicaoBeneficio { get; set; }

        [JsonProperty("manterSalarioBancoAgiplan")]
        public object ManterSalarioBancoAgiplan { get; set; }

        [JsonProperty("bancoNumeroSimulador", NullValueHandling = NullValueHandling.Ignore)]

        public long? BancoNumeroSimulador { get; set; }
    }

    public partial class Cadastro
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("cliente", NullValueHandling = NullValueHandling.Ignore)]
        public Cliente Cliente { get; set; }

        [JsonProperty("referenciaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<ReferenciaList> ReferenciaList { get; set; }

        [JsonProperty("testemunhaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> TestemunhaList { get; set; }
    }

    public partial class Cliente
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoEstadoCivilCasado", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoEstadoCivilCasado { get; set; }

        [JsonProperty("tipoDocumentoCodigo")]
        public object TipoDocumentoCodigo { get; set; }

        [JsonProperty("documentoIdentificacao")]
        public object DocumentoIdentificacao { get; set; }

        [JsonProperty("orgaoExpedidorCodigo")]
        public object OrgaoExpedidorCodigo { get; set; }

        [JsonProperty("dataExpedicao", NullValueHandling = NullValueHandling.Ignore)]
        public string DataExpedicao { get; set; }

        [JsonProperty("sexo")]
        public object Sexo { get; set; }

        [JsonProperty("nacionalidadeCodigo")]
        public object NacionalidadeCodigo { get; set; }

        [JsonProperty("naturalidadeEstadoUF")]
        public object NaturalidadeEstadoUf { get; set; }

        [JsonProperty("naturalidadeCidadeCodigo")]
        public object NaturalidadeCidadeCodigo { get; set; }

        [JsonProperty("ufExpedicao")]
        public object UfExpedicao { get; set; }

        [JsonProperty("nomePai")]
        public object NomePai { get; set; }

        [JsonProperty("nomeMae")]
        public object NomeMae { get; set; }

        [JsonProperty("ocupacaoCodigo")]
        public object OcupacaoCodigo { get; set; }

        [JsonProperty("patrimonioCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PatrimonioCodigo { get; set; }

        [JsonProperty("estadoCivilCodigo")]
        public object EstadoCivilCodigo { get; set; }

        [JsonProperty("conjugeCpf")]
        public object ConjugeCpf { get; set; }

        [JsonProperty("conjugeNome")]
        public object ConjugeNome { get; set; }

        [JsonProperty("profissaoCodigo")]
        public object ProfissaoCodigo { get; set; }

        [JsonProperty("escolaridadeCodigo")]
        public object EscolaridadeCodigo { get; set; }

        [JsonProperty("ppe")]
        public object Ppe { get; set; }

        [JsonProperty("procuradorCpf")]
        public object ProcuradorCpf { get; set; }

        [JsonProperty("clienteAlfabetizado")]
        public object ClienteAlfabetizado { get; set; }
    }

    public partial class ProdutoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("mensagemInformativaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> MensagemInformativaList { get; set; }

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
        public object PoliticaMargemCodigo { get; set; }

        [JsonProperty("politicaMargemNome")]
        public object PoliticaMargemNome { get; set; }

        [JsonProperty("margemPropria")]
        public object MargemPropria { get; set; }

        [JsonProperty("planoCodigo")]
        public object PlanoCodigo { get; set; }

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
        public object GrupoProdutoDescricao { get; set; }

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
        public object ContaCorrenteModel { get; set; }

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
        public object BancoCredito { get; set; }

        [JsonProperty("agenciaCredito")]
        public object AgenciaCredito { get; set; }

        [JsonProperty("contaCredito")]
        public object ContaCredito { get; set; }

        [JsonProperty("tipoOperacaoCreditoCEFCodigo")]
        public object TipoOperacaoCreditoCefCodigo { get; set; }

        [JsonProperty("tipoContaCreditoCodigo")]
        public object TipoContaCreditoCodigo { get; set; }

        [JsonProperty("produtoConfiguracaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProdutoConfiguracaoCodigo { get; set; }

        [JsonProperty("parcelaAutomaticaAgendada")]
        public object ParcelaAutomaticaAgendada { get; set; }

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
        public double? PorcentagemMaxAumentoRendaBruta { get; set; }

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
        public object ClienteOptante { get; set; }

        [JsonProperty("contaDebito")]
        public object ContaDebito { get; set; }

        [JsonProperty("contaLiberacao")]
        public long? ContaLiberacao { get; set; }

        [JsonProperty("contaAverbacao")]
        public object ContaAverbacao { get; set; }

        [JsonProperty("requerAutorizacaoDebito")]
        public object RequerAutorizacaoDebito { get; set; }

        [JsonProperty("dataLiberacao")]
        public object DataLiberacao { get; set; }

        [JsonProperty("tipoProdutoMotor")]
        public object TipoProdutoMotor { get; set; }

        [JsonProperty("produtoScore")]
        public object ProdutoScore { get; set; }

        [JsonProperty("segmentoProdutoCodigo")]
        public object SegmentoProdutoCodigo { get; set; }

        [JsonProperty("margemScr")]
        public object MargemScr { get; set; }

        [JsonProperty("margemScrCP")]
        public object MargemScrCp { get; set; }

        [JsonProperty("grupoRisco")]
        public object GrupoRisco { get; set; }

        [JsonProperty("tipoEntrega")]
        public object TipoEntrega { get; set; }

        [JsonProperty("idPrazoMotor")]
        public object IdPrazoMotor { get; set; }

        [JsonProperty("valorPercentualRendaBruta")]
        public object ValorPercentualRendaBruta { get; set; }

        [JsonProperty("valorPercentualRendaLiquida")]
        public object ValorPercentualRendaLiquida { get; set; }

        [JsonProperty("dataCessacaoMotor")]
        public object DataCessacaoMotor { get; set; }

        [JsonProperty("indiceTaxaMotor")]
        public object IndiceTaxaMotor { get; set; }

        [JsonProperty("reservaContratoNumero")]
        public object ReservaContratoNumero { get; set; }

        [JsonProperty("motorAutomaticApprove", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MotorAutomaticApprove { get; set; }

        [JsonProperty("documentosMotor")]
        public object DocumentosMotor { get; set; }

        [JsonProperty("valorDividaMotor")]
        public object ValorDividaMotor { get; set; }

        [JsonProperty("deveHabilitarTeimosinha")]
        public object DeveHabilitarTeimosinha { get; set; }

        [JsonProperty("mensagemBiometriaString", NullValueHandling = NullValueHandling.Ignore)]
        public string MensagemBiometriaString { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemDisponivel", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemDisponivel { get; set; }

        [JsonProperty("produtoTeveContratoGerado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProdutoTeveContratoGerado { get; set; }

        [JsonProperty("validarPortabilidadeAtiva", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarPortabilidadeAtiva { get; set; }
    }

    public partial class CartaoModel
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("valorLimitePreAprovado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorLimitePreAprovado { get; set; }

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

        [JsonProperty("valorMargemDisponivelOld", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemDisponivelOld { get; set; }

        [JsonProperty("margemReservadaHabilitada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MargemReservadaHabilitada { get; set; }

        [JsonProperty("compartilhaMargem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CompartilhaMargem { get; set; }

        [JsonProperty("politicaMargemCodigo")]
        public object PoliticaMargemCodigo { get; set; }

        [JsonProperty("politicaMargemNome")]
        public object PoliticaMargemNome { get; set; }

        [JsonProperty("valorDisponivelPreSaque")]
        public object ValorDisponivelPreSaque { get; set; }

        [JsonProperty("valorSolicitadoPreSaque")]
        public object ValorSolicitadoPreSaque { get; set; }

        [JsonProperty("contratarPreSaque")]
        public object ContratarPreSaque { get; set; }

        [JsonProperty("permitirPreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermitirPreSaque { get; set; }

        [JsonProperty("aliquotaPreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public long? AliquotaPreSaque { get; set; }

        [JsonProperty("margemPropria", NullValueHandling = NullValueHandling.Ignore)]
        public MargemPropria MargemPropria { get; set; }

        [JsonProperty("usandoMargemPropria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UsandoMargemPropria { get; set; }

        [JsonProperty("multiplicador")]
        public object Multiplicador { get; set; }

        [JsonProperty("atualizarTipoVinculoConta")]
        public object AtualizarTipoVinculoConta { get; set; }

        [JsonProperty("tipoEntrega")]
        public object TipoEntrega { get; set; }

        [JsonProperty("reservaContratoNumero")]
        public object ReservaContratoNumero { get; set; }

        [JsonProperty("requerLimiteSadMotor")]
        public object RequerLimiteSadMotor { get; set; }

        [JsonProperty("valorLimitePreAprovadoAnterior")]
        public object ValorLimitePreAprovadoAnterior { get; set; }

        [JsonProperty("valorMargemCalculadaAnterior")]
        public object ValorMargemCalculadaAnterior { get; set; }
    }

    public partial class MargemPropria
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("politicaMargemNome")]
        public object PoliticaMargemNome { get; set; }

        [JsonProperty("politicaMargemCodigo")]
        public object PoliticaMargemCodigo { get; set; }

        [JsonProperty("valorMargemCompartilhada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCompartilhada { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemReservada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemReservada { get; set; }

        [JsonProperty("valorMargemDisponivel", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemDisponivel { get; set; }
    }

    public partial class CreditoPessoalModel
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("politicaMargemNome")]
        public object PoliticaMargemNome { get; set; }

        [JsonProperty("politicaMargemCodigo")]
        public object PoliticaMargemCodigo { get; set; }

        [JsonProperty("valorMargemCompartilhada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCompartilhada { get; set; }

        [JsonProperty("valorMargemCalculada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemCalculada { get; set; }

        [JsonProperty("valorMargemDisponivel", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemDisponivel { get; set; }

        [JsonProperty("valorMargemDisponivelOld", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemDisponivelOld { get; set; }

        [JsonProperty("valorMargemReservada", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorMargemReservada { get; set; }

        [JsonProperty("valorSaldoRefinanciamento", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSaldoRefinanciamento { get; set; }

        [JsonProperty("valorSomaParcelasRefinanciamento", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSomaParcelasRefinanciamento { get; set; }

        [JsonProperty("margemDisponivelHabilitada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MargemDisponivelHabilitada { get; set; }

        [JsonProperty("dataProximoCorte")]
        public object DataProximoCorte { get; set; }

        [JsonProperty("proximoVencimento", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ProximoVencimento { get; set; }

        [JsonProperty("dataLiberacao")]
        public object DataLiberacao { get; set; }

        [JsonProperty("diasCarencia", NullValueHandling = NullValueHandling.Ignore)]
        public long? DiasCarencia { get; set; }

        [JsonProperty("valorCredito")]
        public decimal? ValorCredito { get; set; }

        [JsonProperty("valorParcela")]
        public decimal? ValorParcela { get; set; }

        [JsonProperty("quantidadeDiasCarencia", NullValueHandling = NullValueHandling.Ignore)]
        public int? QuantidadeDiasCarencia { get; set; }

        [JsonProperty("dataPrimeiroVencimento")]
        public object DataPrimeiroVencimento { get; set; }

        [JsonProperty("excedeuLimite", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcedeuLimite { get; set; }

        [JsonProperty("prazoSelecionado")]
        public PrazoSelecionado PrazoSelecionado { get; set; }

        [JsonProperty("prazoSelecionadoCodigo", NullValueHandling = NullValueHandling.Ignore)]

        public long? PrazoSelecionadoCodigo { get; set; }

        [JsonProperty("verificou", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Verificou { get; set; }

        [JsonProperty("possuiPrazos", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PossuiPrazos { get; set; }

        [JsonProperty("mostrarMargemDisponivel", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MostrarMargemDisponivel { get; set; }

        [JsonProperty("prazoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<PrazoListItem> PrazoList { get; set; }

        [JsonProperty("prazoDisponivelList", NullValueHandling = NullValueHandling.Ignore)]
        public List<PrazoDisponivelListItem> PrazoDisponivelList { get; set; }

        [JsonProperty("contratoRefinList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ContratoRefinList { get; set; }

        [JsonProperty("margemPropria")]
        public object MargemPropria { get; set; }

        [JsonProperty("agrupadorPrazoList")]
        public object AgrupadorPrazoList { get; set; }

        [JsonProperty("reservaContratoNumero")]
        public object ReservaContratoNumero { get; set; }

        [JsonProperty("valorBrutoContratoSemPagamento")]
        public object ValorBrutoContratoSemPagamento { get; set; }

        [JsonProperty("valorSaldoLiquidacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorSaldoLiquidacao { get; set; }

        [JsonProperty("contratoHistoricoAtendimentoList")]
        public object ContratoHistoricoAtendimentoList { get; set; }
    }

    public partial class ProdutoConfiguracao
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("produtoConfiguracaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProdutoConfiguracaoCodigo { get; set; }

        [JsonProperty("grupoProdutoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? GrupoProdutoCodigo { get; set; }

        [JsonProperty("grupoProdutoArrecadacaoCodigo")]
        public long? GrupoProdutoArrecadacaoCodigo { get; set; }

        [JsonProperty("empresaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string EmpresaCodigo { get; set; }

        [JsonProperty("produtoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public string ProdutoCodigo { get; set; }

        [JsonProperty("tipoOperacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoOperacao { get; set; }

        [JsonProperty("neurotechProduto", NullValueHandling = NullValueHandling.Ignore)]
        public string NeurotechProduto { get; set; }

        [JsonProperty("aliasCaptacao", NullValueHandling = NullValueHandling.Ignore)]
        public string AliasCaptacao { get; set; }

        [JsonProperty("aliasAnalise", NullValueHandling = NullValueHandling.Ignore)]
        public string AliasAnalise { get; set; }

        [JsonProperty("comprometerMargem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ComprometerMargem { get; set; }

        [JsonProperty("participarClassificacao", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ParticiparClassificacao { get; set; }

        [JsonProperty("controlarAlcada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ControlarAlcada { get; set; }

        [JsonProperty("participarIntegracaoFinanceira", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ParticiparIntegracaoFinanceira { get; set; }

        [JsonProperty("produto")]
        public object Produto { get; set; }

        [JsonProperty("valorBrutoMinimo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorBrutoMinimo { get; set; }

        [JsonProperty("valorBrutoMaximo", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorBrutoMaximo { get; set; }

        [JsonProperty("mutipliCadorProdutoCartao")]
        public long? MutipliCadorProdutoCartao { get; set; }

        [JsonProperty("referenciaConductor")]
        public string ReferenciaConductor { get; set; }

        [JsonProperty("dataVigenciaInicial", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataVigenciaInicial { get; set; }

        [JsonProperty("dataVigenciaFinal", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DataVigenciaFinal { get; set; }

        [JsonProperty("grupoProduto")]
        public object GrupoProduto { get; set; }

        [JsonProperty("origemCaptura", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrigemCaptura { get; set; }

        [JsonProperty("permitePreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermitePreSaque { get; set; }

        [JsonProperty("aliquotaPreSaque", NullValueHandling = NullValueHandling.Ignore)]
        public long? AliquotaPreSaque { get; set; }

        [JsonProperty("ordemApresentacao", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrdemApresentacao { get; set; }

        [JsonProperty("floatAtraso")]
        public long? FloatAtraso { get; set; }

        [JsonProperty("produtoConfiguracaoVinculadoCodigoCompartilhaMargemList")]
        public object ProdutoConfiguracaoVinculadoCodigoCompartilhaMargemList { get; set; }

        [JsonProperty("prioridadeCompartilhamentoDeMargem", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrioridadeCompartilhamentoDeMargem { get; set; }

        [JsonProperty("confirmacaoAutomatica", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfirmacaoAutomatica { get; set; }

        [JsonProperty("confirmacaoAutomaticaMotivo")]
        public object ConfirmacaoAutomaticaMotivo { get; set; }

        [JsonProperty("analiseAutomatica", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AnaliseAutomatica { get; set; }

        [JsonProperty("analiseAutomaticaMotivo")]
        public object AnaliseAutomaticaMotivo { get; set; }

        [JsonProperty("upaGs")]
        public object UpaGs { get; set; }

        [JsonProperty("conveniadaCodigo")]
        public string ConveniadaCodigo { get; set; }

        [JsonProperty("exigeContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeContaCorrente { get; set; }

        [JsonProperty("exigeContaCredito", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeContaCredito { get; set; }

        [JsonProperty("ofertaCaptura", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OfertaCaptura { get; set; }

        [JsonProperty("tipoProduto", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoProduto { get; set; }

        [JsonProperty("referenciaParaRefin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReferenciaParaRefin { get; set; }

        [JsonProperty("indicadorNovo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IndicadorNovo { get; set; }

        [JsonProperty("tipoDataVencimento", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoDataVencimento { get; set; }

        [JsonProperty("identificadorAGI13Parcela", NullValueHandling = NullValueHandling.Ignore)]
        public long? IdentificadorAgi13Parcela { get; set; }

        [JsonProperty("cadastrarFavorecido", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CadastrarFavorecido { get; set; }

        [JsonProperty("viewRoute")]
        public string ViewRoute { get; set; }

        [JsonProperty("diasAtrasoLimiteInferior")]
        public object DiasAtrasoLimiteInferior { get; set; }

        [JsonProperty("diasAtrasoLimiteSuperior")]
        public object DiasAtrasoLimiteSuperior { get; set; }

        [JsonProperty("separarCadastro", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SepararCadastro { get; set; }

        [JsonProperty("obrigatoriedadeVenda", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ObrigatoriedadeVenda { get; set; }

        [JsonProperty("obrigatoriedadeOferta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ObrigatoriedadeOferta { get; set; }

        [JsonProperty("exigeCartaoMultiplo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeCartaoMultiplo { get; set; }

        [JsonProperty("biometriaFacialBypass", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BiometriaFacialBypass { get; set; }

        [JsonProperty("simulacaoNaoExpira", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SimulacaoNaoExpira { get; set; }

        [JsonProperty("simulacaoSomenteLeitura", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SimulacaoSomenteLeitura { get; set; }

        [JsonProperty("impedirRecalculo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ImpedirRecalculo { get; set; }

        [JsonProperty("exigeParecerContaCorrente", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExigeParecerContaCorrente { get; set; }

        [JsonProperty("remodelagem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Remodelagem { get; set; }

        [JsonProperty("domicilio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Domicilio { get; set; }

        [JsonProperty("validarCallId", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarCallId { get; set; }

        [JsonProperty("diasAtrasoBiometria")]
        public long? DiasAtrasoBiometria { get; set; }

        [JsonProperty("solicitaFoto", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SolicitaFoto { get; set; }

        [JsonProperty("fotoObrigatoria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FotoObrigatoria { get; set; }

        [JsonProperty("diasInadimplente")]
        public object DiasInadimplente { get; set; }

        [JsonProperty("validarAlteracaoEspecieBiometria", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarAlteracaoEspecieBiometria { get; set; }

        [JsonProperty("compararDadosBancarios")]
        public object CompararDadosBancarios { get; set; }

        [JsonProperty("exibirDadosBancariosAverbacao")]
        public bool? ExibirDadosBancariosAverbacao { get; set; }

        [JsonProperty("excecaoOferta")]
        public object ExcecaoOferta { get; set; }

        [JsonProperty("fluxoAverbacaoInterna", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FluxoAverbacaoInterna { get; set; }

        [JsonProperty("possuiPreLiberacao")]
        public bool? PossuiPreLiberacao { get; set; }

        [JsonProperty("validarDadosBancariosAprovacaoAutomatica", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarDadosBancariosAprovacaoAutomatica { get; set; }

        [JsonProperty("diasValidadeFoto")]
        public long? DiasValidadeFoto { get; set; }

        [JsonProperty("porcentagemMaxReducaoRendaBruta")]
        public long? PorcentagemMaxReducaoRendaBruta { get; set; }

        [JsonProperty("porcentagemMaxAumentoRendaBruta")]
        public double? PorcentagemMaxAumentoRendaBruta { get; set; }

        [JsonProperty("porcentagemMaxReducaoRendaLiquida")]
        public object PorcentagemMaxReducaoRendaLiquida { get; set; }

        [JsonProperty("porcentagemMaxAumentoRendaLiquida")]
        public object PorcentagemMaxAumentoRendaLiquida { get; set; }

        [JsonProperty("porcentagemMaxReducaoPMT")]
        public object PorcentagemMaxReducaoPmt { get; set; }

        [JsonProperty("porcentagemMaxAumentoPMT")]
        public object PorcentagemMaxAumentoPmt { get; set; }

        [JsonProperty("porcentagemMaxReducaoDeducaoExtrato")]
        public object PorcentagemMaxReducaoDeducaoExtrato { get; set; }

        [JsonProperty("porcentagemMaxAumentoDeducaoExtrato")]
        public object PorcentagemMaxAumentoDeducaoExtrato { get; set; }

        [JsonProperty("tipoSelecaoContratosRefin")]
        public object TipoSelecaoContratosRefin { get; set; }

        [JsonProperty("deveVetarTrocoRefin")]
        public object DeveVetarTrocoRefin { get; set; }

        [JsonProperty("deveAguardarMargem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeveAguardarMargem { get; set; }

        [JsonProperty("aumentoMargemLiberada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AumentoMargemLiberada { get; set; }

        [JsonProperty("deveAvaliarSelecaoContratosRefin")]
        public object DeveAvaliarSelecaoContratosRefin { get; set; }

        [JsonProperty("porcentagemMaxReducaoValorLiquidoOferta")]
        public object PorcentagemMaxReducaoValorLiquidoOferta { get; set; }

        [JsonProperty("porcentagemMaxAumentoValorLiquidoOferta")]
        public object PorcentagemMaxAumentoValorLiquidoOferta { get; set; }

        [JsonProperty("porcentagemMaxReducaoValorSimulado")]
        public long? PorcentagemMaxReducaoValorSimulado { get; set; }

        [JsonProperty("porcentagemMaxAumentoValorSimulado")]
        public long? PorcentagemMaxAumentoValorSimulado { get; set; }

        [JsonProperty("retornoAverbacaoDesligada")]
        public object RetornoAverbacaoDesligada { get; set; }

        [JsonProperty("valorMinimoParaSolicitarDocumentoCartaoBanco")]
        public long? ValorMinimoParaSolicitarDocumentoCartaoBanco { get; set; }

        [JsonProperty("validarPortabilidadeAtiva", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidarPortabilidadeAtiva { get; set; }

        [JsonProperty("identificadorProduto", NullValueHandling = NullValueHandling.Ignore)]
        public string IdentificadorProduto { get; set; }

        [JsonProperty("permiteAlterarSelecaoContratosRefin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermiteAlterarSelecaoContratosRefin { get; set; }
    }

    public partial class SeguroModel
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("mensagemPadrao", NullValueHandling = NullValueHandling.Ignore)]
        public string MensagemPadrao { get; set; }

        [JsonProperty("linkExterno")]
        public object LinkExterno { get; set; }

        [JsonProperty("peso", NullValueHandling = NullValueHandling.Ignore)]
        public long? Peso { get; set; }

        [JsonProperty("altura", NullValueHandling = NullValueHandling.Ignore)]
        public long? Altura { get; set; }

        [JsonProperty("ddd", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ddd { get; set; }

        [JsonProperty("telefone", NullValueHandling = NullValueHandling.Ignore)]

        public long? Telefone { get; set; }

        [JsonProperty("edicaoTelefoneHabilitada", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EdicaoTelefoneHabilitada { get; set; }

        [JsonProperty("semTelefone", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SemTelefone { get; set; }

        [JsonProperty("comRecarga", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ComRecarga { get; set; }

        [JsonProperty("planoList", NullValueHandling = NullValueHandling.Ignore)]
        public List<PlanoList> PlanoList { get; set; }

        [JsonProperty("planosSeguro")]
        public object PlanosSeguro { get; set; }

        [JsonProperty("planoSelecionado")]
        public object PlanoSelecionado { get; set; }

        [JsonProperty("planoSeguroSelecionado")]
        public object PlanoSeguroSelecionado { get; set; }
    }

    public partial class PlanoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("planoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlanoCodigo { get; set; }

        [JsonProperty("coberturaAluguel", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaAluguel { get; set; }

        [JsonProperty("coberturaDanosPorAgua", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaDanosPorAgua { get; set; }

        [JsonProperty("coberturaIncendioRaioExplosaoQuedaAeronave", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaIncendioRaioExplosaoQuedaAeronave { get; set; }

        [JsonProperty("coberturaResponsabilidadeCivil", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaResponsabilidadeCivil { get; set; }

        [JsonProperty("coberturaRoubo", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaRoubo { get; set; }

        [JsonProperty("coberturaVendaval", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaVendaval { get; set; }

        [JsonProperty("premio", NullValueHandling = NullValueHandling.Ignore)]
        public double? Premio { get; set; }

        [JsonProperty("valorRecarga")]
        public object ValorRecarga { get; set; }

        [JsonProperty("comRecarga", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ComRecarga { get; set; }

        [JsonProperty("coberturaMorteNatural", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaMorteNatural { get; set; }

        [JsonProperty("coberturaMorteAcidental", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaMorteAcidental { get; set; }

        [JsonProperty("auxilioFuneral", NullValueHandling = NullValueHandling.Ignore)]
        public long? AuxilioFuneral { get; set; }

        [JsonProperty("coberturaAssistenciaMedicamento", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoberturaAssistenciaMedicamento { get; set; }

        [JsonProperty("sorteioSemanal", NullValueHandling = NullValueHandling.Ignore)]
        public long? SorteioSemanal { get; set; }
    }

    public partial class BancoOList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("bancoCompensacao", NullValueHandling = NullValueHandling.Ignore)]
        public string BancoCompensacao { get; set; }

        [JsonProperty("bancoNome", NullValueHandling = NullValueHandling.Ignore)]
        public string BancoNome { get; set; }

        [JsonProperty("mascaraAgencia")]
        public string MascaraAgencia { get; set; }

        [JsonProperty("mascaraConta")]
        public string MascaraConta { get; set; }
    }

    public partial class DdD
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("ddd", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ddd { get; set; }

        [JsonProperty("estadoUf", NullValueHandling = NullValueHandling.Ignore)]
        public string EstadoUf { get; set; }
    }

    public partial class DeclaracaoFinsDeAberturaListElement
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("group")]
        public object Group { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selected { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }
    }

    public partial class DocumentosViewModel
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("atendimentoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? AtendimentoCodigo { get; set; }

        [JsonProperty("empresaCodigo")]
        public object EmpresaCodigo { get; set; }

        [JsonProperty("produtosCodigos")]
        public object ProdutosCodigos { get; set; }

        [JsonProperty("cpfCnpj")]
        public object CpfCnpj { get; set; }

        [JsonProperty("documentos", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Documentos { get; set; }

        [JsonProperty("obrigatoriedadeDocumentosList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ObrigatoriedadeDocumentosList { get; set; }

        [JsonProperty("documentosResultadoPoliticaList", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DocumentosResultadoPoliticaList { get; set; }
    }

    public partial class EstadoListElement
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("group")]
        public object Group { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selected { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class GrupoPerfilConfiguracao
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("permiteOcorrencia", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermiteOcorrencia { get; set; }

        [JsonProperty("permiteGerarProposta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermiteGerarProposta { get; set; }

        [JsonProperty("permiteIniciarAcordo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermiteIniciarAcordo { get; set; }

        [JsonProperty("permiteSimular", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermiteSimular { get; set; }
    }

    public partial class NaturezaOcupacaoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("naturezaOcupacaoCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? NaturezaOcupacaoCodigo { get; set; }

        [JsonProperty("descricao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }

    public partial class SimNaoList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("group")]
        public object Group { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selected { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Value { get; set; }
    }

    public partial class SituacaoFuncionalList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("situacaoFuncionalCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? SituacaoFuncionalCodigo { get; set; }

        [JsonProperty("descricao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }

    public partial class TipoContaList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoContaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoContaCodigo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [JsonProperty("codigoSicred", NullValueHandling = NullValueHandling.Ignore)]
        public string CodigoSicred { get; set; }

        [JsonProperty("codigoLydians", NullValueHandling = NullValueHandling.Ignore)]
        public string CodigoLydians { get; set; }
    }

    public partial class TipoLogradouroList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoLogradouroCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoLogradouroCodigo { get; set; }

        [JsonProperty("tipoLogradouroNome", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoLogradouroNome { get; set; }

        [JsonProperty("dataHoraCriacao", NullValueHandling = NullValueHandling.Ignore)]
        public string DataHoraCriacao { get; set; }

        [JsonProperty("dataHoraAtualizacao")]
        public object DataHoraAtualizacao { get; set; }
    }

    public partial class TipoMidiaList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoMidiaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoMidiaCodigo { get; set; }

        [JsonProperty("descricao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }

    public partial class TipoOperacaoCefList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoOperacaoCEFCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoOperacaoCefCodigo { get; set; }

        [JsonProperty("codigoOperacaoCEF", NullValueHandling = NullValueHandling.Ignore)]
        public string CodigoOperacaoCef { get; set; }

        [JsonProperty("descricaoOperacaoCEF", NullValueHandling = NullValueHandling.Ignore)]
        public string DescricaoOperacaoCef { get; set; }
    }

    public partial class TipoResidenciaList
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty("tipoResidenciaCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoResidenciaCodigo { get; set; }

        [JsonProperty("descricao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }

    public partial class TipoTelefoneElement
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("tipoTelefoneCodigo", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoTelefoneCodigo { get; set; }

        [JsonProperty("tipoTelefoneNome", NullValueHandling = NullValueHandling.Ignore)]
        public string TipoTelefoneNome { get; set; }
    }

    public partial class PrazoSelecionado
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("idPrazo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdPrazo { get; set; }

        [JsonProperty("prazo", NullValueHandling = NullValueHandling.Ignore)]
        public int? Prazo { get; set; }

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
        public decimal? ValorAliquotaIof { get; set; }

        [JsonProperty("valorAliquotaIOFAdicional", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorAliquotaIofAdicional { get; set; }

        [JsonProperty("valorTaxaAnual", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTaxaAnual { get; set; }

        [JsonProperty("valorTaxaMensal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTaxaMensal { get; set; }

        [JsonProperty("valorCETAnual", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCetAnual { get; set; }

        [JsonProperty("valorCETMensal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCetMensal { get; set; }

        [JsonProperty("valorCoeficienteIOF", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCoeficienteIof { get; set; }

        [JsonProperty("valorCoeficientePMT", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorCoeficientePmt { get; set; }

        [JsonProperty("valorFinanciado", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorFinanciado { get; set; }

        [JsonProperty("valorIOF", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorIof { get; set; }

        [JsonProperty("valorSeguroPrestamista", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorSeguroPrestamista { get; set; }

        [JsonProperty("valorTC", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTc { get; set; }

        [JsonProperty("valorTFC", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTfc { get; set; }

        [JsonProperty("valorTarifas", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorTarifas { get; set; }

        [JsonProperty("percentualSeguroPrestamista")]
        public string PercentualSeguroPrestamista { get; set; }

        [JsonProperty("grupoApresentacao", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? GrupoApresentacao { get; set; }

        [JsonProperty("indiceTaxaMotor", NullValueHandling = NullValueHandling.Ignore)]
        public string IndiceTaxaMotor { get; set; }

        [JsonProperty("prazoIdentificadorUnico", NullValueHandling = NullValueHandling.Ignore)]
        public string PrazoIdentificadorUnico { get; set; }

        [JsonProperty("valorDivida", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorDivida { get; set; }

        [JsonProperty("valorLiquidoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ValorLiquidoTotal { get; set; }
    }

    public partial class PrazoListItem
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("idPrazo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdPrazo { get; set; }

        [JsonProperty("prazo", NullValueHandling = NullValueHandling.Ignore)]
        public long? Prazo { get; set; }

        [JsonProperty("valorParcela", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorParcela { get; set; }

        [JsonProperty("valorCredito", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCredito { get; set; }

        [JsonProperty("valorBruto", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorBruto { get; set; }

        [JsonProperty("valorLiquido", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorLiquido { get; set; }

        [JsonProperty("selecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selecionado { get; set; }

        [JsonProperty("valorAliquotaIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIof { get; set; }

        [JsonProperty("valorAliquotaIOFAdicional", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIofAdicional { get; set; }

        [JsonProperty("valorTaxaAnual", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorTaxaAnual { get; set; }

        [JsonProperty("valorTaxaMensal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorTaxaMensal { get; set; }

        [JsonProperty("valorCETAnual", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCetAnual { get; set; }

        [JsonProperty("valorCETMensal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCetMensal { get; set; }

        [JsonProperty("valorCoeficienteIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficienteIof { get; set; }

        [JsonProperty("valorCoeficientePMT", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficientePmt { get; set; }

        [JsonProperty("valorFinanciado", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorFinanciado { get; set; }

        [JsonProperty("valorIOF", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorIof { get; set; }

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

        [JsonProperty("indiceTaxaMotor", NullValueHandling = NullValueHandling.Ignore)]
        public string IndiceTaxaMotor { get; set; }

        [JsonProperty("prazoIdentificadorUnico", NullValueHandling = NullValueHandling.Ignore)]
        public string PrazoIdentificadorUnico { get; set; }

        [JsonProperty("valorDivida", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorDivida { get; set; }

        [JsonProperty("valorLiquidoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorLiquidoTotal { get; set; }
    }

    public partial class PrazoDisponivelListItem
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("idPrazo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdPrazo { get; set; }

        [JsonProperty("prazo", NullValueHandling = NullValueHandling.Ignore)]
        public long? Prazo { get; set; }

        [JsonProperty("valorParcela", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorParcela { get; set; }

        [JsonProperty("valorCredito", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCredito { get; set; }

        [JsonProperty("valorBruto", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorBruto { get; set; }

        [JsonProperty("valorLiquido", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorLiquido { get; set; }

        [JsonProperty("selecionado", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selecionado { get; set; }

        [JsonProperty("valorAliquotaIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIof { get; set; }

        [JsonProperty("valorAliquotaIOFAdicional", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorAliquotaIofAdicional { get; set; }

        [JsonProperty("valorTaxaAnual", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorTaxaAnual { get; set; }

        [JsonProperty("valorTaxaMensal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorTaxaMensal { get; set; }

        [JsonProperty("valorCETAnual", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCetAnual { get; set; }

        [JsonProperty("valorCETMensal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorCetMensal { get; set; }

        [JsonProperty("valorCoeficienteIOF", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficienteIof { get; set; }

        [JsonProperty("valorCoeficientePMT", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorCoeficientePmt { get; set; }

        [JsonProperty("valorFinanciado", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorFinanciado { get; set; }

        [JsonProperty("valorIOF", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorIof { get; set; }

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

        [JsonProperty("indiceTaxaMotor", NullValueHandling = NullValueHandling.Ignore)]
        public string IndiceTaxaMotor { get; set; }

        [JsonProperty("prazoIdentificadorUnico", NullValueHandling = NullValueHandling.Ignore)]
        public string PrazoIdentificadorUnico { get; set; }

        [JsonProperty("valorDivida", NullValueHandling = NullValueHandling.Ignore)]
        public long? ValorDivida { get; set; }

        [JsonProperty("valorLiquidoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public double? ValorLiquidoTotal { get; set; }
    }
}



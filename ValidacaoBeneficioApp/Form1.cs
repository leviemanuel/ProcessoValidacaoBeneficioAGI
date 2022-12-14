using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidacaoBeneficioApp.BD;
using ValidacaoBeneficioBot.Objs;
using ValidacaoBeneficioDB;
using ValidacaoBeneficioDB.Models;

namespace ValidacaoBeneficioApp
{
    public partial class Form1 : Form
    {
        private string nmArquivo;
        private List<Thread> ListaThreads;
        ValidacaoBeneficioDBContext context;
        int contador = 0;
        int qtErros = 0;
        int qtProcessados = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void TESTE()
        {
            var robo = new ValidacaoBeneficioBot.Bot4();
            var erro = "";
            var flClienteNovo = false;



            robo.BotInicialize(ref erro);

            //robo.Login(txtUsuario.Text, txtSenha.Text, ref erro);

            //var cons = context.ReservarConsulta(chkApenasNovos.Checked, chkApenasErro.Checked);

            //var dataClientRequest = new ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest()
            //{
            //    Phone = null,
            //    AdditionalDocuments = new List<ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType>(),
            //    Benefit = new ValidacaoBeneficioBot.JSONObjects.BenefitType()
            //    {
            //        BenefitKind = new ValidacaoBeneficioBot.JSONObjects.BenefitKindType()
            //        {
            //            Code = int.Parse(cons.esp)
            //        },
            //        CBCIfPayer = "001",//TODO: INSERIR CODIGO DO BANCO
            //        DispatchYear = (cons.dt_nb.HasValue) ? cons.dt_nb.Value.Year : 1990,
            //        BenefitNumber = cons.nb,
            //        OwnsLawfulAgent = true //TODO: VERIFICAR VALOR CORRETO
            //    },
            //    DateBirthday = cons.dtnasc.Value,
            //    Document = cons.cpf,
            //    ExternalId = "", // PREENCHIDO NA CLASSE DO ROBO
            //    FullName = cons.nome,
            //    Income = new ValidacaoBeneficioBot.JSONObjects.IncomeType()
            //    {
            //        GrossIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
            //        NetIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
            //        DatePayday = new DateTime(2022, 01, 05), //TODO: VERIFICAR VALOR CORRETO
            //        CalculatedPayday = false,
            //        Discount = "0"
            //    },
            //    PostCode = cons.cep,
            //    HasValidToken = false,
            //    AttendanceType = "BY_PHONE",
            //    Consultant = new ValidacaoBeneficioBot.JSONObjects.ConsultantType() { TaxId = "" }, // PREENCHIDO NA CLASSE DO ROBO
            //    OriginalAttendanceType = "BY_PHONE",
            //    DataprevAllowanceType = null
            //};

            //dataClientRequest.AdditionalDocuments.Add(new ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType() { Type = "RG", Number = cons.nb });

            //robo.BuscaCliente(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro);

            //robo.ClicaSimulacao(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro);

            //robo.ClicaINSS(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro);

            //robo.AceitaOfertaGEV(dataClientRequest, ref erro);

            //robo.AtendimentoTelefonico(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro);

            //robo.ContinuarProcesso(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro);

            //robo.ContinuarSemCadastro(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro);

            //robo.EtapaDadosPessoais(dataClientRequest, ref erro);

            //robo.EtapaDadosBeneficios(dataClientRequest, ref erro);

            //robo.EtapaDadosRenda(dataClientRequest, ref erro);

            //robo.EtapaConferencia(dataClientRequest, ref erro);

            //var testeDadosCliente = robo.Simular(dataClientRequest, ref erro);

            var testeBRKP = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            context = new ValidacaoBeneficioDBContext();

            cboThreads.SelectedIndex = 0;
            HabilitaBotoes(true, false);

            //nmArquivo = System.Configuration.ConfigurationSettings.AppSettings["logPath"] + "ValidacaoBeneficioBot_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt";

            //System.IO.File.Create(nmArquivo);

            cboThreads.SelectedIndex = 0;
            lblErros.Text = "000";
            lblProcessados.Text = "000";
            lblTotal.Text = "000";

#if DEBUG
            txtUsuario.Text = "fortal.caio";
            txtSenha.Text = "2022@uTXr";

            //TESTE();
#endif

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty)
                return;

            if (txtSenha.Text == String.Empty)
                return;

            if (!chkApenasNovos.Checked && !chkApenasErro.Checked)
                return;

            ExibeLabel(true);

            //groupBox1.Enabled = false;

            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            txtQtProcessos.Enabled = false;
            btnIniciar.Enabled = false;
            btnParar.Enabled = true;
            chkApenasNovos.Enabled = false;
            chkApenasErro.Enabled = false;


            List<ConsMassiva> consultas = new List<ConsMassiva>();

            ListaThreads = new List<Thread>();
            int qt = 0;

            while (qt < int.Parse(cboThreads.SelectedItem.ToString()))
            {
                ListaThreads.Add(new Thread(() => RoboV3(qt)));
                ListaThreads[qt].Start();
                qt++;
            }
        }

        private void Robo(int threadNum)
        {
            var erro = "";
            var dados = new DadosClienteProduto();

            var robo = new ValidacaoBeneficioBot.Bot();

            #region INICIALIZA ROBÔ
            InsereLog("Inicializando Robô...", false);
            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Inicializando Robô...");

            robo.BotInicialize(ref erro);

            if (erro != "")
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao inicializar o robô - Encerrando processo");
                InsereLog(erro, true);
                return;
            }
            #endregion

            #region LOGIN
            InsereLog("Logando...", false);
            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Logando...");

            robo.Login(txtUsuario.Text, txtSenha.Text, ref erro);

            if (erro != "")
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao tentar logar - Encerrando processo");
                InsereLog(erro, true);
                return;
            }
            #endregion

            tb_cons_massiva cons;

            ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest dataClientRequest;
            bool flClienteNovo = false;

            do
            {
                //Verifica se é para parar a Thread
                VerificarRegistros(threadNum);

                erro = "";
                contador++;

                //Reserva o registro pra consultar
                cons = context.ReservarConsulta(chkApenasNovos.Checked, chkApenasErro.Checked);

                if (cons != null)
                {
                    if (!robo.BuscaCPF(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, erro);
                        if (erro == "CLIENTE NOVO - PULAR")
                        {
                            contador--;
                            continue;
                        }
                        else
                        {
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                        }
                        continue;
                    }

                    if (!robo.ClicaSimulacao(ref erro))
                    {
                        context.SalvaErro(cons.id.Value, erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.ClicaINSS(ref erro))
                    {
                        context.SalvaErro(cons.id.Value, erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (flClienteNovo)
                    {
                        dataClientRequest = new ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest()
                        {
                            Phone = null,
                            AdditionalDocuments = new List<ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType>(),
                            Benefit = new ValidacaoBeneficioBot.JSONObjects.BenefitType()
                            {
                                BenefitKind = new ValidacaoBeneficioBot.JSONObjects.BenefitKindType()
                                {
                                    Code = int.Parse(cons.esp)
                                },
                                CBCIfPayer = "237",//TODO: INSERIR CODIGO DO BANCO
                                DispatchYear = 2014, //TODO: INSERIR ANO CORRETO
                                BenefitNumber = cons.nb,
                                OwnsLawfulAgent = true //TODO: VERIFICAR VALOR CORRETO
                            },
                            DateBirthday = cons.dtnasc.Value,
                            Document = cons.cpf,
                            ExternalId = "", // PREENCHIDO NA CLASSE DO ROBO
                            FullName = cons.nome,
                            Income = new ValidacaoBeneficioBot.JSONObjects.IncomeType()
                            {
                                GrossIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                                NetIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                                DatePayday = new DateTime(2022, 01, 05), //TODO: VERIFICAR VALOR CORRETO
                                CalculatedPayday = false,
                                Discount = "0"
                            },
                            PostCode = cons.cep,
                            HasValidToken = false,
                            AttendanceType = "BY_PHONE",
                            Consultant = new ValidacaoBeneficioBot.JSONObjects.ConsultantType() { TaxId = "" }, // PREENCHIDO NA CLASSE DO ROBO
                            OriginalAttendanceType = "BY_PHONE",
                            DataprevAllowanceType = null
                        };

                        //TODO: MUDAR PRA RG
                        dataClientRequest.AdditionalDocuments.Add(new ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType() { Type = "RG", Number = cons.nb });

                        robo.BuscaOfertasDisponiveis(cons.cpf, cons.nome, dataClientRequest, ref erro);

                        #region REFAZ PROCESSOS ANTERIORES APÓS CADASTRAR CLIENTE
                        if (!robo.BuscaCPF(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        if (!robo.ClicaSimulacao(ref erro))
                        {
                            context.SalvaErro(cons.id.Value, erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        if (!robo.ClicaINSS(ref erro))
                        {
                            context.SalvaErro(cons.id.Value, erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }
                        #endregion
                    }

                    dados = robo.BuscaOfertasDisponiveis(cons.cpf, cons.nome, null, ref erro);

                    if (erro == "")
                    {
                        InsereDados(dados, cons.id.Value);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Cliente processado e produtos capturados");
                    }
                    else
                    {
                        context.SalvaErro(cons.id.Value, erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    IncrementaProcessado();
                }
                else
                {
                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Sem mais registros para consultar");
                    return;
                }

            } while (cons != null);
        }

        private void RoboV2(int threadNum)
        {
            var erro = "";
            var dados = new DadosClienteProduto();

            var robo = new ValidacaoBeneficioBot.Bot2();

            #region INICIALIZA ROBÔ
            InsereLog("Inicializando Robô...", false);
            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Inicializando Robô...");

            robo.BotInicialize(ref erro);

            if (erro != "")
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao inicializar o robô - Encerrando processo");
                InsereLog("Erro método BotInicialize: : " + erro, true);
                return;
            }
            #endregion

            #region LOGIN
            InsereLog("Logando...", false);
            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Logando...");

            robo.Login(txtUsuario.Text, txtSenha.Text, ref erro);

            if (erro != "")
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao tentar logar - Encerrando processo");
                InsereLog("Erro método Login: " + erro, true);
                return;
            }
            #endregion

            tb_cons_massiva cons;

            ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest dataClientRequest;
            bool flClienteNovo = false;

            do
            {
                //Verifica se é para parar a Thread
                VerificarRegistros(threadNum);

                erro = "";
                contador++;

                //Reserva o registro pra consultar
                cons = context.ReservarConsulta(chkApenasNovos.Checked, chkApenasErro.Checked);

                if (cons != null)
                {
                    #region Recupera dados cliente
                    dataClientRequest = new ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest()
                    {
                        Phone = null,
                        AdditionalDocuments = new List<ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType>(),
                        Benefit = new ValidacaoBeneficioBot.JSONObjects.BenefitType()
                        {
                            BenefitKind = new ValidacaoBeneficioBot.JSONObjects.BenefitKindType()
                            {
                                Code = int.Parse(cons.esp)
                            },
                            CBCIfPayer = "237",//TODO: INSERIR CODIGO DO BANCO
                            DispatchYear = 2014, //TODO: INSERIR ANO CORRETO
                            BenefitNumber = cons.nb,
                            OwnsLawfulAgent = true, //TODO: VERIFICAR VALOR CORRETO
                            AvailableCardMargin = null,
                            AvailableMargin = null
                        },
                        DateBirthday = cons.dtnasc.Value,
                        Document = cons.cpf,
                        ExternalId = "", // PREENCHIDO NA CLASSE DO ROBO
                        FullName = cons.nome,
                        Income = new ValidacaoBeneficioBot.JSONObjects.IncomeType()
                        {
                            GrossIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                            NetIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                            DatePayday = new DateTime(2022, 01, 05), //TODO: VERIFICAR VALOR CORRETO
                            CalculatedPayday = false,
                            Discount = "0"
                        },
                        PostCode = cons.cep,
                        HasValidToken = false,
                        AttendanceType = "BY_PHONE",
                        Consultant = new ValidacaoBeneficioBot.JSONObjects.ConsultantType() { TaxId = "" }, // PREENCHIDO NA CLASSE DO ROBO
                        OriginalAttendanceType = "BY_PHONE",
                        DataprevAllowanceType = null,
                        AllowDataprev = false,
                        AllowDataprevRemotely = false,
                        Attachments = new List<object>(),
                        //CreationDate = DateTime.Now,
                        AsyncTokenReceived = false,
                        //LastUpdateDate = DateTime.Now,
                        DurationSeconds = 0,
                        ActualStoreId = "",
                        DataprevAllowanceTypes = new List<object>()
                    };

                    //TODO: MUDAR PRA RG
                    dataClientRequest.AdditionalDocuments.Add(new ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType() { Type = "RG", Number = cons.nb });
                    #endregion

                    if (!robo.BuscaCPF(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, erro);
                        if (erro == "CLIENTE NOVO - PULAR")
                        {
                            contador--;
                            continue;
                        }
                        else
                        {
                            context.SalvaErro(cons.id.Value, "Erro método BuscaCPF: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                        }
                        continue;
                    }

                    if (flClienteNovo)
                    {

                    }

                    if (!robo.ClicaSimulacao(ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ClicaSimulacao: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.ClicaFonteINSS(ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ClicaINSS: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.ContinuarSemConsulta(ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ContinuarSemConsulta: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.SelecionaOfertaGEV(dataClientRequest, new DateTime(2022, 01, 05), ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método SelecionaOfertaGEV: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    dados = robo.Simular(dataClientRequest, ref erro);

                    if (erro == "")
                    {
                        InsereDados(dados, cons.id.Value);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Cliente processado e produtos capturados");
                    }
                    else
                    {
                        context.SalvaErro(cons.id.Value, "Erro método BuscaOfertasDisponiveis: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    //TODO: robo.SalvarRascunho();

                    IncrementaProcessado();
                }
                else
                {
                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Sem mais registros para consultar");
                    return;
                }

            } while (cons != null);
        }

        private void RoboV3(int threadNum)
        {
            try
            {
                var erro = "";
                var dados = new DadosClienteProduto();

                var robo = new ValidacaoBeneficioBot.Bot3();

                #region INICIALIZA ROBÔ
                InsereLog("Inicializando Robô... (v3)", false);
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Inicializando Robô...");

                robo.BotInicialize(ref erro);

                if (erro != "")
                {
                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao inicializar o robô - Encerrando processo");
                    InsereLog("Erro método BotInicialize: : " + erro, true);
                    return;
                }
                #endregion

                #region LOGIN
                InsereLog("THREAD " + threadNum.ToString() + ": Logando...", false);
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Logando...");

                robo.Login(txtUsuario.Text, txtSenha.Text, ref erro);

                if (erro != "")
                {
                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao tentar logar - Encerrando processo");
                    InsereLog("Erro método Login: " + erro, true);
                    return;
                }
                #endregion

                tb_cons_massiva cons;

                ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest dataClientRequest;
                bool flClienteNovo = false;

                do
                {
                    //Verifica se é para parar a Thread
                    VerificarRegistros(threadNum);

                    erro = "";
                    contador++;

                    //Reserva o registro pra consultar
                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Reservando registro...");
                    cons = context.ReservarConsulta(chkApenasNovos.Checked, chkApenasErro.Checked);

                    if (cons != null)
                    {
                        #region Recupera dados cliente
                        dataClientRequest = new ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest()
                        {
                            Phone = null,
                            AdditionalDocuments = new List<ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType>(),
                            Benefit = new ValidacaoBeneficioBot.JSONObjects.BenefitType()
                            {
                                BenefitKind = new ValidacaoBeneficioBot.JSONObjects.BenefitKindType()
                                {
                                    Code = int.Parse(cons.esp)
                                },
                                CBCIfPayer = "237",//TODO: INSERIR CODIGO DO BANCO
                                DispatchYear = 2014, //TODO: INSERIR ANO CORRETO
                                BenefitNumber = cons.nb,
                                OwnsLawfulAgent = true, //TODO: VERIFICAR VALOR CORRETO
                                AvailableCardMargin = null,
                                AvailableMargin = null
                            },
                            DateBirthday = cons.dtnasc.Value,
                            Document = cons.cpf,
                            ExternalId = "", // PREENCHIDO NA CLASSE DO ROBO
                            FullName = cons.nome,
                            Income = new ValidacaoBeneficioBot.JSONObjects.IncomeType()
                            {
                                GrossIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                                NetIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                                DatePayday = new DateTime(2022, 01, 05), //TODO: VERIFICAR VALOR CORRETO
                                CalculatedPayday = false,
                                Discount = "0"
                            },
                            PostCode = cons.cep,
                            HasValidToken = false,
                            AttendanceType = "BY_PHONE",
                            Consultant = new ValidacaoBeneficioBot.JSONObjects.ConsultantType() { TaxId = "" }, // PREENCHIDO NA CLASSE DO ROBO
                            OriginalAttendanceType = "BY_PHONE",
                            DataprevAllowanceType = null,
                            AllowDataprev = false,
                            AllowDataprevRemotely = false,
                            Attachments = new List<object>(),
                            //CreationDate = DateTime.Now,
                            AsyncTokenReceived = false,
                            //LastUpdateDate = DateTime.Now,
                            DurationSeconds = 0,
                            ActualStoreId = "",
                            DataprevAllowanceTypes = new List<object>()
                        };

                        //TODO: MUDAR PRA RG
                        dataClientRequest.AdditionalDocuments.Add(new ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType() { Type = "RG", Number = cons.nb });
                        #endregion

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Buscando cliente...");
                        if (!robo.BuscaCliente(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, erro);
                            if (erro == "CLIENTE NOVO - PULAR")
                            {
                                contador--;
                                continue;
                            }
                            else
                            {
                                context.SalvaErro(cons.id.Value, "Erro método BuscaCliente: " + erro);
                                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                                IncrementaErro();
                            }
                            continue;
                        }

                        if (flClienteNovo)
                        {
                            if (!robo.BuscaCliente(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                            {
                                context.SalvaErro(cons.id.Value, erro);
                                if (erro == "CLIENTE NOVO - PULAR")
                                {
                                    contador--;
                                    continue;
                                }
                                else
                                {
                                    context.SalvaErro(cons.id.Value, "Erro método BuscaCliente (Segunda chamada): " + erro);
                                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                                    IncrementaErro();
                                }
                                continue;
                            }
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Clicando em Simulacao...");
                        if (!robo.ClicaSimulacao(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método ClicaSimulacao: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Clicando INSS...");
                        if (!robo.ClicaINSS(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método ClicaINSS: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Aceitando Oferta GEV...");
                        if (!robo.AceitaOfertaGEV(dataClientRequest, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método AceitaOfertaGEV: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Atendimento Telefônico...");
                        if (!robo.AtendimentoTelefonico(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método AtendimentoTelefonico: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Continuando processo...");
                        if (!robo.ContinuarProcesso(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método ContinuarProcesso: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Continuar sem Cadastro...");
                        if (!robo.ContinuarSemCadastro(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método ContinuarSemCadastro: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Informando dados pessoais...");
                        if (!robo.EtapaDadosPessoais(dataClientRequest, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método EtapaDadosPessoais: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Informando dados do benefício...");
                        if (!robo.EtapaDadosBeneficios(dataClientRequest, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método EtapaDadosBeneficios: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Informando dados de renda...");
                        if (!robo.EtapaDadosRenda(dataClientRequest, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método EtapaDadosRenda: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Conferindo dados...");
                        if (!robo.EtapaConferencia(dataClientRequest, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, "Erro método EtapaConferencia: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Simulando...");
                        dados = robo.Simular(dataClientRequest, ref erro);

                        if (erro == "")
                        {
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Cadastrando produtos e simulações...");
                            InsereDados(dados, cons.id.Value);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Cliente processado e produtos capturados");
                        }
                        else
                        {
                            context.SalvaErro(cons.id.Value, "Erro método BuscaOfertasDisponiveis: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                            continue;
                        }

                        //TODO: robo.SalvarRascunho();

                        IncrementaProcessado();
                    }
                    else
                    {
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Sem mais registros para consultar");
                        return;
                    }

                } while (cons != null);
            }
            catch (Exception ex)
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro no robô");
                AlteraTexto("\r\n" + ex.Message);

                if (ex.InnerException != null)
                    AlteraTexto("\r\n" + ex.InnerException.Message);

                ListaThreads[threadNum - 1].Abort();
                return;
            }
        }

        private void RoboV4(int threadNum)
        {
            var erro = "";
            var dados = new DadosClienteProduto();

            var robo = new ValidacaoBeneficioBot.Bot4();

            #region INICIALIZA ROBÔ
            InsereLog("Inicializando Robô...", false);
            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Inicializando Robô...");

            robo.BotInicialize(ref erro);

            if (erro != "")
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao inicializar o robô - Encerrando processo");
                InsereLog("Erro método BotInicialize: : " + erro, true);
                return;
            }
            #endregion

            #region LOGIN
            InsereLog("Logando...", false);
            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Logando...");

            robo.Login(txtUsuario.Text, txtSenha.Text, ref erro);

            if (erro != "")
            {
                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro ao tentar logar - Encerrando processo");
                InsereLog("Erro método Login: " + erro, true);
                return;
            }
            #endregion

            tb_cons_massiva cons;

            ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest dataClientRequest;
            bool flClienteNovo = false;

            do
            {
                //Verifica se é para parar a Thread
                VerificarRegistros(threadNum);

                erro = "";
                contador++;

                //Reserva o registro pra consultar
                cons = context.ReservarConsulta(chkApenasNovos.Checked, chkApenasErro.Checked);

                if (cons != null)
                {
                    #region Recupera dados cliente
                    dataClientRequest = new ValidacaoBeneficioBot.JSONObjects.DataClientPutRequest()
                    {
                        Phone = null,
                        AdditionalDocuments = new List<ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType>(),
                        Benefit = new ValidacaoBeneficioBot.JSONObjects.BenefitType()
                        {
                            BenefitKind = new ValidacaoBeneficioBot.JSONObjects.BenefitKindType()
                            {
                                Code = int.Parse(cons.esp)
                            },
                            CBCIfPayer = "237",//TODO: INSERIR CODIGO DO BANCO
                            DispatchYear = 2014, //TODO: INSERIR ANO CORRETO
                            BenefitNumber = cons.nb,
                            OwnsLawfulAgent = true, //TODO: VERIFICAR VALOR CORRETO
                            AvailableCardMargin = null,
                            AvailableMargin = null
                        },
                        DateBirthday = cons.dtnasc.Value,
                        Document = cons.cpf,
                        ExternalId = "", // PREENCHIDO NA CLASSE DO ROBO
                        FullName = cons.nome,
                        Income = new ValidacaoBeneficioBot.JSONObjects.IncomeType()
                        {
                            GrossIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                            NetIncome = int.Parse(cons.renda.Substring(0, cons.renda.IndexOf('.'))),
                            DatePayday = new DateTime(2022, 01, 05), //TODO: VERIFICAR VALOR CORRETO
                            CalculatedPayday = false,
                            Discount = "0"
                        },
                        PostCode = cons.cep,
                        HasValidToken = false,
                        AttendanceType = "BY_PHONE",
                        Consultant = new ValidacaoBeneficioBot.JSONObjects.ConsultantType() { TaxId = "" }, // PREENCHIDO NA CLASSE DO ROBO
                        OriginalAttendanceType = "BY_PHONE",
                        DataprevAllowanceType = null,
                        AllowDataprev = false,
                        AllowDataprevRemotely = false,
                        Attachments = new List<object>(),
                        //CreationDate = DateTime.Now,
                        AsyncTokenReceived = false,
                        //LastUpdateDate = DateTime.Now,
                        DurationSeconds = 0,
                        ActualStoreId = "",
                        DataprevAllowanceTypes = new List<object>()
                    };

                    //TODO: MUDAR PRA RG
                    dataClientRequest.AdditionalDocuments.Add(new ValidacaoBeneficioBot.JSONObjects.AdditionalDocumentsType() { Type = "RG", Number = cons.nb });
                    #endregion

                    if (!robo.BuscaCliente(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, erro);
                        if (erro == "CLIENTE NOVO - PULAR")
                        {
                            contador--;
                            continue;
                        }
                        else
                        {
                            context.SalvaErro(cons.id.Value, "Erro método BuscaCliente: " + erro);
                            AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                            IncrementaErro();
                        }
                        continue;
                    }

                    if (flClienteNovo)
                    {
                        if (!robo.BuscaCliente(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref flClienteNovo, ref erro))
                        {
                            context.SalvaErro(cons.id.Value, erro);
                            if (erro == "CLIENTE NOVO - PULAR")
                            {
                                contador--;
                                continue;
                            }
                            else
                            {
                                context.SalvaErro(cons.id.Value, "Erro método BuscaCliente (Segunda chamada): " + erro);
                                AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                                IncrementaErro();
                            }
                            continue;
                        }
                    }

                    if (!robo.ClicaSimulacao(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ClicaSimulacao: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.ClicaINSS(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ClicaINSS: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.AceitaOfertaGEV(dataClientRequest, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método AceitaOfertaGEV: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.AtendimentoTelefonico(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método AtendimentoTelefonico: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.ContinuarProcesso(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ContinuarProcesso: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.ContinuarSemCadastro(cons.cpf, cons.PrimeiroNome, cons.Sobrenome, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método ContinuarSemCadastro: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.EtapaDadosPessoais(dataClientRequest, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método EtapaDadosPessoais: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.EtapaDadosBeneficios(dataClientRequest, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método EtapaDadosBeneficios: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.EtapaDadosRenda(dataClientRequest, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método EtapaDadosRenda: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    if (!robo.EtapaConferencia(dataClientRequest, ref erro))
                    {
                        context.SalvaErro(cons.id.Value, "Erro método EtapaConferencia: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    dados = robo.Simular(dataClientRequest, ref erro);

                    if (erro == "")
                    {
                        InsereDados(dados, cons.id.Value);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Cliente processado e produtos capturados");
                        context.SalvaProcessado(cons.id.Value);
                    }
                    else
                    {
                        context.SalvaErro(cons.id.Value, "Erro método BuscaOfertasDisponiveis: " + erro);
                        AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Erro");
                        IncrementaErro();
                        continue;
                    }

                    //TODO: robo.SalvarRascunho();

                    IncrementaProcessado();
                }
                else
                {
                    AlteraTexto("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " Thread " + threadNum.ToString() + " - Sem mais registros para consultar");
                    return;
                }

            } while (cons != null);
        }

        private void InsereDados(DadosClienteProduto dados, Guid idConsulta)
        {
            tb_cons_massiva_produtos prodModel;
            tb_cons_massiva_simulacoes simuModel;

            foreach (var prod in dados.Produtos)
            {
                prodModel = new tb_cons_massiva_produtos()
                {
                    id = Guid.NewGuid(),
                    id_cons_massiva = idConsulta,
                    produto = prod.Nome,

                    vl_margem_calculada = prod.ValorMargemCalculada,
                    regra_margem = prod.PoliticaMargemNome,
                    //DtSimulacao = atendimentoOperacaoSimulacaoCPList.dataHoraSimulacao,
                    //DtLiberacao =
                    //DtProxCorte = prod.corte
                    //DtPrimeiroVencimento = dataPrimeiroVencimento
                };

                if (prod.CreditoPessoalModel != null)
                {
                    if (prod.CreditoPessoalModel.PrazoSelecionado != null)
                    {
                        prodModel.vl_parcela = prod.CreditoPessoalModel.PrazoSelecionado.ValorParcela;
                        prodModel.prazo = prod.CreditoPessoalModel.PrazoSelecionado.Prazo;
                        prodModel.vl_liberado = prod.CreditoPessoalModel.PrazoSelecionado.ValorLiquidoTotal;
                    }
                    prodModel.carencia = prod.CreditoPessoalModel.QuantidadeDiasCarencia;
                    prodModel.vl_credito = prod.CreditoPessoalModel.ValorCredito;
                    prodModel.vl_parcela_credito = prod.CreditoPessoalModel.ValorParcela;
                }

                if (prod.CartaoModel != null && prod.Nome == "CARTÃO MÚLTIPLO")
                {
                    prodModel.vl_limite_calculado = prod.CartaoModel.ValorLimitePreAprovado;
                    //prodModel.TpEntrega = 
                }

                if (prod.ContaCorrenteModel != null && prod.Nome == "CONTA CORRENTE")
                {
                    prodModel.vl_limite_calculado = prod.ContaCorrenteModel.ValorLimitePreAprovado;
                    //prodModel.DeclaracaoFinsAbertura = 
                }

                if (prod.ContaCorrenteModel != null && prod.Nome == "SEGURO DE VIDA")
                {
                    //planos
                    //prodModel.DeclaracaoFinsAbertura = 
                }

                prodModel = context.tb_cons_massiva_produtos.Add(prodModel);
                context.SaveChanges();

                if (prod.CreditoPessoalModel != null)
                {
                    foreach (var prz in prod.CreditoPessoalModel.PrazoList)
                    {
                        simuModel = new tb_cons_massiva_simulacoes()
                        {
                            id = Guid.NewGuid(),
                            id_cons_massiva_produto = prodModel.id,
                            prazo = prz.Prazo.ToString(),
                            vl_parcela = decimal.Parse(prz.ValorParcela.ToString()),
                            tx_mensal = decimal.Parse(prz.ValorTaxaMensal.ToString()),
                            cet_mensal = decimal.Parse(prz.ValorCetMensal.ToString()),
                            cet_anual = decimal.Parse(prz.ValorCetAnual.ToString()),
                            vl_credito = decimal.Parse(prz.ValorCredito.ToString()),
                            vl_max_min_parcelas = null,
                            vl_min_max_credito = null,
                            plano = null
                        };

                        context.tb_cons_massiva_simulacoes.Add(simuModel);
                    }

                    context.SaveChanges();
                }
            }
        }

        private void VerificarRegistros(int threadNum)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(VerificarRegistros), new object[] { threadNum });
                return;
            }

            int qtMax = int.Parse(txtQtProcessos.Text);

            if (contador >= qtMax)
            {
                ListaThreads[threadNum - 1].Abort();

                txtUsuario.Enabled = true;
                txtSenha.Enabled = true;
                txtQtProcessos.Enabled = true;
                btnIniciar.Enabled = true;
                btnParar.Enabled = false;
                lblWorking.Visible = false;
                chkApenasNovos.Enabled = true;
                chkApenasErro.Enabled = true;
                MessageBox.Show("Processo Finalizado", "Validação de Benefícios", MessageBoxButtons.OK);
            }
        }

        private void AlteraTexto(string texto)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AlteraTexto), new object[] { texto });
                return;
            }

            txtLog.Text = texto + txtLog.Text;
            lblWorking.Focus();
        }

        private void ExibeLabel(bool exibe)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(ExibeLabel), new object[] { exibe });
                return;
            }

            lblWorking.Visible = exibe;
        }

        private void HabilitaBotoes(bool habilitaIniciar, bool habilitaParar)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool, bool>(HabilitaBotoes), new object[] { habilitaIniciar, habilitaParar });
                return;
            }

            btnIniciar.Enabled = habilitaIniciar;
            btnParar.Enabled = habilitaParar;
        }

        private void InsereLog(string mensagem, bool erro)
        {
            if (erro) mensagem = "ERRO " + mensagem;

            //System.IO.File.WriteAllLines(nmArquivo, new String[] { DateTime.Now.ToString("yyyy/MM/dd_hh:mm:ss") + " - " + mensagem });
        }

        private void IncrementaErro()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(IncrementaErro));
                return;
            }
            qtErros++;
            lblErros.Text = qtErros.ToString("000");
            IncrementaTotal();
        }

        private void IncrementaProcessado()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(IncrementaProcessado));
                return;
            }
            qtProcessados++;
            lblProcessados.Text = qtProcessados.ToString("000");
            IncrementaTotal();
        }

        private void IncrementaTotal()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(IncrementaTotal));
                return;
            }
            lblTotal.Text = (qtProcessados + qtErros).ToString("000");
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            foreach (var thread in ListaThreads)
                thread.Abort();

            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            txtQtProcessos.Enabled = true;
            btnIniciar.Enabled = true;
            btnParar.Enabled = false;
            lblWorking.Visible = false;
            chkApenasNovos.Enabled = true;
            chkApenasErro.Enabled = true;
        }
    }
}

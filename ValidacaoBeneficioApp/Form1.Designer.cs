namespace ValidacaoBeneficioApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblErros = new System.Windows.Forms.Label();
            this.lblProcessados = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkApenasErro = new System.Windows.Forms.CheckBox();
            this.chkApenasNovos = new System.Windows.Forms.CheckBox();
            this.btnParar = new System.Windows.Forms.Button();
            this.cboThreads = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtQtProcessos = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWorking = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblStatusConsulta = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grdProdutos = new System.Windows.Forms.DataGridView();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSimulacoes = new System.Windows.Forms.DataGridView();
            this.prazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tx_mensal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cet_mensal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cet_anual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_max_min_parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_min_max_parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblConsultaWorking = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtConsultaUsuario = new System.Windows.Forms.TextBox();
            this.txtConsultaCPF = new System.Windows.Forms.TextBox();
            this.txtConsultaSenha = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAProcessar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSimulacoes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 622);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lblWorking);
            this.tabPage1.Controls.Add(this.txtLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(466, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Robô";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.64995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.64995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.64995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.64995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.64995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.75025F));
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblErros, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProcessados, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 575);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 18);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Location = new System.Drawing.Point(378, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(73, 18);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "000000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(303, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblErros
            // 
            this.lblErros.AutoSize = true;
            this.lblErros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErros.Location = new System.Drawing.Point(228, 0);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(69, 18);
            this.lblErros.TabIndex = 8;
            this.lblErros.Text = "000000";
            // 
            // lblProcessados
            // 
            this.lblProcessados.AutoSize = true;
            this.lblProcessados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessados.Location = new System.Drawing.Point(78, 0);
            this.lblProcessados.Name = "lblProcessados";
            this.lblProcessados.Size = new System.Drawing.Size(69, 18);
            this.lblProcessados.TabIndex = 7;
            this.lblProcessados.Text = "000000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Processados";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(153, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 18);
            this.label12.TabIndex = 2;
            this.label12.Text = "Erros";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkApenasErro);
            this.groupBox1.Controls.Add(this.chkApenasNovos);
            this.groupBox1.Controls.Add(this.btnParar);
            this.groupBox1.Controls.Add(this.cboThreads);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.txtQtProcessos);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // chkApenasErro
            // 
            this.chkApenasErro.AutoSize = true;
            this.chkApenasErro.Location = new System.Drawing.Point(110, 84);
            this.chkApenasErro.Name = "chkApenasErro";
            this.chkApenasErro.Size = new System.Drawing.Size(112, 17);
            this.chkApenasErro.TabIndex = 11;
            this.chkApenasErro.Text = "Apenas com Erros";
            this.chkApenasErro.UseVisualStyleBackColor = true;
            // 
            // chkApenasNovos
            // 
            this.chkApenasNovos.AutoSize = true;
            this.chkApenasNovos.Checked = true;
            this.chkApenasNovos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApenasNovos.Location = new System.Drawing.Point(8, 84);
            this.chkApenasNovos.Name = "chkApenasNovos";
            this.chkApenasNovos.Size = new System.Drawing.Size(96, 17);
            this.chkApenasNovos.TabIndex = 11;
            this.chkApenasNovos.Text = "Apenas Novos";
            this.chkApenasNovos.UseVisualStyleBackColor = true;
            // 
            // btnParar
            // 
            this.btnParar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParar.Location = new System.Drawing.Point(259, 68);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(90, 33);
            this.btnParar.TabIndex = 3;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // cboThreads
            // 
            this.cboThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThreads.Enabled = false;
            this.cboThreads.FormattingEnabled = true;
            this.cboThreads.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboThreads.Location = new System.Drawing.Point(371, 16);
            this.cboThreads.MaxDropDownItems = 4;
            this.cboThreads.Name = "cboThreads";
            this.cboThreads.Size = new System.Drawing.Size(74, 21);
            this.cboThreads.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Qt. Processos por hora:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Número de Threads:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Senha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciar.Location = new System.Drawing.Point(355, 68);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 33);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtQtProcessos
            // 
            this.txtQtProcessos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQtProcessos.Location = new System.Drawing.Point(371, 42);
            this.txtQtProcessos.MaxLength = 200;
            this.txtQtProcessos.Name = "txtQtProcessos";
            this.txtQtProcessos.Size = new System.Drawing.Size(74, 20);
            this.txtQtProcessos.TabIndex = 0;
            this.txtQtProcessos.Text = "10";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(55, 16);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(110, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(55, 42);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '@';
            this.txtSenha.Size = new System.Drawing.Size(110, 20);
            this.txtSenha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // lblWorking
            // 
            this.lblWorking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorking.BackColor = System.Drawing.Color.LightGreen;
            this.lblWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.Location = new System.Drawing.Point(6, 115);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(454, 23);
            this.lblWorking.TabIndex = 5;
            this.lblWorking.Text = "ROBÔ TRABALHANDO";
            this.lblWorking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWorking.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(6, 141);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(454, 428);
            this.txtLog.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblStatusConsulta);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(466, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblStatusConsulta
            // 
            this.lblStatusConsulta.Location = new System.Drawing.Point(3, 570);
            this.lblStatusConsulta.Name = "lblStatusConsulta";
            this.lblStatusConsulta.Size = new System.Drawing.Size(460, 23);
            this.lblStatusConsulta.TabIndex = 3;
            this.lblStatusConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.grdProdutos, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grdSimulacoes, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 118);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(460, 449);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // grdProdutos
            // 
            this.grdProdutos.AllowUserToAddRows = false;
            this.grdProdutos.AllowUserToDeleteRows = false;
            this.grdProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.produto});
            this.grdProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProdutos.Location = new System.Drawing.Point(3, 3);
            this.grdProdutos.Name = "grdProdutos";
            this.grdProdutos.ReadOnly = true;
            this.grdProdutos.Size = new System.Drawing.Size(454, 218);
            this.grdProdutos.TabIndex = 0;
            this.grdProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProdutos_CellContentClick);
            // 
            // produto
            // 
            this.produto.HeaderText = "produto";
            this.produto.Name = "produto";
            this.produto.ReadOnly = true;
            this.produto.Width = 420;
            // 
            // grdSimulacoes
            // 
            this.grdSimulacoes.AllowUserToAddRows = false;
            this.grdSimulacoes.AllowUserToDeleteRows = false;
            this.grdSimulacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSimulacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prazo,
            this.vl_parcela,
            this.tx_mensal,
            this.cet_mensal,
            this.cet_anual,
            this.vl_credito,
            this.vl_max_min_parcelas,
            this.vl_min_max_parcelas,
            this.plano});
            this.grdSimulacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSimulacoes.Location = new System.Drawing.Point(3, 227);
            this.grdSimulacoes.Name = "grdSimulacoes";
            this.grdSimulacoes.ReadOnly = true;
            this.grdSimulacoes.Size = new System.Drawing.Size(454, 219);
            this.grdSimulacoes.TabIndex = 1;
            // 
            // prazo
            // 
            this.prazo.HeaderText = "Prazo";
            this.prazo.Name = "prazo";
            this.prazo.ReadOnly = true;
            // 
            // vl_parcela
            // 
            this.vl_parcela.HeaderText = "Parcela";
            this.vl_parcela.Name = "vl_parcela";
            this.vl_parcela.ReadOnly = true;
            // 
            // tx_mensal
            // 
            this.tx_mensal.HeaderText = "Tx. Mensal";
            this.tx_mensal.Name = "tx_mensal";
            this.tx_mensal.ReadOnly = true;
            // 
            // cet_mensal
            // 
            this.cet_mensal.HeaderText = "CET Mensal";
            this.cet_mensal.Name = "cet_mensal";
            this.cet_mensal.ReadOnly = true;
            // 
            // cet_anual
            // 
            this.cet_anual.HeaderText = "CET Anual";
            this.cet_anual.Name = "cet_anual";
            this.cet_anual.ReadOnly = true;
            // 
            // vl_credito
            // 
            this.vl_credito.HeaderText = "Vl. Crédito";
            this.vl_credito.Name = "vl_credito";
            this.vl_credito.ReadOnly = true;
            // 
            // vl_max_min_parcelas
            // 
            this.vl_max_min_parcelas.HeaderText = "Vl. Max Min Parcelas";
            this.vl_max_min_parcelas.Name = "vl_max_min_parcelas";
            this.vl_max_min_parcelas.ReadOnly = true;
            // 
            // vl_min_max_parcelas
            // 
            this.vl_min_max_parcelas.HeaderText = "Vl. Min Max Parcelas";
            this.vl_min_max_parcelas.Name = "vl_min_max_parcelas";
            this.vl_min_max_parcelas.ReadOnly = true;
            // 
            // plano
            // 
            this.plano.HeaderText = "Plano";
            this.plano.Name = "plano";
            this.plano.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblConsultaWorking);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtConsultaUsuario);
            this.groupBox2.Controls.Add(this.txtConsultaCPF);
            this.groupBox2.Controls.Add(this.txtConsultaSenha);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados";
            // 
            // lblConsultaWorking
            // 
            this.lblConsultaWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaWorking.Location = new System.Drawing.Point(267, 9);
            this.lblConsultaWorking.Name = "lblConsultaWorking";
            this.lblConsultaWorking.Size = new System.Drawing.Size(187, 94);
            this.lblConsultaWorking.TabIndex = 9;
            this.lblConsultaWorking.Text = "Robô Trabalhando";
            this.lblConsultaWorking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConsultaWorking.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "CPF:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Senha:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Usuário:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(171, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 72);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtConsultaUsuario
            // 
            this.txtConsultaUsuario.Location = new System.Drawing.Point(55, 16);
            this.txtConsultaUsuario.Name = "txtConsultaUsuario";
            this.txtConsultaUsuario.Size = new System.Drawing.Size(110, 20);
            this.txtConsultaUsuario.TabIndex = 0;
            // 
            // txtConsultaCPF
            // 
            this.txtConsultaCPF.Location = new System.Drawing.Point(55, 68);
            this.txtConsultaCPF.Name = "txtConsultaCPF";
            this.txtConsultaCPF.Size = new System.Drawing.Size(110, 20);
            this.txtConsultaCPF.TabIndex = 1;
            // 
            // txtConsultaSenha
            // 
            this.txtConsultaSenha.Location = new System.Drawing.Point(55, 42);
            this.txtConsultaSenha.Name = "txtConsultaSenha";
            this.txtConsultaSenha.PasswordChar = '@';
            this.txtConsultaSenha.Size = new System.Drawing.Size(110, 20);
            this.txtConsultaSenha.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 13);
            this.label18.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 2;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(190, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 21);
            this.label6.TabIndex = 4;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAProcessar
            // 
            this.lblAProcessar.AutoSize = true;
            this.lblAProcessar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAProcessar.Location = new System.Drawing.Point(283, 0);
            this.lblAProcessar.Name = "lblAProcessar";
            this.lblAProcessar.Size = new System.Drawing.Size(87, 21);
            this.lblAProcessar.TabIndex = 5;
            this.lblAProcessar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(376, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 21);
            this.label8.TabIndex = 6;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 628);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validação de Benefício";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSimulacoes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAProcessar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.ComboBox cboThreads;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQtProcessos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblErros;
        private System.Windows.Forms.Label lblProcessados;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkApenasErro;
        private System.Windows.Forms.CheckBox chkApenasNovos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtConsultaUsuario;
        private System.Windows.Forms.TextBox txtConsultaCPF;
        private System.Windows.Forms.TextBox txtConsultaSenha;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView grdProdutos;
        private System.Windows.Forms.DataGridView grdSimulacoes;
        private System.Windows.Forms.Label lblConsultaWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn prazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn tx_mensal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cet_mensal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cet_anual;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_max_min_parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_min_max_parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano;
        private System.Windows.Forms.Label lblStatusConsulta;
    }
}


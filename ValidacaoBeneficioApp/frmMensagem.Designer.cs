namespace ValidacaoBeneficioApp
{
    partial class frmMensagem
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
            this.lblErro = new System.Windows.Forms.Label();
            this.txtDescErro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblErro
            // 
            this.lblErro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblErro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErro.Location = new System.Drawing.Point(12, 9);
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(510, 73);
            this.lblErro.TabIndex = 0;
            this.lblErro.Text = "ERRO";
            this.lblErro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescErro
            // 
            this.txtDescErro.BackColor = System.Drawing.Color.White;
            this.txtDescErro.Location = new System.Drawing.Point(11, 85);
            this.txtDescErro.Multiline = true;
            this.txtDescErro.Name = "txtDescErro";
            this.txtDescErro.ReadOnly = true;
            this.txtDescErro.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescErro.Size = new System.Drawing.Size(510, 271);
            this.txtDescErro.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(510, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "FECHAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescErro);
            this.Controls.Add(this.lblErro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMensagem";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMensagem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblErro;
        private System.Windows.Forms.TextBox txtDescErro;
        private System.Windows.Forms.Button button1;
    }
}
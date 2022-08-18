using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidacaoBeneficioApp
{
    public partial class frmMensagem : Form
    {
        public frmMensagem(string erro, string descErro)
        {
            InitializeComponent();

            lblErro.Text = erro;
            txtDescErro.Text = descErro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmMensagem_Load(object sender, EventArgs e)
        {

        }
    }
}

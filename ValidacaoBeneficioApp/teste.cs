using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidacaoBeneficioBot;

namespace ValidacaoBeneficioApp
{
    public partial class teste : Form
    {
        public teste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Dummy().Transforma(textBox1.Text);
        }
    }
}

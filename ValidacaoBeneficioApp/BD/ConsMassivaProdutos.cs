using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioApp.BD
{
    internal class ConsMassivaProdutos
    {
        public Guid id { get; set; }
        public string cpf { get; set; }
        public DateTime dtExtracao { get; set; }
        public string jsonProdutos { get; set; }
    }
}

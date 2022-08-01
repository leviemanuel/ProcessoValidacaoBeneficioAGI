using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacaoBeneficioBot.JSONObjects;

namespace ValidacaoBeneficioBot.Objs
{
    public class DadosClienteProduto
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public List<ProdutoResponse> Produtos { get; set; }
    }
}

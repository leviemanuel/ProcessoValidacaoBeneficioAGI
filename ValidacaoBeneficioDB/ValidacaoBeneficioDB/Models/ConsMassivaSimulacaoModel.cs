using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioDB.Models
{
    [Table("tb_cons_massiva_simulacoes")]
    public class ConsMassivaSimulacaoModel
    {
        [Column("id")]
        public Guid? Id { get; set; }

        [Column("id_cons_massiva_produto")]
        public string IdConsMassivaProduto { get; set; }

        [Column("prazo")]
        public string Prazo { get; set; }

        [Column("vl_parcela")]
        public string VlParcela { get; set; }

        [Column("tx_mensal")]
        public string TxMensal { get; set; }

        [Column("cet_mensal")]
        public string CETMensal { get; set; }

        [Column("cet_anual")]
        public string CETAnual { get; set; }

        [Column("vl_credito")]
        public string VlCredito { get; set; }

        [Column("vl_max_min_parcelas")]
        public string VlMaxMinParcelas { get; set; }

        [Column("vl_min_max_credito")]
        public string VlMinMaxCredito { get; set; }

        [Column("plano")]
        public string Plano { get; set; }
    }
}

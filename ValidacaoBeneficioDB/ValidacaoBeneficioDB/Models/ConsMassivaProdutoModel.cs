using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioDB.Models
{
    [Table("tb_cons_massiva_produtos")]
    public class ConsMassivaProdutoModel
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_cons_massiva")]
        public Guid IdConsMassiva { get; set; }

        [Column("produto")]
        public string Produto { get; set; }

        [Column("vl_parcela")]
        public decimal? VlParcela { get; set; }

        [Column("prazo")]
        public int? Prazo { get; set; }

        [Column("vl_liberado")]
        public decimal? VlLiberado { get; set; }

        [Column("vl_margem_calculada")]
        public decimal? VlMargemCalculada { get; set; }

        [Column("regra_margem")]
        public string RegraMargem { get; set; }

        [Column("dt_simulacao")]  
        public DateTime? DtSimulacao { get; set; }

        [Column("dt_liberacao")]
        public DateTime? DtLiberacao { get; set; }

        [Column("dt_prox_corte")]
        public DateTime? DtProxCorte { get; set; }

        [Column("dt_primeiro_vencimento")]
        public DateTime? DtPrimeiroVencimento { get; set; }

        [Column("carencia")]
        public int? Carencia { get; set; }

        [Column("vl_credito")]
        public decimal? VlCredito { get; set; }

        [Column("vl_parcela_credito")]
        public decimal? VlParcelaCredito { get; set; }

        [Column("prazo_selecionado")]
        public Guid? PrazoSelecionado { get; set; }

        [Column("tp_entrega")]
        public string TpEntrega { get; set; }

        [Column("vl_limite_calculado")]
        public decimal? VlLimiteCalculado { get; set; }

        [Column("declarado_fins_abertura")]
        public string DeclaracaoFinsAbertura { get; set; }
    }
}

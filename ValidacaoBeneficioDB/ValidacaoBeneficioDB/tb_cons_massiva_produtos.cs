namespace ValidacaoBeneficioDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_cons_massiva_produtos
    {
        public Guid id { get; set; }

        public Guid id_cons_massiva { get; set; }

        [StringLength(50)]
        public string produto { get; set; }

        public decimal? vl_parcela { get; set; }

        public int? prazo { get; set; }

        public decimal? vl_liberado { get; set; }

        public decimal? vl_margem_calculada { get; set; }

        [StringLength(50)]
        public string regra_margem { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_simulacao { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_liberacao { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_prox_corte { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_primeiro_vencimento { get; set; }

        public int? carencia { get; set; }

        public decimal? vl_credito { get; set; }

        public decimal? vl_parcela_credito { get; set; }

        public Guid? prazo_selecionado { get; set; }

        [StringLength(100)]
        public string tp_entrega { get; set; }

        public decimal? vl_limite_calculado { get; set; }

        [StringLength(200)]
        public string declaracao_fins_abertura { get; set; }
    }
}

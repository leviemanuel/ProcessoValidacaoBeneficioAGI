namespace ValidacaoBeneficioDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_cons_massiva_simulacoes
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Key]
        public Guid id { get; set; }

        public Guid id_cons_massiva_produto { get; set; }

        [StringLength(50)]
        public string prazo { get; set; }

        public decimal? vl_parcela { get; set; }

        public decimal? tx_mensal { get; set; }

        public decimal? cet_mensal { get; set; }

        public decimal? cet_anual { get; set; }

        public decimal? vl_credito { get; set; }

        public decimal? vl_max_min_parcelas { get; set; }

        public decimal? vl_min_max_credito { get; set; }

        [StringLength(50)]
        public string plano { get; set; }
    }
}

namespace ValidacaoBeneficioDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_erro_param
    {
        [Key]
        [Column(Order = 0)]
        public Guid id_erro_param { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string erro_param_texto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string tipo_erro { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int status_cons_massiva { get; set; }
    }
}

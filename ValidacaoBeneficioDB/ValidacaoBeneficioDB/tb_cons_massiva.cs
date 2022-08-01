namespace ValidacaoBeneficioDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tb_cons_massiva
    {
        [Key]
        [StringLength(20)]
        public string cpf { get; set; }

        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(20)]
        public string telefone { get; set; }

        [StringLength(15)]
        public string cep { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dtnasc { get; set; }

        [StringLength(20)]
        public string nb { get; set; }

        [StringLength(10)]
        public string esp { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_nb { get; set; }

        [StringLength(50)]
        public string renda { get; set; }

        public Guid? id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dtconsulta { get; set; }

        [StringLength(1000)]
        public string erro { get; set; }

        public int? status { get; set; }

        public string PrimeiroNome
        {
            //get { return ""; }
            get { return nome.Split(' ').First(); }
        }

        public string Sobrenome
        {
            //get { return ""; }
            get { return nome.Replace(PrimeiroNome, "").TrimStart(); }
        }
    }
}

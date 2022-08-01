using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioDB.Models
{
    [Table("tb_cons_massiva")]
    public class ConsMassivaModel
    {
        [Column("id")]
        public Guid? Id { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("cep")]
        public string CEP { get; set; }

        //[Column("dtnasc")]
        //public DateTime? DtNasc { get; set; }

        [Column("nb")]
        public string NB { get; set; }

        [Column("esp")]
        public string ESP { get; set; }

        //[Column("dt_nb")]
        //public DateTime? DtNb { get; set; }

        [Column("renda")]
        public string Renda { get; set; }

        //[Column("dtconsulta")]
        //public DateTime? DtConsulta { get; set; }

        [Column("erro")]
        public string Erro { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        public string PrimeiroNome
        {
            get { return ""; }
            //get { return Nome.Split(' ').First(); }
        }

        public string Sobrenome
        {
            get { return ""; }
            //get { return Nome.Replace(PrimeiroNome, "").TrimStart(); }
        }

    }
}

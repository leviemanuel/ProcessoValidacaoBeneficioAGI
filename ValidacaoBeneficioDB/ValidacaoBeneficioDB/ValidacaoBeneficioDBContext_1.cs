using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ValidacaoBeneficioDB
{
    public partial class ValidacaoBeneficioDBContext : DbContext
    {
        public ValidacaoBeneficioDBContext() : base("name=ValidacaoBeneficioDBContext") { }

        public virtual DbSet<tb_cons_massiva> tb_cons_massiva { get; set; }
        public virtual DbSet<tb_cons_massiva_produtos> tb_cons_massiva_produtos { get; set; }
        public virtual DbSet<tb_cons_massiva_simulacoes> tb_cons_massiva_simulacoes { get; set; }

        public tb_cons_massiva ReservarConsulta(bool flNovos, bool flErro)
        {
            //Database.BeginTransaction();

            //tb_cons_massiva consulta = new tb_cons_massiva();
            //consulta.id = Guid.NewGuid();
            //consulta.cpf = "00396804608";
            //consulta.nome = "JOSE PAULO SUPRIANO";

            //var consulta = tb_cons_massiva.Where(c=> c.cpf == "15062958865").FirstOrDefault();
            //var consulta = tb_cons_massiva.Where(c => !c.id.HasValue).FirstOrDefault();
            //var consulta = tb_cons_massiva.Where(c => c.erro == "Cliente novo - Não cadastrar").FirstOrDefault();

            tb_cons_massiva consulta;

            if (flNovos && flErro)
                consulta = tb_cons_massiva.Where(c => !c.id.HasValue || (c.id.HasValue && !string.IsNullOrEmpty(c.erro))).FirstOrDefault();
            else if (flNovos)
                consulta = tb_cons_massiva.Where(c => !c.id.HasValue).FirstOrDefault();
            else
                consulta = tb_cons_massiva.Where(c => c.id.HasValue && !string.IsNullOrEmpty(c.erro)).FirstOrDefault();

            consulta = tb_cons_massiva.Where(c => c.erro.Contains("Erro método BuscaCliente: Comprimento não pode ser menor que zero")).FirstOrDefault();

            if (consulta != null)
            {
                consulta.status = 1;
                consulta.id = Guid.NewGuid();
                consulta.dtconsulta = DateTime.Now;
                SaveChanges();
            }

            //Database.CurrentTransaction.Commit();

            return consulta;
        }

        public void SalvaErro(Guid id, string erro)
        {
            var consulta = tb_cons_massiva.Where(c => c.id == id).FirstOrDefault();

            if (consulta != null)
            {
                consulta.status = 9;
                consulta.erro = erro;
                SaveChanges();
            }
        }

        public void SalvaProcessado(Guid id)
        {
            var consulta = tb_cons_massiva.Where(c => c.id == id).FirstOrDefault();

            if (consulta != null)
            {
                consulta.status = 2;
                consulta.erro = null;

                SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.produto)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.vl_parcela)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.vl_liberado)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.vl_margem_calculada)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.regra_margem)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.vl_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.vl_parcela_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.tp_entrega)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.vl_limite_calculado)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos>()
                .Property(e => e.declaracao_fins_abertura)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.nb)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.esp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.renda)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva>()
                .Property(e => e.erro)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.prazo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.vl_parcela)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.tx_mensal)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.cet_mensal)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.cet_anual)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.vl_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.vl_max_min_parcelas)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.vl_min_max_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes>()
                .Property(e => e.plano)
                .IsUnicode(false);
        }
    }
}

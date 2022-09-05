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
        public virtual DbSet<tb_cons_massiva_02> tb_cons_massiva_02 { get; set; }
        public virtual DbSet<tb_cons_massiva_produtos_02> tb_cons_massiva_produtos_02 { get; set; }
        public virtual DbSet<tb_cons_massiva_simulacoes_02> tb_cons_massiva_simulacoes_02 { get; set; }
        public virtual DbSet<tb_erro_param> tb_erro_param { get; set; }

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

            //consulta = tb_cons_massiva.Where(c => c.status == 9).FirstOrDefault();

            //consulta = tb_cons_massiva.Where(c => c.cpf == "66723019920").FirstOrDefault();

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

        public tb_cons_massiva BuscarDadosCliente(string cpf)
        {
            tb_cons_massiva consulta;

            consulta = tb_cons_massiva.Where(c => c.cpf == cpf).FirstOrDefault();

            return consulta;
        }

        public void SalvaErro(Guid id, string erro, string erroSite)
        {
            var consulta = tb_cons_massiva.Where(c => c.id == id).FirstOrDefault();

            var erroParam = tb_erro_param.Where(e => e.erro_param_texto.Contains(erroSite)).FirstOrDefault();

            if (consulta != null)
            {
                if (erroParam != null)
                    consulta.status = erroParam.status_cons_massiva;
                else
                    consulta.status = 9;

                consulta.erro = erro;
                SaveChanges();
            }
        }

        public tb_cons_massiva_02 ReservarConsulta_02(bool flNovos, bool flErro)
        {
            tb_cons_massiva_02 consulta;

            if (flNovos && flErro)
                consulta = tb_cons_massiva_02.Where(c => !c.id.HasValue || (c.id.HasValue && !string.IsNullOrEmpty(c.erro))).FirstOrDefault();
            else if (flNovos)
                consulta = tb_cons_massiva_02.Where(c => !c.id.HasValue).FirstOrDefault();
            else
                consulta = tb_cons_massiva_02.Where(c => c.id.HasValue && !string.IsNullOrEmpty(c.erro)).FirstOrDefault();

            if (consulta != null)
            {
                consulta.status = 1;
                consulta.id = Guid.NewGuid();
                consulta.dtconsulta = DateTime.Now;
                SaveChanges();
            }

            return consulta;
        }

        public void SalvaErro_02(Guid id, string erro, string erroSite)
        {
            var consulta = tb_cons_massiva_02.Where(c => c.id == id).FirstOrDefault();

            var erroParam = tb_erro_param.Where(e => e.erro_param_texto.Contains(erroSite)).FirstOrDefault();

            if (consulta != null)
            {
                if (erroParam != null)
                    consulta.status = erroParam.status_cons_massiva;
                else
                    consulta.status = 9;

                consulta.erro = erro;
                SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region 01
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
                .HasPrecision(9, 4);

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

            modelBuilder.Entity<tb_erro_param>()
                .Property(e => e.erro_param_texto)
                .IsUnicode(false);

            modelBuilder.Entity<tb_erro_param>()
                .Property(e => e.tipo_erro)
                .IsUnicode(false);
            #endregion


            #region 02
            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.produto)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.vl_parcela)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.vl_liberado)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.vl_margem_calculada)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.regra_margem)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.vl_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.vl_parcela_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.tp_entrega)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.vl_limite_calculado)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_produtos_02>()
                .Property(e => e.declaracao_fins_abertura)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.nb)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.esp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.renda)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_02>()
                .Property(e => e.erro)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.prazo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.vl_parcela)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.tx_mensal)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.cet_mensal)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.cet_anual)
                .HasPrecision(9, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.vl_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.vl_max_min_parcelas)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.vl_min_max_credito)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tb_cons_massiva_simulacoes_02>()
                .Property(e => e.plano)
                .IsUnicode(false);

            #endregion
        }
    }
}

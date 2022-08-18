using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ValidacaoBeneficioDB
{
    public partial class ValidacaoBeneficioDBContext_2 : DbContext
    {
        public ValidacaoBeneficioDBContext_2()
            : base("name=Model1ValidacaoBeneficioDBContext_2")
        {
        }

        public virtual DbSet<tb_cons_massiva_produtos> tb_cons_massiva_produtos { get; set; }
        public virtual DbSet<tb_cons_massiva> tb_cons_massiva { get; set; }
        public virtual DbSet<tb_cons_massiva_simulacoes> tb_cons_massiva_simulacoes { get; set; }
        public virtual DbSet<tb_erro_param> tb_erro_param { get; set; }

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

            modelBuilder.Entity<tb_erro_param>()
                .Property(e => e.erro_param_texto)
                .IsUnicode(false);

            modelBuilder.Entity<tb_erro_param>()
                .Property(e => e.tipo_erro)
                .IsUnicode(false);
        }
    }
}

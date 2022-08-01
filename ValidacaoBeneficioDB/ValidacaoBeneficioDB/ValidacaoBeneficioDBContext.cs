using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacaoBeneficioDB.Models;

namespace ValidacaoBeneficioDB
{
    //public class ValidacaoBeneficioDBContext : DbContext
    //{
    //    public ValidacaoBeneficioDBContext() : base("Server=200.168.184.234,5200;Database=DB_DEV_ENRIQFORTAL;User Id=Yupp1e@fortal;Password=%0O61XPDmlBp0ko;") { }
    //    public DbSet<ConsMassivaModel> ConsultasMassivas { get; set; }
    //    public DbSet<ConsMassivaProdutoModel> ConsultasMassivasProdutos { get; set; }
    //    public DbSet<ConsMassivaSimulacaoModel> ConsultasMassivasSimulacoes { get; set; }

        

    //    public Guid InsereProduto(ConsMassivaProdutoModel produto)
    //    {
    //        produto.Id = new Guid();

    //        ConsultasMassivasProdutos.Add(produto);
    //        SaveChanges();

    //        return produto.Id;
    //    }
    //    public Guid InsereSimulacao(ConsMassivaSimulacaoModel simulacao)
    //    {
    //        simulacao.Id = new Guid();

    //        ConsultasMassivasSimulacoes.Add(simulacao);
    //        SaveChanges();

    //        return simulacao.Id.Value;
    //    }
    //}
}

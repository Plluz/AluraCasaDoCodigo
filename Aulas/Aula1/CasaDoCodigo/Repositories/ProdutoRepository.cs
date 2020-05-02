using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext contexto;
        private readonly Microsoft.EntityFrameworkCore.DbSet<Produto> dbSet;

        public ProdutoRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<Produto>();
        }

        public IList<Produto> GetProdutos()
        {
            return contexto.Set<Produto>().ToList();
        }

        public void GravarProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            contexto.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}

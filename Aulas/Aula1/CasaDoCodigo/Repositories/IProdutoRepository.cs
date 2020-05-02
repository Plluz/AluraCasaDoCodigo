using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void GravarProdutos(List<Livro> livros);
    }
}
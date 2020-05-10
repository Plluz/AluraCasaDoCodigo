using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public CadastroRepository Update(int cadastroId, Cadastro novoCadastro)
        {
            throw new System.NotImplementedException();
        }
    }
}

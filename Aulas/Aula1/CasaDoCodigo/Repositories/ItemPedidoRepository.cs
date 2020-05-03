using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = dbSet.Where(ip => ip.Id == itemPedido.Id).SingleOrDefault();

            if (itemPedidoDB != null)
            {
                itemPedidoDB.UpdateQuantidade(itemPedido.Quantidade);
                contexto.SaveChanges();
            }
        }
    }
}

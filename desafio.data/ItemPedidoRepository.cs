using desafio.data.Base;
using desafio.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace desafio.data
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>
    {
        public IEnumerable<ItemPedido> GetByPedido(int idPedido)
        {
            return this.table.Where((i) => i.PedidoId == idPedido);
            
        }

        public override void Update(ItemPedido entity)
        {

            var item = this.GetById(entity.Id);
            item.Quantidade = entity.Quantidade;
            item.PrecoUnitario = entity.PrecoUnitario;
            base.Update(item);
        }
    }
}

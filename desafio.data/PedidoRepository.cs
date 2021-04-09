using desafio.data.Base;
using desafio.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace desafio.data
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
    

        public Pedido GetByCodigo(string codigoPedido)
        {
            Pedido pedido = this.table.Where((p) => p.Codigo == codigoPedido).SingleOrDefault();
            

            return pedido;
        }

    
    }
}

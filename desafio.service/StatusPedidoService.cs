using desafio.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using desafio.domain.enumerator;

namespace desafio.service
{
    public class StatusPedidoService
    {

        private static StatusPedidoService instance = null;

        private StatusPedidoService()
        {

        }

        public static StatusPedidoService GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatusPedidoService();
                }
                return instance;
            }
        }

        PedidoService pedidoService = new PedidoService();
        
        public RetornoStatusPedido ValidadeStatus(StatusPedido statusPedido)
        {
            Pedido pedido = pedidoService.GetByCodigo(statusPedido.pedido);
         
            return statusPedido.validate(pedido);

        }

    }
}

using desafio.data;
using desafio.domain;
using desafio.service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.service
{
    public class ItemPedidoService : ServiceBase<ItemPedido, ItemPedidoRepository>
    {

        private static ItemPedidoService instance = null;

        private ItemPedidoService()
        {

        }

        public static ItemPedidoService GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemPedidoService();
                }
                return instance;
            }
        }


        public IEnumerable<ItemPedido> GetByPedido(int idPedido)
        {
            return repository.GetByPedido(idPedido);

        }
    }
}

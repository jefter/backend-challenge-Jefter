using desafio.data;
using desafio.domain;
using desafio.service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.service
{
    public class PedidoService : ServiceBase<Pedido, PedidoRepository>
    {
        const string MSG_VALIDA_CODIGO_PEDIDO = "Códido do pedido já informado";

        ItemPedidoService itemPedidoService = ItemPedidoService.GetInstance;

        public override void Insert(Pedido entity)
        {
            Pedido existPedido = this.GetByCodigo(entity.Codigo);

            if (existPedido != null)
            {
                throw new Exception(MSG_VALIDA_CODIGO_PEDIDO);

            }

            if (entity.isValid())
            {
                base.Insert(entity);
            }
        }

        public Pedido GetByCodigo(string codigoPedido)
        {
            Pedido pedido = repository.GetByCodigo(codigoPedido);

            if (pedido != null)
            {
                var itens = itemPedidoService.GetByPedido((int)pedido.Id);
                pedido.Itens = itens;
            }

            return pedido;
        }

        public override void Update(Pedido pedido)
        {

            foreach (var item in pedido.Itens)
            {
                if (item.isValid())
                    itemPedidoService.Update(item);
            }

            //base.Update(entity);
        }

        public override Pedido GetById(object id)
        {
            Pedido pedido = repository.GetByCodigo(id.ToString());

            if (pedido != null)
            {
                var itens = itemPedidoService.GetByPedido(pedido.Id);
                pedido.Itens = itens;
            }

            return pedido;
        }

        public override IEnumerable<Pedido> GetAll()
        {
            var pedidos = base.GetAll();

            foreach (var item in pedidos)
            {
                item.Itens = itemPedidoService.GetByPedido((int)item.Id);
            }

            return pedidos;
        }

        public override void Delete(int id)
        {
            var itens = itemPedidoService.GetByPedido((int)id);
            if (itens != null)
            {
                foreach (var item in itens)
                {
                    itemPedidoService.Delete(item.Id);
                }
            }

            base.Delete(id);
        }
    }
}

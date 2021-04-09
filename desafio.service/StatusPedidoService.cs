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


        PedidoService pedidoService = new  PedidoService();
        const string APROVADO = "APROVADO";
        const string REPROVADO = "REPROVADO";

        public RetornoStatusPedido ValidadeStatus(StatusPedido statusPedido)
        {

            RetornoStatusPedido result = new RetornoStatusPedido();
            result.status = new List<STATUS>();
            result.pedido = statusPedido.pedido;
            Pedido pedido = pedidoService.GetByCodigo(statusPedido.pedido);
            int qtdTotalItens;
            decimal valorTotalPedido;
            //pedido não for localizado no banco de dados.
            if (pedido == null)
            {
                result.status.Add(domain.enumerator.STATUS.CODIGO_PEDIDO_INVALIDO);
                return result;
            }

            qtdTotalItens = pedido.GetTotalItens;
            valorTotalPedido = pedido.GetValorTotal;


            //pedido for localizado no banco de dados. status for igual a REPROVADO
            if (statusPedido.status.Equals(REPROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.REPROVADO);

            }

            /*
              pedido for localizado no banco de dados.

itensAprovados for igual a quantidade de itens do pedido.

valorAprovado for igual o valor total do pedido.

status for igual a APROVADO.
             */

         
            if (qtdTotalItens == statusPedido.itensAprovado && valorTotalPedido == statusPedido.valorAprovado && statusPedido.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO);
            }

            /*
             pedido for localizado no banco de dados.

valorAprovado for menor que o valor total do pedido

status for igual a APROVADO
             */

            if (statusPedido.valorAprovado < valorTotalPedido && statusPedido.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_VALOR_A_MENOR);
            }

            /*
             * pedido for localizado no banco de dados.

itensAprovados for menor que a quantidade de itens do pedido.

status for igual a APROVADO

             */

            if (statusPedido.itensAprovado < qtdTotalItens && statusPedido.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_QTD_A_MENOR);
            }


            /*
             * pedido for localizado no banco de dados.

valorAprovado for maior que o valor total do pedido

status for igual a APROVADO
             */
            if (statusPedido.valorAprovado > valorTotalPedido && statusPedido.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_VALOR_A_MAIOR);
            }

            /*
             * pedido for localizado no banco de dados.

itensAprovados for maior que a quantidade de itens do pedido.

status for igual a APROVAD
             */
            if (statusPedido.itensAprovado > qtdTotalItens && statusPedido.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_QTD_A_MAIOR);
            }

            return result;

        }

    }
}

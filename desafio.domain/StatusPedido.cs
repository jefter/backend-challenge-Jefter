using desafio.domain.enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace desafio.domain
{
    public class StatusPedido
    {
        const string APROVADO = "APROVADO";
        const string REPROVADO = "REPROVADO";

        public string status { get; set; }
        public int itensAprovado { get; set; }
        public int valorAprovado { get; set; }
        public string pedido { get; set; }

        public RetornoStatusPedido validate(Pedido pedido)
        {
            try
            {

           
            int qtdTotalItens;
            decimal valorTotalPedido;
            RetornoStatusPedido result = new RetornoStatusPedido();
            result.status = new List<STATUS>();
            result.pedido = this.pedido;

            if (pedido == null)
            {
                result.status.Add(domain.enumerator.STATUS.CODIGO_PEDIDO_INVALIDO);
                return result;
            }

            qtdTotalItens = pedido.GetTotalItens;
            valorTotalPedido = pedido.GetValorTotal;


            //pedido for localizado no banco de dados. status for igual a REPROVADO
            if (this.status.Equals(REPROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.REPROVADO);

            }

            /*
              pedido for localizado no banco de dados.

itensAprovados for igual a quantidade de itens do pedido.

valorAprovado for igual o valor total do pedido.

status for igual a APROVADO.
             */


            if (qtdTotalItens == this.itensAprovado && valorTotalPedido == this.valorAprovado && this.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO);
            }

            /*
             pedido for localizado no banco de dados.

valorAprovado for menor que o valor total do pedido

status for igual a APROVADO
             */

            if (this.valorAprovado < valorTotalPedido && this.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_VALOR_A_MENOR);
            }

            /*
             * pedido for localizado no banco de dados.

itensAprovados for menor que a quantidade de itens do pedido.

status for igual a APROVADO

             */

            if (this.itensAprovado < qtdTotalItens && this.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_QTD_A_MENOR);
            }


            /*
             * pedido for localizado no banco de dados.

valorAprovado for maior que o valor total do pedido

status for igual a APROVADO
             */
            if (this.valorAprovado > valorTotalPedido && this.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_VALOR_A_MAIOR);
            }

            /*
             * pedido for localizado no banco de dados.

itensAprovados for maior que a quantidade de itens do pedido.

status for igual a APROVAD
             */
            if (this.itensAprovado > qtdTotalItens && this.status.Equals(APROVADO))
            {
                result.status.Add(domain.enumerator.STATUS.APROVADO_QTD_A_MAIOR);
            }

            return result;
            }
            catch (Exception e) 
            {

                throw e;
            }
        }

    }

    public class RetornoStatusPedido
    {
        public List<STATUS> status { get; set; }
        
        public string pedido { get; set; }

        public override bool Equals(object obj)
        {
            RetornoStatusPedido item = (RetornoStatusPedido) obj;

            if (item.pedido != this.pedido)
                return false;


            return Enumerable.SequenceEqual(this.status, item.status);
        }

    }
}

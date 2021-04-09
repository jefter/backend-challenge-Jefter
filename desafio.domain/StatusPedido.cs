using desafio.domain.enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace desafio.domain
{
    public class StatusPedido
    {
        public string status { get; set; }
        public int itensAprovado { get; set; }
        public int valorAprovado { get; set; }
        public string pedido { get; set; }

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

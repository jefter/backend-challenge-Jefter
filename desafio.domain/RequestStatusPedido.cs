using desafio.domain.enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.domain
{
  public  class RequestStatusPedido
    {

        public  STATUS Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }

    }
}

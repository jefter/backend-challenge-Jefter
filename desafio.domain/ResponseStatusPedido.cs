using desafio.domain.enumerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.domain
{
   public class ResponseStatusPedido
    {
        public string Pedido { get; set; }
     

        public List<STATUS> Status { get; set; }


    }
}

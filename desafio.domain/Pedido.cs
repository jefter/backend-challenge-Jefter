using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace desafio.domain
{
   public class Pedido : EntityBase

    {
        const string MSG_VALIDA_CODIGO_PEDIDO = "Códido do pedido não informado";
        public IEnumerable<ItemPedido> Itens { get; set; }
        [JsonProperty("pedido")]

        public string Codigo { get; set; }

        public override bool isValid()
        {

            if (String.IsNullOrEmpty(this.Codigo))
                throw new Exception(MSG_VALIDA_CODIGO_PEDIDO);


            foreach (var item in this.Itens)
            {
                item.isValid();
            }
            return true;
        }

        public int GetTotalItens
        {
            get
            {
                if (this.Itens != null)
                    return this.Itens.Sum((i) => i.Quantidade);
                else
                    return 0;
            }
        }

        public decimal GetValorTotal
        {
            get
            {
                if (this.Itens != null)
                    return this.Itens.Sum((i) => i.PrecoUnitario * i.Quantidade);
                else
                    return 0;
            }
        }

    }
}

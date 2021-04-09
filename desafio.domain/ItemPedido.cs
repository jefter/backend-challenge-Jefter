using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.domain
{

    public class ItemPedido : Item
    {

        const string MSG_VALIDA_QUANTIDADE_MENOR_ZERO = "Quantidade do item {0} inválida";


        [JsonProperty("qtd")]

        public int Quantidade { get; set; }
        public int PedidoId { get; set; }

        public override bool isValid()
        {
                       
            if (this.Quantidade <= 0)
                throw new Exception(String.Format(MSG_VALIDA_QUANTIDADE_MENOR_ZERO, this.Descricao));

            base.isValid();

            return true;
        }

    }
}

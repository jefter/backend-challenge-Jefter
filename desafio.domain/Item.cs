using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.domain
{
    public class Item : EntityBase
    {

        const string MSG_VALIDA_DESCRICAO_NULL = "Descrição do item inválida";
        const string MSG_VALIDA_PRECO_UNIT = "Valor do item {0} inválido";

        [JsonProperty("descricao")]

        public string Descricao { get; set; }
        [JsonProperty("precoUnitario")]

        public decimal PrecoUnitario { get; set; }

        public override bool isValid()
        {

            if (String.IsNullOrEmpty(this.Descricao))
                throw new Exception(MSG_VALIDA_DESCRICAO_NULL);

            if (this.PrecoUnitario <= 0)
                throw new Exception(String.Format(MSG_VALIDA_PRECO_UNIT, this.Descricao));

            return true;
        }

    }
}

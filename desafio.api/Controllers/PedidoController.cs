using desafio.api.Base;
using desafio.domain;
using desafio.service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.api.Controllers
{
    public class PedidoController : BaseCrudController<PedidoService, Pedido>
    {
     
    }
}

using desafio.api.Base;
using desafio.domain;
using desafio.service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : Controller
    {
        StatusPedidoService statusPedidoService = StatusPedidoService.GetInstance;

        [HttpPost]
        public IActionResult Status([FromBody] dynamic request)
        {
            string message = "OK";

            try
            {
                StatusPedido statusPedido = JsonConvert.DeserializeObject<StatusPedido>(request.ToString());

                RetornoStatusPedido retornoStatusPedido = statusPedidoService.ValidadeStatus(statusPedido);

                return Ok(retornoStatusPedido);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Ok(new ResponseModel() { Data = null, Success = false, Message = message, Code = ResponseCodeType.GENERAL_ERROR });
            }
        }
    }
}

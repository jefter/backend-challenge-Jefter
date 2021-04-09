using Microsoft.VisualStudio.TestTools.UnitTesting;
using desafio.service;
using System;
using System.Collections.Generic;
using System.Text;
using desafio.domain;
using desafio.domain.enumerator;

namespace desafio.service.Tests
{
    [TestClass()]
    public class StatusPedidoServiceTests
    {
        [TestMethod]
        public void ValidadeStatusTest()
        {

            StatusPedidoService service =  StatusPedidoService.GetInstance;
            RetornoStatusPedido retornoStatusPedidoEsperado;
            RetornoStatusPedido retornoStatusPedidoObtido;
            StatusPedido statusPedido;

            /**************************** #1 ****************************/

            statusPedido = new StatusPedido()
            {
                status = "APROVADO",
                itensAprovado = 3,
                valorAprovado = 20,
                pedido = "123456"
            };


            retornoStatusPedidoEsperado = new RetornoStatusPedido()
            {
                pedido = "123456",
                status = new List<domain.enumerator.STATUS> { STATUS.APROVADO }
            };

            retornoStatusPedidoObtido = service.ValidadeStatus(statusPedido);

            Assert.AreEqual(retornoStatusPedidoEsperado, retornoStatusPedidoObtido);

            /**************************** #2 ****************************/


            statusPedido = new StatusPedido()
            {
                status = "APROVADO",
                itensAprovado = 3,
                valorAprovado = 10,
                pedido = "123456"
            };


            retornoStatusPedidoEsperado = new RetornoStatusPedido()
            {
                pedido = "123456",
                status = new List<domain.enumerator.STATUS> { STATUS.APROVADO_VALOR_A_MENOR }
            };

            retornoStatusPedidoObtido = service.ValidadeStatus(statusPedido);

            Assert.AreEqual(retornoStatusPedidoEsperado, retornoStatusPedidoObtido);

            /**************************** #3 ****************************/


            statusPedido = new StatusPedido()
            {
                status = "APROVADO",
                itensAprovado = 4,
                valorAprovado = 21,
                pedido = "123456"
            };


            retornoStatusPedidoEsperado = new RetornoStatusPedido()
            {
                pedido = "123456",
                status = new List<domain.enumerator.STATUS> { STATUS.APROVADO_VALOR_A_MAIOR, STATUS.APROVADO_QTD_A_MAIOR }
            };

            retornoStatusPedidoObtido = service.ValidadeStatus(statusPedido);

            Assert.AreEqual(retornoStatusPedidoEsperado, retornoStatusPedidoObtido);

            /**************************** #4 ****************************/


            statusPedido = new StatusPedido()
            {
                status = "APROVADO",
                itensAprovado = 2,
                valorAprovado = 20,
                pedido = "123456"
            };


            retornoStatusPedidoEsperado = new RetornoStatusPedido()
            {
                pedido = "123456",
                status = new List<domain.enumerator.STATUS> { STATUS.APROVADO_QTD_A_MENOR }
            };

            retornoStatusPedidoObtido = service.ValidadeStatus(statusPedido);

            Assert.AreEqual(retornoStatusPedidoEsperado, retornoStatusPedidoObtido);

            /**************************** #5 ****************************/


            statusPedido = new StatusPedido()
            {
                status = "REPROVADO",
                itensAprovado = 0,
                valorAprovado = 0,
                pedido = "123456"
            };


            retornoStatusPedidoEsperado = new RetornoStatusPedido()
            {
                pedido = "123456",
                status = new List<domain.enumerator.STATUS> { STATUS.REPROVADO }
            };

            retornoStatusPedidoObtido = service.ValidadeStatus(statusPedido);

            Assert.AreEqual(retornoStatusPedidoEsperado, retornoStatusPedidoObtido);

            /**************************** #6 ****************************/


            statusPedido = new StatusPedido()
            {
                status = "APROVADO",
                itensAprovado = 3,
                valorAprovado = 20,
                pedido = "123456-N"
            };


            retornoStatusPedidoEsperado = new RetornoStatusPedido()
            {
                pedido = "123456",
                status = new List<domain.enumerator.STATUS> { STATUS.CODIGO_PEDIDO_INVALIDO }
            };

            retornoStatusPedidoObtido = service.ValidadeStatus(statusPedido);

            Assert.AreNotEqual(retornoStatusPedidoEsperado, retornoStatusPedidoObtido);

        }
    }
}
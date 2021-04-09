using desafio.domain;
using desafio.service.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.api.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseCrudController<S, T> : ControllerBase
             where T : EntityBase
         where S : IServices<T>, new()
    {

        protected S service;

        public BaseCrudController()
        {
            service = new S();
        }


        //[Authorize("Bearer")]
        [HttpGet]
        public virtual ResponseModel Get()
        {
            string message = "OK";
            try
            {

                ResponseModel response = new ResponseModel()
                {
                    Data = (List<T>)service.GetAll(),
                    Code = ResponseCodeType.SUCCESS,
                    Message = message,
                    Success = true

                };

                return response;

            }
            catch (Exception ex)
            {
                message = ex.Message;
              
                return  new ResponseModel() { Success = false, Message = message, Code = ResponseCodeType.GENERAL_ERROR };
            }
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        public ResponseModel GetId(string id)
        {
            string message = "OK";

            try
            {

                T result = service.GetById(id);

                ResponseModel response = new ResponseModel()
                {
                    Data = result,
                    Code = ResponseCodeType.SUCCESS,
                    Message = message,
                    Success = true

                };

                return response;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return new ResponseModel() { Success = false, Message = message, Code = ResponseCodeType.GENERAL_ERROR };
            }
        }

        // [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Insert([FromBody] dynamic request)
        {
            string message = "OK";

            try
            {
                T model = JsonConvert.DeserializeObject<T>(request.ToString());

                service.Insert(model);

                ResponseModel response = new ResponseModel()
                {
                    Data = null,
                    Code = ResponseCodeType.SUCCESS,
                    Message = message,
                    Success = true
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Ok(new ResponseModel() { Data = null, Success = false, Message = message, Code = ResponseCodeType.GENERAL_ERROR });
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        public IActionResult Update([FromBody] dynamic request)
        {
            string message = "OK";

            try
            {
                T model = JsonConvert.DeserializeObject<T>(request.ToString());

                service.Update(model);

                ResponseModel response = new ResponseModel()
                {
                    Data = null,
                    Code = ResponseCodeType.SUCCESS,
                    Message = message,
                    Success = true
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Ok(new ResponseModel() { Success = false, Message = message, Code = ResponseCodeType.GENERAL_ERROR });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string message = "OK";

            try
            {

                service.Delete(id);

                ResponseModel response = new ResponseModel()
                {
                    Data = null,
                    Code = ResponseCodeType.SUCCESS,
                    Message = message,
                    Success = true
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Ok(new ResponseModel() { Success = false, Message = message, Code = ResponseCodeType.GENERAL_ERROR });
            }
        }


    }
}

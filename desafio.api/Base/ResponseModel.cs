using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.api.Base
{
    public enum ResponseCodeType
    {

        GENERAL_ERROR = -1,
        SUCCESS =0
    }

    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public ResponseCodeType Code { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Results
{
    public class Response
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
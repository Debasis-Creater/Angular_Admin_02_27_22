using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel
{
   public  class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}

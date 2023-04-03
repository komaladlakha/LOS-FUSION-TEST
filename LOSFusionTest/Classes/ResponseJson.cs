using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOSFusionTest.Classes
{
    public class ResponseJson
    {
        public bool status { get; set; }
        public int statusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
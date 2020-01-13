using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EwelinkNet.API.Responses
{
    internal class WsUpdateResponse
    {
        public string action { get; set; }
        public string deviceid { get; set; }
        public string apikey { get; set; }
        public string userAgent { get; set; }
        public string sequence { get; set; }
        public int ts { get; set; }
        public string tempRec { get; set; }
        public dynamic @params { get; set; } = new ExpandoObject();
    }
}

using EwelinkNet.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EwelinkNet.Payloads
{
    public class WsUpdatePayload
    {
        public string action { get; internal set; }
        public string userAgent { get; internal set; }

        public string deviceid { get; internal set; }

        public string apikey { get; internal set; }
        public string selfApikey { get; internal set; }

        public dynamic @params { get; internal set; } = new ExpandoObject();

        public string sequence { get; internal set; }

        internal WsUpdatePayload(string deviceId, string apiKey, object @params)
        {
            var seq = EwelinkHelper.MakeSequence();

            action = "update";
            userAgent = "app";
            deviceid = deviceId;
            apikey = apiKey;
            selfApikey = apiKey;
            this.@params = @params;
            sequence = seq.sequence;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EwelinkNet.Helpers;

namespace EwelinkNet.Payloads
{
    public class ZeroConfUpdatePayload

    {
        public string sequence { get; }
        public string deviceid { get; }
        public string selfApikey { get; }
        public string iv { get; }
        public bool encrypt { get; } = true;
        public string data { get; }


        public ZeroConfUpdatePayload(string deviceId, string deviceKey, string selfApiKey, string payload)
        {
            var timeStamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            sequence = Math.Floor(timeStamp * 1000).ToString();

            deviceid = deviceId;
            selfApikey = selfApiKey;

            var encrypted = CryptoHelper.Encrypt(payload, deviceKey);
            data = encrypted.output;
            iv = encrypted.iv;
        }
    }
}

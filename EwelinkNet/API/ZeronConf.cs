using EwelinkNet.Payloads;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EwelinkNet.API
{
    public static class ZeronConf
    {
        public static string UpdateDevice(string url, string deviceId, string deviceKey, string selfApiKey, object @params)
        {
            var client = new RestClient(url);
            var request = new RestRequest("/switch", Method.POST);

            var payload = new ZeroConfUpdatePayload(deviceId, deviceKey, selfApiKey, JsonConvert.SerializeObject(@params));
            var body = JsonConvert.SerializeObject(payload);

            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var cancellationTokenSource = new CancellationTokenSource();
            var response = client.Execute(request);

            return response.Content;

        }
    }
}

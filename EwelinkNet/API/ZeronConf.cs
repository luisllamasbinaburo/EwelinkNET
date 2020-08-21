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
        public static async Task<string> UpdateDevice(string url, string endpoint, string deviceId, string deviceKey, string selfApiKey, object @params)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.POST);

            var payload = new ZeroConfUpdatePayload(deviceId, deviceKey, selfApiKey, JsonConvert.SerializeObject(@params));
            var body = JsonConvert.SerializeObject(payload);

            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            return response.Content;

        }
    }
}

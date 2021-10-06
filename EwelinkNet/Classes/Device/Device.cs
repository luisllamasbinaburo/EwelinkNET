using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EwelinkNet.API;
using EwelinkNet.Helpers.Extensions;
using EwelinkNet.Payloads;
using Newtonsoft.Json;

namespace EwelinkNet.Classes
{
    public class Device
    {
        public string deviceid { get; set; }
        public int uiid { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string devicekey { get; set; }
        public string apikey { get; set; }

        public string _id { get; set; }

        public string group { get; set; }
        public bool online { get; set; }

        public string location { get; set; }
        public string onlineTime { get; set; }
        public string createdAt { get; set; }
        public string ip { get; set; }
        public string offlineTime { get; set; }
        public string deviceStatus { get; set; }

        public string deviceUrl { get; set; }
        public string brandName { get; set; }
        public bool showBrand { get; set; }
        public string brandLogoUrl { get; set; }
        public string productModel { get; set; }
        public int __v { get; set; }

        public ExtraRoot extra { get; set; }
        public List<string> groups { get; set; }

        public dynamic devConfig { get; set; } = new ExpandoObject();
        public dynamic devGroups { get; set; } = new ExpandoObject();
        public dynamic @params { get; set; } = new ExpandoObject();
        public dynamic tags { get; set; } = new ExpandoObject();
        public dynamic sharedTo { get; set; } = new ExpandoObject();
        public dynamic settings { get; set; } = new ExpandoObject();


        public override string ToString() => $"{name} {deviceid}";


        [JsonIgnore]
        public Ewelink context { get; set; }

        [JsonIgnore]
        public string deviceName => Constants.DevicesUiid.GetDeviceNameByUiid(uiid);

        [JsonIgnore]
        public PhysicalAddress mac => PhysicalAddress.Parse(extra.extra.staMac.Replace(':', '-').ToUpper());

        [JsonIgnore]
        internal protected string channelName => Constants.DevicesSwitchName.GetDeviceSwitchByName(deviceName);


        public IPAddress GetIp() => context.Arptable.GetIPAddressByMac(mac).FirstOrDefault();

        public string GetParameter(string parameterName) => ExpandoHelpers.GetOrDefault(@params, parameterName);

        public void UpdateDevice(object payload)
        {
            var isPreviouslyConnected = context.webSocket.IsConnected;
            context.OpenWebSocket();
            Thread.Sleep(Constants.WebSocketApi.DELAY_MS);
            context.webSocket.UpdateDevice(apikey, deviceid, payload);
            if (!isPreviouslyConnected) context.CloseWebSocket();
        }

        public async Task ZeroConfUpdateDevice(object payload, string endpoint)
        {
            var url = Constants.URLs.GetZeroconfUrl(GetIp().ToString());
            await ZeronConf.UpdateDevice(url, endpoint, deviceid, devicekey, apikey, payload);
        }
    }
}

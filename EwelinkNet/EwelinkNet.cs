using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using EwelinkNet.Classes;
using EwelinkNet.Helpers.Extensions;
using System.Dynamic;
using EwelinkNet.Payloads;
using EwelinkNet.API.Responses;
using Mapster;
using EwelinkNet.Classes.Events;
using WebSocketSharp;
using System.Linq;

namespace EwelinkNet
{
    public class Ewelink
    {
        public event EventHandler<EvendDeviceUpdate> OnDeviceChanged;

        public string region { get; set; } = "us";
        public string email { get; set; }
        public string password { get; set; }
        public string at { get; set; }
        public string apikey { get; set; }



        [JsonIgnore]
        public ArpTable Arptable { get; set; } = new ArpTable();

        [JsonIgnore]
        internal Credentials Credentials { get; private set; }

        [JsonIgnore]
        public Device[] Devices { get; private set; }

        [JsonIgnore]
        internal API.WebSocket webSocket = new API.WebSocket();


        public Ewelink(string email, string password, string region = "us")
        {
            this.email = email;
            this.password = password;
            this.region = region;
        }

        public Ewelink(string credentialsFile)
        {
            RestoreCredenditalsFromFile(credentialsFile);
        }

        public async Task<Credentials> GetCredentials()
        {
            var url = Constants.URLs.GetApiUrl(region);

            var response = await API.Rest.GetCredentials(url, email, password);
            Credentials = JsonConvert.DeserializeObject<Credentials>(response);
            return Credentials;
        }

        public async Task<string> GetRegion()
        {
            var url = Constants.URLs.GetApiUrl("us");

            var response = await API.Rest.GetCredentials(url, email, password);
            dynamic credentials = JsonConvert.DeserializeObject<ExpandoObject>(response);
            region = credentials.region;
            return region;
        }

        public void StoreCredenditalsFromFile(string filename = "credentials.json") => System.IO.File.WriteAllText(filename, Credentials.AsJson());

        public void RestoreCredenditalsFromFile(string filename = "credentials.json") => Credentials = System.IO.File.ReadAllText(filename).FromJson<Credentials>();

        public void StoreDevicesToFile(string filename = "devices.json") => System.IO.File.WriteAllText(filename, Devices.AsJson());

        public void RestoreDevicesFromFile(string filename = "devices.json") => CreateDevices(System.IO.File.ReadAllText(filename).FromJson<Device[]>());

        public void RestoreArpTableFromFile(string filename = "arp-table.json") => Arptable.RestoreFromFile(filename);


        public async Task GetDevices()
        {
            var url = Constants.URLs.GetApiUrl(region);

            var response = await API.Rest.GetDevices(url, Credentials.at);
            CreateDevices(response);
        }

        private void CreateDevices(string json)
        {
            CreateDevices(JsonConvert.DeserializeObject<DeviceList>(json).devicelist.ToArray());
        }

        
        private Dictionary<string, Device> deviceCache = new Dictionary<string, Device>();

        private void CreateDevices(Device[] devices)
        {
            Devices = devices.Select(x => DeviceFactory.CreateDevice(this, x)).ToArray();
            deviceCache = Devices.ToDictionary(x => x.deviceid);
        }

        public void OpenWebSocket()
        {
            if (webSocket.IsConnected) return;
            webSocket.Connect(Credentials.at, Devices[0].apikey, Credentials.region);
            webSocket.OnMessage += handleWebsocketResponse;
        }

        private void handleWebsocketResponse(object sender, EventWebsocketMessage e)
        {
            var response = e.Message as WsUpdateResponse;
            if (response == null) return;

            if (deviceCache.ContainsKey(response.deviceid))
            {
                ExpandoHelpers.Map(response.@params, deviceCache[response.deviceid].@params);
                OnDeviceChanged.Emit(e, new EvendDeviceUpdate() { Device = deviceCache[response.deviceid] });
            }
        }

        public void CloseWebSocket()
        {
            if (!webSocket.IsConnected) return;
            webSocket.OnMessage -= handleWebsocketResponse;
            webSocket.Disconnect();
        }
    }
}

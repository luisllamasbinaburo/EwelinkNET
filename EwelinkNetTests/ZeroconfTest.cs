using System;
using Xunit;
using EwelinkNet;
using System.Threading.Tasks;
using System.Dynamic;
using EwelinkNet.Classes;
using System.Linq;
using EwelinkNet.Helpers.Extensions;
using System.Text.Json;
using Xunit.Abstractions;

namespace EwelinkNet.Tests
{
    public class ZeroconfTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;


        public ZeroconfTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.singleChannelDeviceId;
        }

        [Fact]
        public void ZeroconfMac()
        {
            var ewelink = new Ewelink("", "", "");
            ewelink.RestoreDevicesFromFile();
            ewelink.Arptable.RestoreFromFile();

            Device device = ewelink.Devices.First();
            var mac = device.mac;

            output.WriteLine(mac.ToString());

        }

        [Fact]
        public void ZeroconfGetIp()
        {
            var ewelink = new Ewelink("", "", "");
            ewelink.RestoreDevicesFromFile();
            ewelink.RestoreArpTableFromFile();

            Device device = ewelink.Devices.First();
            var ip = device.GetIp();

            output.WriteLine(ip.ToString());
        }

        [Fact]
        public async void LANTurnON()
        {
            var ewelink = new Ewelink("", "", "");
            ewelink.RestoreDevicesFromFile();
            ewelink.RestoreCredenditalsFromFile();
            ewelink.RestoreArpTableFromFile();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;

            await device.TurnOnLAN();
        }
    }
}

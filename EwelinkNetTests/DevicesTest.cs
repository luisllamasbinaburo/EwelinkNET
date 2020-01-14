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
    public class DevicesTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;
        private readonly string deviceName;


        public DevicesTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.singleChannelDeviceId;
            deviceName = testData.singleChannelDeviceName;
        }


        [Fact]
        public async Task GetDevices()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();

            output.WriteLine(ewelink.Devices.AsJson());
        }

        [Fact]
        public async void GetDeviceByDeviceId()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;

            output.WriteLine(device.AsJson());
        }

        [Fact]
        public async void GetDeviceByDeviceName()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.name.Contains(deviceName, StringComparison.OrdinalIgnoreCase)) as SwitchDevice;

            output.WriteLine(device.AsJson());
        }
    }
}

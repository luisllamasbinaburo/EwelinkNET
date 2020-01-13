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
    public class MultiChannelDeviceTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;


        public MultiChannelDeviceTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.multiChannelDeviceId;
        }


        [Fact]
        public async void GetChannel()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as MultiSwitchDevice;
            var state = device.GetState(0);

            output.WriteLine(state);
        }

        [Fact]
        public async void TurnOnDevice()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as MultiSwitchDevice;
            device.TurnOn();
        }

        [Fact]
        public async void TurnOffDevice()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as MultiSwitchDevice;
            device.TurnOff();
        }

        [Fact]
        public async void TurnOnChannel()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as MultiSwitchDevice;
            device.TurnOn(2);
        }

        [Fact]
        public async void TurnOffChannel()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as MultiSwitchDevice;
            device.TurnOff(1);
        }


    }
}

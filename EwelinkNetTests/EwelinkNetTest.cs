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
    public class EwelinkNetTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;


        public EwelinkNetTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.singleChannelDeviceId;
        }


        [Fact]
        public async Task GetCredentials()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();

            output.WriteLine(credentials.AsJson());
        }

              [Fact]
        public async Task GetRegion()
        {
            var ewelink = new Ewelink(Email, Password);
            var region = await ewelink.GetRegion();

            output.WriteLine(region);
        }

        [Fact]
        public async void StoreCredentialsFromFile()
        {

            var ewelink = new Ewelink(Email, Password, Region);
            await ewelink.GetCredentials();
            ewelink.StoreCredenditalsFromFile();
        }

        [Fact]
        public void RestoreCredentialsFromFile()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            ewelink.RestoreCredenditalsFromFile();

            output.WriteLine(ewelink.Credentials.AsJson());
        }

        [Fact]
        public async void StoreDevicesToFile()
        {

            var ewelink = new Ewelink(Email, Password, Region);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();
            ewelink.StoreDevicesToFile();
        }

        [Fact]
        public void RestoreDevicesFromFile()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            ewelink.RestoreDevicesFromFile();

            output.WriteLine(ewelink.Devices.AsJson());
        }
    }
}

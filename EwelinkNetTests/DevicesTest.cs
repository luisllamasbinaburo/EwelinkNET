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


        public DevicesTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
        }


        [Fact]
        public async Task GetDevices()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();

            output.WriteLine(ewelink.Devices.AsJson());
        }

    }
}

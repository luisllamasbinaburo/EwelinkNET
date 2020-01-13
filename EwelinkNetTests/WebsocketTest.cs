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
    public class WebsocketTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;


        public WebsocketTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.singleChannelDeviceId;
        }

        [Fact]
        public async void Open()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();

            ewelink.OpenWebSocket();
            ewelink.CloseWebSocket();
        }

        [Fact]
        public async void Listen()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var messages = "";
            ewelink.webSocket.OnMessage += (s, e) => messages += e.Message.AsJson();
            ewelink.OpenWebSocket();

            System.Threading.Thread.Sleep(2000);

            output.WriteLine(messages);
        }
    }
}

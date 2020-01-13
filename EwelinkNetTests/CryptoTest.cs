using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Dynamic;

namespace EwelinkNet.Tests
{
    public class CryptoTest
    {
        private readonly ITestOutputHelper output;
        private readonly dynamic testData;

        const string message = "{\"pulses\":[{\"pulse\":\"off\",\"width\":15000,\"outlet\":0},{\"pulse\":\"off\",\"width\":1000,\"outlet\":1},{\"pulse\":\"off\",\"width\":1000,\"outlet\":2}]}";

        const string encrypted = "1b9eRuvfMvVKXxLnVBSoAaYW9rWyzEm9+J9VOR2f5mKHAJGpQoQWh3Tf5jK4JuQAsZgpanaQyZNkEJZugitRQpNWqVB2RePdLj95TG49VxjUrVSbpZWYJwofEMMBDNwJU5okFC/5G8uWNYVp5+FM+wuZ5+jwR47K+nzuRMleycp7u1WXdQFaLhIgvUgTKdUg";
        const string key = "99999999-0000-1111-2222-aaaaaaaaaaa";
        const string iv = "xt0Yu7GBKxV3snrJW03Tqg==";

        public CryptoTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Encrypt()
        {
            var encrypted = Helpers.CryptoHelper.Encrypt(message, key);

            output.WriteLine(encrypted.output);
            output.WriteLine(encrypted.iv);
        }

        [Fact]
        public void Decrypt()
        {
            var decrypted = Helpers.CryptoHelper.Decrypt(encrypted, iv, key);
            Assert.Equal(message, decrypted);

            output.WriteLine(decrypted);
        }

        [Fact]
        public void EncryptAndDecrypt()
        {
            var encrypted = Helpers.CryptoHelper.Encrypt(message, key);
            var decrypted = Helpers.CryptoHelper.Decrypt(encrypted.output, encrypted.iv, key);

            Assert.Equal(message, decrypted);
        }
    }
}

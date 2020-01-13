using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace EwelinkNet.Helpers
{
    public class EwelinkHelper
    {
        internal static string MakeNonce()
        {
            var nonce = new byte[15];
            RandomNumberGenerator.Fill(nonce);

            return Convert.ToBase64String(nonce);
        }

        internal static string MakeTimestamp()
        {
            var seed = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var timestamp = Math.Floor(seed / 1000);
            return (timestamp).ToString(CultureInfo.InvariantCulture);
        }

        internal static (string timestamp, string sequence) MakeSequence()
        {
            var seed = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var timestamp = Math.Floor(seed / 1000);
            var sequence = Math.Floor(timestamp);
            return (timestamp.ToString(CultureInfo.InvariantCulture), sequence.ToString(CultureInfo.InvariantCulture));
        }

        internal static string MakeFakeImei()
        {
            var random = new Random();
            var num1 = random.Next(1000, 9999);
            var num2 = random.Next(1000, 9999);

            return $"DF7425A0-{num1}-{num2}-9F5E-3BC9179E48FB";
        }
    }
}

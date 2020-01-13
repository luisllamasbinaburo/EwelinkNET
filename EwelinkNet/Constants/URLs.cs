using System;
using System.Collections.Generic;
using System.Text;

namespace EwelinkNet.Constants
{
    internal static class URLs
    {
        public static string GetApiUrl(string region)
        {
            return $"https://{region}-api.coolkit.cc:8080/api";
        }

        public static string GetWebsocketUrl(string region)
        {
            return $"wss://{region}-pconnect3.coolkit.cc:8080/api/ws";
        }

        public static string GetOtaUrl(string region)
        {
            return $"https://{region}-ota.coolkit.cc:8080/otaother";
        }

        public static string GetZeroconfUrl(string ip)
        {
            return $"http://{ip}:8081/zeroconf";
        }
    }
}

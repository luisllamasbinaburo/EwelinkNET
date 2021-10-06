using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using EwelinkNet.Classes;
using EwelinkNet.Constants;
using EwelinkNet.Helpers;


namespace EwelinkNet.Payloads
{
    internal class WsCredentialsPayload
    {
        public string action { get; internal set; }
        public string userAgent { get; internal set; }
        public string version { get; internal set; }
        public string nonce { get; internal set; }
        public string apkVesrion { get; internal set; }

        public string appid { get; internal set; }

        public string os { get; internal set; }
        public string at { get; internal set; }
        public string apikey { get; internal set; }
        public string ts { get; internal set; }
        public string model { get; internal set; }
        public string romVersion { get; internal set; }
        public string sequence { get; internal set; }


        internal WsCredentialsPayload(string accessToken, string apiKey)
        {
            var seq = EwelinkHelper.MakeSequence();

            action = "userOnline";
            userAgent = "app";
            version = AppData.VERSION;
            nonce = EwelinkHelper.MakeNonce();
            apkVesrion = AppData.APK_VERSION;
            appid = AppData.APP_ID;
            os = AppData.OS;
            at = accessToken;
            apikey = apiKey;
            ts = seq.timestamp;
            model = AppData.MODEL;
            romVersion = AppData.ROM_VERSION;
            sequence = seq.sequence;
        }
    }
}

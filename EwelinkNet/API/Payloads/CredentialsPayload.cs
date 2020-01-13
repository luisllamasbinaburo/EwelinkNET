using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using EwelinkNet.Constants;
using EwelinkNet.Helpers;
using Newtonsoft.Json;

namespace EwelinkNet.Payloads
{
    internal class CredentialsPayload
    {
        public string email { get; internal set; }
        public string password { get; internal set;}
        public string version { get; internal set; }
        public string ts { get; internal set; }
        public string nonce { get; internal set; }
        public string appid { get; internal set; }
        public string imei { get; internal set; }
        public string os { get; internal set; }
        public string model { get; internal set;}
        public string romVersion { get; internal set; }
        public string appVersion { get; internal set; }


        internal CredentialsPayload(string email, string password)
        {
            this.email = email;
            this.password = password;
            version = AppData.VERSION;
            ts = EwelinkHelper.MakeTimestamp();
            nonce = EwelinkHelper.MakeNonce();
            os = AppData.OS;
            appid = AppData.APP_ID;
            imei = EwelinkHelper.MakeFakeImei();
            model = AppData.MODEL;
            romVersion = AppData.ROM_VERSION;
            appVersion = AppData.APP_VERSION;
        }

    }
}

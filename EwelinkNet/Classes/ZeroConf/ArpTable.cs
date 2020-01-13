using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Linq;
using System.Runtime.InteropServices;
using EwelinkNet.Helpers.Extensions;
using System.IO;
using Newtonsoft.Json;

namespace EwelinkNet.Classes
{
    public class ArpTable
    {
        public List<ArpEntry> Entries { get; set; } = new List<ArpEntry>();

        public IPAddress[] GetIPAddressByMac(PhysicalAddress mac) => Entries.ToLookup(x => x.Mac)[mac].Select(x => x.Ip).ToArray();

        public PhysicalAddress[] GetMacByIPAddress(IPAddress ip) => Entries.ToLookup(x => x.Ip)[ip].Select(x => x.Mac).ToArray();

        public void RestoreFromFile(string filename = "arp-table.json")
        {
            var json = File.ReadAllText(filename);
            var entries = JsonConvert.DeserializeAnonymousType(json, new[] { new { ip = "", mac = "" } });
            Entries = entries.Select(x => new ArpEntry(x.ip, x.mac)).ToList();
        }
    }
}

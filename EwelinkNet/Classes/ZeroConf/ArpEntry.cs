using System;
using System.Net;
using System.Net.NetworkInformation;

namespace EwelinkNet.Classes
{
    public class ArpEntry : IEquatable<ArpEntry>
    {
        public IPAddress Ip { get; set; }
        public PhysicalAddress Mac { get; set; }

        public ArpEntry(IPAddress ip, PhysicalAddress mac)

        {
            Ip = ip;
            Mac = mac;
        }

        public ArpEntry(string ip, string mac)

        {
            Ip = IPAddress.Parse(ip);
            Mac = PhysicalAddress.Parse(mac.Replace(':', '-'));
        }

        public override string ToString()

        {
            return $"IP={Ip} MAC={Mac}";
        }

        public bool Equals(ArpEntry other)
        {
            return Ip.Equals(other.Ip) && Mac.Equals(other.Mac);
        }
    }
}

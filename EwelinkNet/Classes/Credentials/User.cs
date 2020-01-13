using System;
using System.Collections.Generic;


namespace EwelinkNet.Classes
{
    public class User
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string appId { get; set; }
        public DateTime createdAt { get; set; }
        public string apikey { get; set; }
        public int __v { get; set; }
        public string ip { get; set; }
        public string location { get; set; }
        public string lang { get; set; }
        public string userStatus { get; set; }
        public bool online { get; set; }
        public DateTime onlineTime { get; set; }
        public DateTime offlineTime { get; set; }
        public BindInfos bindInfos { get; set; }
        public IList<AppInfo> appInfos { get; set; }
    }
}
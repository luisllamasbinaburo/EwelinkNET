using System;
using System.Collections.Generic;
using System.Text;

namespace EwelinkNet.Classes.Events
{
    public class EvendDeviceUpdate : EventArgs
    {
        public Device Device { get; set; }
    }
}

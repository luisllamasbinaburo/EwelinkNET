using EwelinkNet.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace EwelinkNet.Classes
{
    public class RfBridgeDevice : Device
    {
        public void TransmitChannel(int channel)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, $"rfCh{channel}", 0);
            data.cmd = "transmit";

            UpdateDevice(data);
        }
    }
}

using EwelinkNet.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EwelinkNet.Classes
{
    public abstract class SingleChannelDevice : Device
    {
        public void SetState(string state)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, channelName, state);

            UpdateDevice(data);
        }

        public void SetStateLAN(string state)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, channelName, state);
 
            ZeroConfUpdateDevice(data);
        }
    }
}

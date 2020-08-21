using EwelinkNet.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace EwelinkNet.Classes
{
    public partial class MultiChannelDevice : Device
    {
        public int NumChannels => (int)Constants.DeviceChannels.GetDeviceChannelsByName(deviceName);

        public void SetAllChannels(string state)
        {
            SetChannels(Enumerable.Range(1, NumChannels).Select(x => new OutletState(x, state)).ToArray());
        }

        public void SetChannel(int outlet, string state)
        {
            if(outlet >= NumChannels) return;
            SetChannels(new[] { new OutletState(outlet, state) });
        }

        public void SetChannels(OutletState[] states)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, channelName, states);

            UpdateDevice(data);
        }

        public void SetAllChannelsLAN(string state)
        {
            SetChannelsLAN(Enumerable.Range(1, NumChannels).Select(x => new OutletState(x, state)).ToArray());
        }

        public void SetChannelLAN(int outlet, string state)
        {
            SetChannelsLAN(new[] { new OutletState(outlet, state) });
        }

        public void SetChannelsLAN(OutletState[] states)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, channelName, states);

            ZeroConfUpdateDevice(data, "/switches");
        }
    }
}

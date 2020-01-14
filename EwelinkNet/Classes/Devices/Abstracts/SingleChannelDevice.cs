using EwelinkNet.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task SetStateLAN(string state)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, channelName, state);
 
            await ZeroConfUpdateDevice(data);
        }

        public void SetPulse(string state, int width)
        {
            if(width < Constants.Pulse.PULSE_MIN_WIDTH) width = Constants.Pulse.PULSE_MIN_WIDTH;
            if(width > Constants.Pulse.PULSE_MAX_WIDTH) width = Constants.Pulse.PULSE_MAX_WIDTH;
            
            dynamic data = new ExpandoObject();
            data.pulse = state;
            data.pulseWidth = width;

            UpdateDevice(data);
        }
    }
}

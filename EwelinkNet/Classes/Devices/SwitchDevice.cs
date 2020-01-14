using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace EwelinkNet.Classes
{
    public class SwitchDevice : SingleChannelDevice
    {
        public void TurnOff() => SetState("off");
        public void TurnOn() => SetState("on");
        public void Toggle() => (GetState() == "on" ? (Action)TurnOff : (Action)TurnOn)();
  
        public async Task TurnOnLAN() => await SetStateLAN("on");
        public async Task TurnOffLAN() => await SetStateLAN("off");

        public string GetState() => @params.@switch;

    }
}
